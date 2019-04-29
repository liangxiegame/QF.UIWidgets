using TodoListUIWidgets;
using Unity.UIWidgets;

namespace LearnUIWidgets
{
    public class SaveMiddleware
    {
        public static Middleware<State> create<State>() where State : TodoViewState
        {
            return (store) => (next) => new DispatcherImpl((action) =>
            {                
                var result = next.dispatch(action);
                var afterState = store.getState();
                afterState.Todos.Save();
                return result;
            });
        }
    }
}