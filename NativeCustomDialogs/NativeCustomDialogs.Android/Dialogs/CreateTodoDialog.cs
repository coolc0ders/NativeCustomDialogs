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

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.CreateTodoLayout,
                container, false);

            _titleEditText = view.FindViewById<EditText>(Resource.Id.TitleEditText);
            _doneBtn = view.FindViewById<Button>(Resource.Id.CatDoneButton);
            _cancelBtn = view.FindViewById<Button>(Resource.Id.CatCancelButton);

            _titleEditText.Hint = ViewModel.TitlePlaceholder;
            this.WhenAny(x => x._titleEditText.Text, x => x.Value).Subscribe((val) =>
            {
                ViewModel.Title = val;
            });

            _doneBtn.Text = "Done".Translate();
            _cancelBtn.Text = "Cancel".Translate();
            _doneBtn.Click += DoneBtn_Click;
            _cancelBtn.Click += CancelBtn_Click;

            return view;
        }

        private async void DoneBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_titleEditText.Text))
            {
                if (((ICommand)ViewModel.DoneClicked).CanExecute(null))
                {
                    ((ICommand)ViewModel.DoneClicked).Execute(null);
                    this.Dismiss();
                }
            }
            else
            {
                //_validationTextView.Visibility = ViewStates.Visible;
                //_titleEditText.SetBackgroundResource(Resource.Layout.ErrorEditTextLayout);
                _titleEditText.SetError("EnterTitleError".Translate(), Resources.GetDrawable(Resource.Drawable.ic_error_outline_black_24dp));
            }
        }

        public override Dialog OnCreateDialog(Bundle savedState)
        {
            var dialog = base.OnCreateDialog(savedState);
            dialog.SetTitle("Create New Expenditure");
            return dialog;
        }
    }
}