using NativeCustomDialogs.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Text;
using Xamarin.Forms;

namespace NativeCustomDialogs.ViewModels
{
    public class MainViewModel : ReactiveObject
    {
        ReactiveList<Todo> _todos;
        public ReactiveList<Todo> Todos
        {
            get => _todos;
            set => this.RaiseAndSetIfChanged(ref _todos, value);
        }

        public ReactiveCommand CreateTodoCommand { get; set; }

        public MainViewModel()
        {
            CreateTodoCommand = ReactiveCommand.Create(async () =>
            {
                //CAll the Dialog
                await DependencyService.Get<ICallDialog>().CallDialog(new CreateTodoViewModel());
            });

            Todos = new ReactiveList<Todo>() { ChangeTrackingEnabled = true };
            
            Todos.ItemChanged.Where(x => x.PropertyName == "IsDone" && x.Sender.IsDone)
                .Select(x => x.Sender)
                .Subscribe(x =>
                {
                    if (x.IsDone)
                    {
                        Todos.Remove(x);
                        Todos.Add(x);
                    }
                });
        }
        
        public void Initialize()
        {
            MessagingCenter.Subscribe<object, Todo>(this, $"ItemCreated", (s, todo) =>
            {
                Todos.Add(todo);
            });
        }

        public void Stop()
        {
            MessagingCenter.Unsubscribe<object, Todo>(this, $"ItemCreated");
        }
    }
}
