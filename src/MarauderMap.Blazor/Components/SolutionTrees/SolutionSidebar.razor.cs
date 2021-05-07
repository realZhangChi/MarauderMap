using System;
using System.Threading.Tasks;
using MarauderMap.Blazor.Components.ContextMenus;
using MarauderMap.Solutions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using Volo.Abp.Guids;

namespace MarauderMap.Blazor.Components.SolutionTrees
{
    public partial class SolutionSidebar
    {
        [Inject]
        protected IGuidGenerator GuidGenerator { get; set; }

        [Parameter]
        public TreeNodeDto Root { get; set; }

        public Node SelectedNodeReference { get; private set; }

        private ContextMenu _contextMenu;

        private Task OnNodeClickAsync(object arg)
        {
            if (arg is not Node clickNode)
            {
                return Task.CompletedTask;
            }

            // TODO: Better way(Decoupled) to set selected state
            if (SelectedNodeReference is not null)
            {
                SelectedNodeReference.IsSelected = false;
            }
            SelectedNodeReference = clickNode;

            return Task.CompletedTask;
        }

        private Task OnMouseUpAsync(MouseEventArgs e)
        {
            if (e.Button == 2)
            {
                _contextMenu.ShowAsync(e.ClientX, e.ClientY);
            }
            return Task.CompletedTask;
        }

    }
}
