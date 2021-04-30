using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarauderMap.Solutions;
using Microsoft.AspNetCore.Components;

namespace MarauderMap.Blazor.Pages.Designers
{
    public partial class Designer
    {
        [Parameter]
        public string SolutionPath { get; set; }

        protected SolutionDto Solution { get; set; }

        [Inject]
        private ISolutionAppService SolutionAppService { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            await base.OnParametersSetAsync();

            Solution = await SolutionAppService.SetPathAsync(SolutionPath);
        }
    }
}
