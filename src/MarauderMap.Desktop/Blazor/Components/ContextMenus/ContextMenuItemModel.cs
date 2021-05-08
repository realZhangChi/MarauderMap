using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace MarauderMap.Desktop.Blazor.Components.ContextMenus
{
    public class ContextMenuItemModel
    {
        public string Name { get; set; }

        public bool IsEnable { get; set; }

        public EventCallback OnClickedCallBack { get; set; }
    }
}
