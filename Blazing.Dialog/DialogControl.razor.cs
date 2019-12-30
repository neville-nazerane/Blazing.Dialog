using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazing.Dialog
{
    public partial class DialogControl
    {

        string currentId;

        [Inject]
        IJSRuntime JSRuntime { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public DialogAccess Access { get; set; }

        protected override void OnParametersSet()
        {
            if (Access != null && string.IsNullOrEmpty(currentId))
            {
                currentId = Guid.NewGuid().ToString("N");

                Access.DialogId = currentId;
                Access.OpenAction = Opener;
                Access.CloseAction = Closer;
            }
            base.OnParametersSet();
        }

        Task Opener() => JSRuntime.InvokeVoidAsync("bsModal.show", currentId).AsTask();
        Task Closer() => JSRuntime.InvokeVoidAsync("bsModal.hide", currentId).AsTask();

    }
}
