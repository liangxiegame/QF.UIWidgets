using System.Collections.Generic;
using System.Linq;
using LearnUIWidgets;
using QFramework.UIWidgets;
using Unity.UIWidgets;
using Unity.UIWidgets.material;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.Redux;
using Unity.UIWidgets.widgets;
using UnityEngine;

namespace TodoListUIWidgets
{
    class TodoListPage : StatefulWidget
        {
            public override State createState()
            {
                return new TodoListState();
            }
        }

        public enum TodoListPageMode
        {
            List,
            Finished
        }
        
        class TodoListState : State<TodoListPage>
        {   

            void OnChanged()
            {
                this.setState(()=>{});
            }

            void Save()
            {
            }


            public override Widget build(BuildContext context)
            {
                return new StoreConnector<TodoViewState, TodoViewState>(
                    converter: state => state,
                    builder: (buildContext, model, dispatcher) =>
                    {
                        if (model.TodoListPageMode == TodoListPageMode.List)
                        {
                            return QF.ListView
                                .Child(new IconButton(icon:new Icon(Icons.network_wifi),onPressed: () =>
                                    {
                                        dispatcher.dispatch(NetworkRequestAction.Create());
                                    }))
                                .Child(new TodoInputView(data =>
                                {
                                    dispatcher.dispatch(new AddTodoAction(data));
                                }))
                                .Children(ListTodoViews(model.Todos,dispatcher))
                                .Padding(EdgeInsets.only(top: 50))
                                .EndListView();
                        }

                        return QF.ListView
                            .Children(FinishedTodoViews(model.Todos,dispatcher))
                            .Padding(EdgeInsets.only(top: 50))
                            .EndListView();
                    });
            }


            private Widget[] ListTodoViews(List<Todo> todos,Dispatcher dispatcher)
            {
                var retWidgets = new List<Widget>();

                foreach (var data in todos.Where(data => !data.Finished))
                {
                    retWidgets.Add(new TodoView(data,
                        () =>
                        {
                            dispatcher.dispatch(new FinishTodoAction(data));
                        },
                        () =>
                        {
                            dispatcher.dispatch(new DeleteTodoAction(data));
                        },
                        (newContent) =>
                        {
                            dispatcher.dispatch(new UpdateTodoAction(data, newContent));
                        }));
                    retWidgets.Add(new Divider());
                }

                return retWidgets.ToArray();
            }

            private Widget[] FinishedTodoViews(List<Todo> todos,Dispatcher dispatcher)
            {

                var retWidgets = new List<Widget>();

                foreach (var data in todos.Where(data => data.Finished))
                {
                    retWidgets.Add(new TodoView(data,
                        () =>
                        {
                            dispatcher.dispatch(new FinishTodoAction(data));
                        },
                        () =>
                        {
                            dispatcher.dispatch(new DeleteTodoAction(data));
                        },
                        (newContent) =>
                        {
                            dispatcher.dispatch(new UpdateTodoAction(data, newContent));
                        }));
                    retWidgets.Add(new Divider());
                }

                return retWidgets.ToArray();
            }
        }
}