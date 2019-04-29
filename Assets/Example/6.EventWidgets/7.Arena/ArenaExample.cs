using System.Collections.Generic;
using Unity.UIWidgets.engine;
using Unity.UIWidgets.material;
using Unity.UIWidgets.widgets;

namespace LearnUIWidgets
{
    public class ArenaExample : UIWidgetsPanel
    {
        protected override Widget createWidget()
        {
            return new MaterialApp(
                home: new Scaffold(
                    body: new ArenaTestRoute()
                )
            );

        }

        class ArenaTestRoute : StatefulWidget
        {
            public override State createState()
            {
                return new ArenaTestState();
            }
        }

        class ArenaTestState : State<ArenaTestRoute>
        {
            float mTop  = 0.0f;
            float mLeft = 0.0f;

            public override Widget build(BuildContext context)
            {
                return new Stack(
                    children: new List<Widget>
                    {
                        new Positioned(
                            top: mTop,
                            left: mLeft,
                            child: new GestureDetector(
                                child: new Text("A"),
                                //垂直方向拖动事件
                                onVerticalDragUpdate: (details) => { setState(() => { mTop += details.delta.dy; }); },
                                onHorizontalDragUpdate: (details) => { setState(() => { mLeft += details.delta.dx; }); }
                            )
                        )
                    }
                );
            }
        }
    }
}