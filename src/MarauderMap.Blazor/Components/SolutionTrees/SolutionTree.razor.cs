using System;
using System.Threading.Tasks;
using MarauderMap.Solutions;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Volo.Abp.Guids;

namespace MarauderMap.Blazor.Components.SolutionTrees
{
    public partial class SolutionTree
    {
        [Inject]
        protected IGuidGenerator GuidGenerator { get; set; }

        [Parameter]
        public TreeNodeDto Root { get; set; }

    }
}
