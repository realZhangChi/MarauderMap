using System;
using System.Threading.Tasks;
using MarauderMap.Blazor.Components.ContextMenus;
using MarauderMap.Solutions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;
using Volo.Abp.Guids;

namespace MarauderMap.Blazor.Components.SolutionTrees
{
    public partial class Node
    {
        private Lazy<Task<IJSObjectReference>> _jsTask;

        [Parameter]
        public int NestedLevel { get; set; }

        [Parameter]
        public TreeNodeDto NodeModel { get; set; }

        [Parameter]
        public EventCallback OnClickCallback { get; set; }

        [Inject]
        private IJSRuntime JsRuntime { get; set; }

        public string Id { get; private set; }

        public bool IsSelected { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            Id = Guid.NewGuid().ToString("N");
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            _jsTask = _jsTask = new Lazy<Task<IJSObjectReference>>(() => JsRuntime.InvokeAsync<IJSObjectReference>(
                "import", "./solutionTree.js").AsTask());
        }

        private async Task OnClickedAsync(MouseEventArgs e)
        {
            var js = await _jsTask.Value;
            IsSelected = true;
            if (e.Button == 0 && !NodeModel.IsFile)
            {
                await js.InvokeVoidAsync("toggle", Id);
            }

            await OnClickCallback.InvokeAsync(this);
        }

    }
}
