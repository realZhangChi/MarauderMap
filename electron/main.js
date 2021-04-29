// require('update-electron-app')({
//   logger: require('electron-log')
// })

const path = require('path')
const {spawn, exec} = require('child_process')
const {app, Menu, Tray, BrowserWindow, shell, dialog} = require('electron')

const debug = /--debug/.test(process.argv[2])

if (process.mas) app.setName('AbpHelper')

if (process.platform === 'darwin') require('fix-path')()

let mainWindow = null
let contextMenu = null
let blazorHost = null
let httpApiHost = null

let forceQuit = false

function initialize () {
  makeSingleInstance()

  function runHttpApiHost() {
    httpApiHost = spawn('dotnet', ['MarauderMap.HttpApi.Host.dll', '--urls', 'https://localhost:44308'], {cwd: "./host/MarauderMap.HttpApi.Host"})

    httpApiHost.on('close', function (code) {
      if (code !== 0) {
        console.log(`MarauderMap.HttpApi.Host exited with code ${code}`);
      }
      forceQuit = true;
      app.quit()
    })
  }

  function runBlazorHost() {
    blazorHost = spawn('dotnet', ['MarauderMap.Blazor.Host.dll', '--urls', 'https://localhost:44307'], {cwd: "./host/MarauderMap.Blazor.Host"})

    blazorHost.on('close', function (code) {
      if (code !== 0) {
        console.log(`MarauderMap.Blazor exited with code ${code}`);
      }
      forceQuit = true;
      app.quit()
    })
  }

  process.on('exit', function () {
    if (blazorHost != null) blazorHost.kill(2)
    if (httpApiHost != null) httpApiHost.kill(2)
  });

  function createWindow () {
    const windowOptions = {
      width: 1600,
      minWidth: 680,
      height: 1200,
      title: app.name + ' v' + app.getVersion(),
      webPreferences: {
        nodeIntegration: true,
        webSecurity: false
      },
      icon: path.join(__dirname, '/assets/app-icon/png/32.png')
    }

    if (process.platform === 'linux') {
      windowOptions.icon = path.join(__dirname, '/assets/app-icon/png/512.png')
    }

    mainWindow = new BrowserWindow(windowOptions)
    mainWindow.setMenuBarVisibility(false)
    mainWindow.loadURL(path.join('https://localhost:44307'))

    // Launch fullscreen with DevTools open, usage: npm run debug
    if (debug) {
      mainWindow.webContents.openDevTools()
      mainWindow.maximize()
      // require('devtron').install()
    }

    mainWindow.on('closed', () => {
      mainWindow = null
    })
    mainWindow.on('close', (event) => { 
      mainWindow.hide(); 
      if (!forceQuit) event.preventDefault();
    })
  }

  app.on('ready', () => {
    let checkDotnetProcess = exec("dotnet --version", (error, stdout, stderr) => {
      if (error) {
        dialog.showMessageBoxSync({type: "error", message: "Required .NET 5.0+ runtime is not installed."})
        app.quit()
        return
      }
      
      let trustCertProcess = exec("dotnet dev-certs https --trust")
    
      trustCertProcess.on('close', function (code) {
        runHttpApiHost()
        runBlazorHost()
        setTimeout(function() {
          createWindow()
        }, 1000);
      })
    });
  })

  app.on('window-all-closed', () => {
    if (process.platform !== 'darwin') {
      app.quit()
    }
  })

  app.on('activate', () => {
    if (mainWindow === null) {
      createWindow()
    }else if (process.platform === 'darwin' && !mainWindow.isVisible()) {
      createWindow()
    }
  })

  app.on('before-quit', () => {
    if (process.platform === 'darwin') {
      forceQuit = true;
    }
 });
}

// Make this app a single instance app.
//
// The main window will be restored and focused instead of a second window
// opened when a person attempts to launch a second instance.
//
// Returns true if the current version of the app should quit instead of
// launching.
function makeSingleInstance () {
  if (process.mas) return

  if (!app.requestSingleInstanceLock()) {
    app.quit()
  }

  app.on('second-instance', () => {
    if (mainWindow) {
      if (mainWindow.isMinimized()) mainWindow.restore()
      mainWindow.focus()
    }
  })
}

initialize()