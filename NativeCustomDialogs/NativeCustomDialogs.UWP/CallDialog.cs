using NativeCustomDialogs.UWP;
using NativeCustomDialogs.UWP.Dialogs;
using NativeCustomDialogs.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: Xamarin.Forms.Dependency(
   typeof(CallDialog))]
namespace NativeCustomDialogs.UWP
{
    public class CallDialog : ICallDialog
    {
        async Task ICallDialog.CallDialog(object viewModel)
        {
            await new CreateTodoDialog(viewModel as CreateTodoViewModel).ShowAsync();
        }
    }
}
