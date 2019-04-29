

using System.Net.Http;
using TodoListUIWidgets;
using Unity.UIWidgets.Redux;

namespace LearnUIWidgets
{
    public class ListPageModeAction
    {
    }

    public class FinishedPageModeAction
    {
    }


    public class AddTodoAction
    {
        public AddTodoAction(string todoContent)
        {
            TodoContent = todoContent;
        }

        public string TodoContent { get; }
    }

    public class DeleteTodoAction
    {
        public readonly Todo Todo;

        public DeleteTodoAction(Todo todo)
        {
            Todo = todo;
        }
    }

    public class FinishTodoAction
    {
        public readonly Todo Todo;

        public FinishTodoAction(Todo todo)
        {
            Todo = todo;
        }
    }

    public class UpdateTodoAction
    {
        public readonly Todo Todo;
        public readonly string NewContent;

        public UpdateTodoAction(Todo todo, string newContent)
        {
            Todo = todo;
            NewContent = newContent;
        }
    }

    public class NetworkRequestAction
    {
        public string Result { get; set; }

        public static ThunkAction<TodoViewState> Create()
        {
            return new ThunkAction<TodoViewState>(action: (dispatcher, getState) =>
            {
                var client = new HttpClient();

                var task = client.GetAsync("http://sikiedu.com");

                task.GetAwaiter().OnCompleted(() =>
                {
                    var contentTask = task.Result.Content.ReadAsStringAsync();

                    contentTask.GetAwaiter().OnCompleted(() =>
                    {
                        dispatcher.dispatch(new NetworkRequestAction()
                        {
                            Result = contentTask.Result
                        });
                    });
                });

                return null;
            });
        }
    }
}