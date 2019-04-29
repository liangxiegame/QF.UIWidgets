using System.Collections.Generic;
using QFramework.UIWidgets;
using Unity.UIWidgets.engine;
using Unity.UIWidgets.material;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.rendering;
using Unity.UIWidgets.widgets;

namespace LearnUIWidgets
{
    public class StackExample : UIWidgetsPanel
    {
        protected override Widget createWidget()
        {
            return QF.ConstrainedBox
                .Constraints(BoxConstraints.expand())
                .Child(QF.Stack
                    .AlignmentCenter()
                    .FitExpand()
                    .Children(new List<Widget>()
                    {
                        QF.Container
                            .Child(QF.Text
                                .Data("Hello world")
                                .FontColor(Colors.white)
                                .EndText())
                            .Color(Colors.red)
                            .EndContainer(),
                        new Text("I am Jack")
                            .Positioned(left:18.0f),
                        new Text("Your friend")
                            .Positioned(top:18.0f)
                    })
                    .EndStack())
                .EndConstrainedBox();
        }
    }
}