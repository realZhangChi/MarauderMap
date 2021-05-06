﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using MarauderMap.Blazor.Components.ContextMenus;
using MarauderMap.Blazor.Components.SolutionTrees;
using MarauderMap.Solutions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;

namespace MarauderMap.Blazor.Pages
{
    public partial class Index
    {
        private Lazy<Task<IJSObjectReference>> _jsTask;

        [Inject]
        private IJSRuntime JsRuntime { get; set; }

        [Inject]
        private ISolutionAppService SolutionAppService { get; set; }

        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        protected ContextMenu ContextMenu;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            _jsTask = new Lazy<Task<IJSObjectReference>>(() => JsRuntime.InvokeAsync<IJSObjectReference>(
                "import", "./index.js").AsTask());
        }

        private async Task OnOpenSolutionClickedAsync()
        {
            var js = await _jsTask.Value;
            var solutionPath = await js.InvokeAsync<string>("selectSolution");
            NavigationManager.NavigateTo($"designer/{WebUtility.UrlEncode(solutionPath)}");
        }

        private Task OnOpenSolutionClickedAsync(MouseEventArgs e)
        {
            ContextMenu.Top = e.ClientY;
            ContextMenu.Left = e.ClientX;
            return Task.CompletedTask;
        }
    }
}
