using NativeCustomDialogs.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Input;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace NativeCustomDialogs.UWP.Dialogs
{
    public sealed partial class CreateTodoDialog : ContentDialog
    {
        CreateTodoViewModel ViewModel => DataContext as CreateTodoViewModel;
        bool _canClose;

        public CreateTodoDialog(CreateTodoViewModel vm)
        {
            this.InitializeComponent();
            DataContext = vm;
            Closing += CreateCategoryDialog_Closing;
        }

        private void CreateCategoryDialog_Closing(ContentDialog sender, ContentDialogClosingEventArgs args)
        {
            if (!_canClose)
            {
                args.Cancel = true;
            }
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            if(string.IsNullOrEmpty(TitleDialog.Text))
            {
                TitleDialog.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            else
            {
                if((ViewModel.CreateTodo as ICommand).CanExecute(null))
                {
                    (ViewModel.CreateTodo as ICommand).Execute(null);
                }
                _canClose = true;
                this.Hide();
            }
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            _canClose = true;
            this.Hide();
        }
    }
}
