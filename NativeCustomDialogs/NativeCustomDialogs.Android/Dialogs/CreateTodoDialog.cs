using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using NativeCustomDialogs.ViewModels;
using ReactiveUI;
using ReactiveUI.AndroidSupport;

namespace NativeCustomDialogs.Droid.Dialogs
{
    class CreateTodoDialog : ReactiveDialogFragment
    {
        public CreateTodoViewModel ViewModel { get; set; }
        EditText _titleEditText;
        Button _doneBtn;
        Button _cancelBtn;
        Spinner _icons;

        public CreateTodoDialog(CreateTodoViewModel vm)
        {
            ViewModel = vm;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.CreateTodoLayout,
                container, false);

            _titleEditText = view.FindViewById<EditText>(Resource.Id.TitleEditText);
            _doneBtn = view.FindViewById<Button>(Resource.Id.CatDoneButton);
            _cancelBtn = view.FindViewById<Button>(Resource.Id.CatCancelButton);

            _titleEditText.Hint = "Title";

            //Use WhenAny to create a kind of one way databining between view and viewmodel property
            this.WhenAny(x => x._titleEditText.Text, x => x.Value).Subscribe((val) =>
            {
                ViewModel.Title = val;
            });

            _doneBtn.Text = "Done";
            _cancelBtn.Text = "Cancel";
            _doneBtn.Click += DoneBtn_Click;
            _cancelBtn.Click += (o, e) => this.Dismiss();

            return view;
        }

        private async void DoneBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_titleEditText.Text))
            {
                if (((ICommand)ViewModel.CreateTodo).CanExecute(null))
                {
                    ((ICommand)ViewModel.CreateTodo).Execute(null);
                    this.Dismiss();
                }
            }
            else
            {
                _titleEditText.SetError("Enter the title please", Resources.GetDrawable(Resource.Drawable.abc_ab_share_pack_mtrl_alpha));
            }
        }

        public override Dialog OnCreateDialog(Bundle savedState)
        {
            var dialog = base.OnCreateDialog(savedState);
            dialog.SetTitle("Create New Todo");
            return dialog;
        }
    }
}