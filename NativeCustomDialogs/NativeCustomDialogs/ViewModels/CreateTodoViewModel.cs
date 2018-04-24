using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace NativeCustomDialogs.ViewModels
{
    public class CreateTodoViewModel : ReactiveObject
    {
        public ReactiveCommand CreateTodo { get; set; }
        private string _title;

        public string Title
        {
            get { return _title; }
            set {
                this.RaiseAndSetIfChanged(ref _title, value); }
        }

        private string _description;

        public string Description
        {
            get { return _description; }
            set {
                this.RaiseAndSetIfChanged(ref _description, value); }
        }

        public CreateTodoViewModel()
        {
            CreateTodo = ReactiveCommand.Create(() =>
            {
                MessagingCenter.Send<>
            });
        }
    }
}
