using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using NativeCustomDialogs.Droid;

[assembly: Xamarin.Forms.Dependency(
   typeof(CallDialog))]
namespace NativeCustomDialogs.Droid
{
    public class CallDialog : ICallDialog
    {
        Task ICallDialog.CallDialog(object viewModel)
        {
            throw new NotImplementedException();
        }
    }
}