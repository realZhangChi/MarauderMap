using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
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
        public NodeModel NodeModel { get; set; }

        [Inject]
        protected IGuidGenerator GuidGenerator { get; set; }

        [Inject]
        private IJSRuntime JsRuntime { get; set; }

        [Inject]
        private ILogger<Node> Logger { get; set; }

        protected string Id { get; private set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            Id = GuidGenerator.Create().ToString("N");
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            _jsTask = _jsTask = new Lazy<Task<IJSObjectReference>>(() => JsRuntime.InvokeAsync<IJSObjectReference>(
                "import", "./solutionTree.js").AsTask());
        }

        private async Task OnToggleClickedAsync()
        {
            var js = await _jsTask.Value;
            await js.InvokeVoidAsync("toggle", Id);
        }
    }
}
