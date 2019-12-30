using Microsoft.JSInterop;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blazing.Dialog
{
    public class DialogAccess
    {

        TaskCompletionSource<object> taskCompletionSource;

        protected static ConcurrentDictionary<string, DialogAccess> openedDialogues = new ConcurrentDictionary<string, DialogAccess>();

        internal Func<Task> OpenAction { get; set; }
        internal Func<Task> CloseAction { get; set; }
        internal string DialogId { get; set; }
        public string Title { get; set; }

        public virtual Task OpenAsync(string title)
        {
            Title = title;
            return OpenAction();
        }

        public async Task OpenAsync()
        {
            if (OpenAction is null) throw new Exception("Not set to dialog");
            if (taskCompletionSource != null || openedDialogues.ContainsKey(DialogId)) return;
            taskCompletionSource = new TaskCompletionSource<object>();
            openedDialogues[DialogId] = this;
            await OpenAction();
            await taskCompletionSource.Task;
        }

        public virtual Task CancelAsync() => CloseAction();

        internal virtual void ClearTask()
        {
            taskCompletionSource.SetResult(null);
            openedDialogues.TryRemove(DialogId, out _);
            taskCompletionSource = null;
        }

        [JSInvokable]
        public static void ShutBlazingDialog(string id)
        {
            if (openedDialogues.TryGetValue(id, out var dialog)) dialog.ClearTask();
        }

    }

    public class DialogAccess<TResponse> : DialogAccess
    {

        TaskCompletionSource<TResponse> taskCompletionSource;

        public override Task OpenAsync(string title)
        {
            Title = title;
            return OpenAction();
        }

        public new async Task<TResponse> OpenAsync()
        {
            if (OpenAction is null) throw new Exception("Not set to dialog");
            if (taskCompletionSource != null || openedDialogues.ContainsKey(DialogId)) return default;
            taskCompletionSource = new TaskCompletionSource<TResponse>();
            openedDialogues[DialogId] = this;
            await OpenAction();
            var res = await taskCompletionSource.Task;
            return res;
        }

        internal override void ClearTask()
        {
            taskCompletionSource.SetResult(default);
            openedDialogues.TryRemove(DialogId, out _);
            taskCompletionSource = null;
        }

        public async Task CompleteAsync(TResponse result)
        {
            taskCompletionSource.SetResult(result);
            openedDialogues.TryRemove(DialogId, out _);
            taskCompletionSource = null;
            await CloseAction();
        }

    }


}
