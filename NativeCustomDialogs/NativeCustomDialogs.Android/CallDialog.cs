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
using NativeCustomDialogs.Droid.Dialogs;
using NativeCustomDialogs.ViewModels;
using Plugin.CurrentActivity;
using Xamarin.Forms.Platform.Android;

[assembly: Xamarin.Forms.Dependency(
   typeof(CallDialog))]
namespace NativeCustomDialogs.Droid
{
    public class CallDialog : ICallDialog
    {
        async Task ICallDialog.CallDialog(object viewModel)
        {
            var activity = CrossCurrentActivity.Current.Activity as FormsAppCompatActivity;

            new CreateTodoDialog(viewModel as CreateTodoViewModel)
                        .Show(activity.SupportFragmentManager, "CreateTodoDialog");
        }
    }
}