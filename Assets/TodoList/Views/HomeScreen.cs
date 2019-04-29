using LearnUIWidgets;
using QFramework.UIWidgets;
using Unity.UIWidgets.material;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.Redux;
using Unity.UIWidgets.widgets;

namespace TodoListUIWidgets
{
    public class HomeScreen : StatelessWidget
    {
        public override Widget build(BuildContext buildContext)
        {
            return new Scaffold(
                appBar: new AppBar(
                    title: new Center(child:
                        QF.Text
                            .Data("TodoList")
                            .FontBold()
                            .FontSize(30)
                            .EndText())
                ),
                drawer: new Drawer(child:
                    QF.ListView
                        .Padding(EdgeInsets.zero)
                        .Child(new Divider())
                        .Child(
                            new StoreConnector<TodoViewState, object>(
                                converter: (state) => null,
                                builder: (context, model, dispatcher) => new ListTile(
                                    leading: new Icon(Icons.list, size: 30),
                                    title: QF
                                        .Text
                                        .Data("待办事项")
                                        .FontSize(25)
                                        .FontBold()
                                        .EndText(),
                                    onTap: () => { dispatcher.dispatch(new ListPageModeAction()); }
                                )
                            ))
                        .Child(new Divider())
                        .Child(new StoreConnector<TodoViewState, object>(
                            converter: (state) => null,
                            builder: (context, model, dispatcher) => new ListTile(
                                leading: new Icon(Icons.check_box, size: 30),
                                title: QF
                                    .Text
                                    .Data("已完成")
                                    .FontBold()
                                    .FontSize(25)
                                    .EndText(),
                                onTap: () => { dispatcher.dispatch(new FinishedPageModeAction()); }
                            ))
                        )
                        .Child(new Divider())
                        .EndListView()),
                body: new TodoListPage());
        }
    }
}