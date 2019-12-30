using Blazing.Dialog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazing.Sample.Pages
{
    public partial class SimpleDialog
    {
        
        readonly DialogAccess _dialog = new DialogAccess();

        string message;

        async Task ShowAsync()
        {
            message = "Dialog is now open";
            await _dialog.OpenAsync();
            message = "Dialog has now closed";
        }



    }
}
