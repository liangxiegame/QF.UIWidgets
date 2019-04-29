using Unity.UIWidgets.engine;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.ui;
using Unity.UIWidgets.widgets;

namespace LearnUIWidgets
{
    public class SetupApp : UIWidgetsPanel
    {
        protected override Widget createWidget()
        {
            return new Text("Hello World",
                style: new TextStyle(color: Color.white, fontSize: 30));
        }
    }
}