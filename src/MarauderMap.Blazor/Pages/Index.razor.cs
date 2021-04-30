using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MarauderMap.Blazor.Components.SolutionTrees;
using MarauderMap.Solution;
using Microsoft.AspNetCore.Components;
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

        private readonly NodeModel _treeRoot = new NodeModel()
        {
            Name = "解决方案文件夹",
            IsFile = false,
            Children = new List<NodeModel>()
            {
                new NodeModel()
                {
                    Name = "文件.cs",
                    IsFile = true
                },
                new NodeModel()
                {
                    Name = "文件夹1",
                    IsFile = false,
                    Children = new List<NodeModel>()
                    {
                        new NodeModel()
                        {
                            Name = "文件2.js",
                            IsFile = true
                        },
                        new NodeModel()
                        {
                            Name = "文件夹2",
                            IsFile = false
                        }
                    }
                }
            }
        };

        public NodeModel TreeRoot => _treeRoot;


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
            await SolutionAppService.SetPathAsync(solutionPath);
        }
    }
}
