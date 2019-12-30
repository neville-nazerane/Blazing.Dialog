using Blazing.Dialog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazing.Sample.Pages
{
    public partial class OptionsDialog
    {

        Dictionary<int, string> options = new Dictionary<int, string> {
            { 1, "Sample 1" },
            { 2, "Sample two" }
        };

        DialogAccess<string> dialog = new DialogAccess<string>();
        DialogAccess<int> dialogWithIds = new DialogAccess<int>();

        string message;
        private string _newOption;
        string NewOption
        {
            get => _newOption; 
            set
            {
                _newOption = value;
                AddOption();
            }
        }

        async Task ShowAsync()
        {
            message = "Dialog is now open";
            string result = await dialog.OpenAsync();
            if (result is null) message = "Dialog was closed";
            else message = $"You choose item: {result}!";
        }

        async Task ShowWithIdAsync()
        {
            message = "Dialog is now open";
            int result = await dialogWithIds.OpenAsync();
            if (result is 0) message = "Dialog was closed";
            else message = $"You choose item with id: {result}!";
        }

        void AddOption()
        {
            if (string.IsNullOrWhiteSpace(NewOption)) return;
            int nextId = options.Keys.Max() + 1;
            options[nextId] = NewOption;
            NewOption = null;
        }



    }
}
