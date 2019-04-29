using System.Collections.Generic;
using System.Linq;
using LearnUIWidgets;
using QFramework.UIWidgets;
using Unity.UIWidgets;
using Unity.UIWidgets.engine;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.widgets;
using Unity.UIWidgets.material;
using Unity.UIWidgets.Redux;
using Unity.UIWidgets.ui;
using UnityEngine;

namespace TodoListUIWidgets
{
    public class TodoListApp : UIWidgetsPanel
    {
        protected override void OnEnable()
        {
            base.OnEnable();
            FontManager.instance.addFont(Resources.Load<Font>("MaterialIcons-Regular"), "Material Icons");
        }

        protected override Widget createWidget()
        {
            var appWidghet = new MaterialApp(
                initialRoute:"/",
                routes:new Dictionary<string, WidgetBuilder>()
                {
                    {"/",builder=>new HomeScreen()}
                }
            );

            var store = new Store<TodoViewState>(reducer: Reducers.Reduce,
                initialState: new TodoViewState()
                {
                    Todos = Model.Load()
                },
                SaveMiddleware.create<TodoViewState>(),
                ReduxThunk.create<TodoViewState>());

            var provider = new StoreProvider<TodoViewState>(store: store, child: appWidghet);
            return provider;
        }
    }
}