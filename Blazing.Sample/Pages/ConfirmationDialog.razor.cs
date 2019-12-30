using Blazing.Dialog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazing.Sample.Pages
{
    public partial class ConfirmationDialog
    {

        DialogAccess<bool> dialog = new DialogAccess<bool>();


        string message;

        async Task ShowAsync()
        {
            message = "Dialog is now open";
            if (await dialog.OpenAsync())
                message = "You picked Yes";
            else message = "Selected NO!";
        }


    }
}
