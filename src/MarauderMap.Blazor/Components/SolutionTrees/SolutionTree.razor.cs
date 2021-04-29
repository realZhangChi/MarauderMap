using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace MarauderMap.Blazor.Components.SolutionTrees
{
    public partial class SolutionTree
    {
        private Lazy<Task<IJSObjectReference>> _jsTask;

        [Inject]
        private IJSRuntime JsRuntime { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            _jsTask = _jsTask = new Lazy<Task<IJSObjectReference>>(() => JsRuntime.InvokeAsync<IJSObjectReference>(
                "import", "./solutionTree.js").AsTask());
        }

        private async Task OnToggleClickedAsync(string id)
        {
            var js = await _jsTask.Value;
            await js.InvokeVoidAsync("toggle", id);
        }
    }
}
