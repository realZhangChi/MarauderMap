using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace MarauderMap.Blazor.Components.ContextMenus
{
    public partial class ContextMenuItem
    {
        [Parameter]
        public ContextMenuItemModel Model { get; set; }

        private Task OnClicked()
        {
            return !Model.IsEnable ? Task.CompletedTask : Model.OnClickedCallBack.InvokeAsync();
        }
    }
}
