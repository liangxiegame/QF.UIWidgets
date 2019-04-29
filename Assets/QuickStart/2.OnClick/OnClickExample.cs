using Unity.UIWidgets.engine;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.widgets;
using UnityEngine;
using Color = Unity.UIWidgets.ui.Color;

namespace LearnUIWidgets
{
    public class OnClickExample : UIWidgetsPanel
    {
        protected override Widget createWidget()
        {
            return
                new GestureDetector(
                    child: new Text("OnClick", style: new TextStyle(color: Color.white, fontSize: 30)),
                    onTap: () => { Debug.Log("onTap"); });
        }
    }
}