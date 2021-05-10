using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarauderMap.Desktop.Blazor.Components.EntityModals
{
    public class ModalSaveClickEventArgs
    {
        public ModalSaveClickEventArgs(object data)
        {
            Data = data;
        }

        public object Data { get; protected set; }
    }
}
