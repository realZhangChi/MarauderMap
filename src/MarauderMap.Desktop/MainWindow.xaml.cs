using System;
using System.Windows;

namespace MarauderMap.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(IServiceProvider serviceProvider)
        {
            Resources.Add("services", serviceProvider);
            InitializeComponent();
        }
    }
}
