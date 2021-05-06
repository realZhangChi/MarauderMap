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

        private double _top;
        public double Top
        {
            get => _top;
            set
            {
                _top = value;
                StateHasChanged();
            }
        }

        private double _left;
        public double Left
        {
            get => _left;
            set
            {
                _left = value;
                StateHasChanged();
            }
        }

        private string Styles => $"top: {_top}px; left: {_left}px; {(_top == 0 && _left == 0 ? "display: none;" : string.Empty)}";

        public string Id { get; } = Guid.NewGuid().ToString("N");

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            _jsTask = new Lazy<Task<IJSObjectReference>>(() => JsRuntime.InvokeAsync<IJSObjectReference>(
                "import", "./contextMenu.js").AsTask());
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

        private Task OnBlurAsync()
        {
            Top = 0;
            Left = 0;
            return Task.CompletedTask;
        }
    }
}
