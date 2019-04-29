using System.Collections.Generic;
using Unity.UIWidgets.engine;
using Unity.UIWidgets.widgets;

namespace LearnUIWidgets
{
    public class SingleDirectionDragExample : UIWidgetsPanel
    {
        protected override Widget createWidget()
        {
            return new SingleDirectionDragRoute();
        }

        class SingleDirectionDragRoute : StatefulWidget
        {
            public override State createState()
            {
                return new SingleDirectionDragState();
            }
        }

        class SingleDirectionDragState : State<SingleDirectionDragRoute>
        {
            float mTop = 0.0f;

            public override Widget build(BuildContext context)
            {
                return new Stack(
                    children: new List<Widget>
                    {
                        new Positioned(
                            top: mTop,
                            child: new GestureDetector(
                                child: new Text("A"),
                                //垂直方向拖动事件
                                onVerticalDragUpdate: (details) => { setState(() => { mTop += details.delta.dy; }); }
                            )
                        )
                    }
                );
            }
        }
    }
}