# Blazing.Dialog

Open dialogs (bootstrap modals) in blazor with awaitable calls. 



![Nuget](https://img.shields.io/nuget/v/Blazing.Dialog.svg)


## Things to note:

1. As mentioned this uses bootstrap modals (bootstrap 4+). This means it is dependent on jquery and bootstrap javascript references that isn't imported in the default blazor templates. Make sure you add these imports. Here are some useful links: 

    jQuery: https://code.jquery.com/

    bootstrap: https://www.bootstrapcdn.com/

    bootstrap (older versions): https://www.bootstrapcdn.com/legacy/bootstrap/

2. This nuget aims at functionality and doesn't come with a any UI/css out of the box. You can use any boiler-plate boostrap modal code. 

## Installation:

1. Install the [nuget package](https://www.nuget.org/packages/Blazing.Dialog/) 
    ```powershell
    install-package Blazing.Dialog
    ```

2. Import the script file in your index.html
    ```html
    <script src="_content/Blazing.Dialog/scripts.js"></script>
    ```

3. In the _imports.razor file, add the following import:
    ```csharp
    @using Blazing.Dialog
    ```

## Usage:

### C# code

Create a new instance of the `DialogAccess` class; 
```csharp
readonly DialogAccess dialog = new DialogAccess();
```

You can now open this dialog by calling `dialog.OpenAsync()`. **`OpenAsync` will only work when `dialog` is bound to a dialog UI (next section)** 

```csharp
// do something before the dialog is opened
await dialog.OpenAsync();
// do something after the  is closed
```

You can programatically close the dialog by calling `dialog.CancelAsync()` at any time. 

It is often helpful if the `OpenAsync` function returned some data relating to a selection in the dialog. Here are some examples
- A confirmation dialog can return a bool. It can return true only when the user clicks "Yes".
- A dialog can display a list of options and can return a string representing the selection. 
- A dialog can display a list of options and return an int representing the Id of the selection.

All above examples can be found in the blazor sample project in this repo. 

To make the `OpenAsync` function return a type of your choice, you can use the generic `DialogAccess` class. Your declaration would change to: 

```csharp
readonly DialogAccess<string> dialog = new DialogAccess<string>();
```

Next, to make the `OpenAsync` complete and return a specific string, you can call `dialog.CompleteAsync("my response")` while the dialog is still open. This code normally goes in a blazor onclick event. See the "ConfirmationDialog.razor" and "OptionsDialog.razor" pages in the blazor sample for detailed examples. 


### Blazor code for binding UI

Add the `DialogControl` component and assign the `Access` property to the `dialog` field created above. 

```html
<DialogControl Access=dialog>
<!-- Add your own modal content here -->
</DialogControl>
```

The `DialogControl` creates a div with a "modal" class. You can add any boiler plate code "modal-content" code for **bootstrap 4 modals**. Here is one sample: https://www.w3schools.com/bootstrap4/bootstrap_modal.asp.



