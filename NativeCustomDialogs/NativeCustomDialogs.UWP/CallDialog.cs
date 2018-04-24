using NativeCustomDialogs.UWP;
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
        Task ICallDialog.CallDialog(object viewModel)
        {
            throw new NotImplementedException();
        }
    }
}
