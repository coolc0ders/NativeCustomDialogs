using NativeCustomDialogs.Models;
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

        public CreateTodoViewModel()
        {
            CreateTodo = ReactiveCommand.Create(() =>
            {
                MessagingCenter.Send<object, Todo>(this, $"ItemCreated", new Todo { Title = Title, IsDone = false});
            });
        }
    }
}
