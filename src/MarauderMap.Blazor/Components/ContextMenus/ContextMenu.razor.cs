using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Volo.Abp.Guids;

namespace MarauderMap.Blazor.Components.ContextMenus
{
    public partial class ContextMenu
    {

        private Lazy<Task<IJSObjectReference>> _jsTask;

        [Inject]
        private IJSRuntime JsRuntime { get; set; }

        protected double Top { get; private set; }

        protected double Left { get; private set; }

        private bool _isDisplay;

        private string Styles => $"top: {Top}px; left: {Left}px; {(_isDisplay ? string.Empty : "display: none;")}";

        public string Id { get; } = Guid.NewGuid().ToString("N");

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            if (firstRender)
            {
                _jsTask = new Lazy<Task<IJSObjectReference>>(() => JsRuntime.InvokeAsync<IJSObjectReference>(
                    "import", "./contextMenu.js").AsTask());
            }
            var js = await _jsTask.Value;
            await js.InvokeVoidAsync("focus", Id);
        }


        public List<ContextMenuItemModel> Model => new List<ContextMenuItemModel>()
        {
            new ContextMenuItemModel()
            {
                Name = "Menu1",
                IsEnable = true
            },
            new ContextMenuItemModel()
            {
                Name = "Menu2",
                IsEnable = false
            }
        };

        public Task ShowAsync(double x, double y)
        {
            Left = x;
            Top = y;
            _isDisplay = true;
            StateHasChanged();
            return Task.CompletedTask;
        }

        private Task OnBlurAsync()
        {
            Top = 0;
            Left = 0;
            _isDisplay = false;
            StateHasChanged();
            return Task.CompletedTask;
        }
    }
}
