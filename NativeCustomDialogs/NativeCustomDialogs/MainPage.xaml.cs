using NativeCustomDialogs.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NativeCustomDialogs
{
	public partial class MainPage : ContentPage
	{
        public MainViewModel ViewModel => BindingContext as MainViewModel;

        public MainPage()
		{
			InitializeComponent();
		}

        protected override void OnAppearing()
        {
            //Initialize the viewmodel
            ViewModel.Initialize();
            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            ViewModel.Stop();
            base.OnDisappearing();
        }
    }
}
