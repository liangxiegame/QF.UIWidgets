using System.Collections;
using System.Collections.Generic;
using Unity.UIWidgets.engine;
using Unity.UIWidgets.gestures;
using Unity.UIWidgets.material;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.widgets;

namespace LearnUIWidgets
{
    public class ListenerExample : UIWidgetsPanel
    {
        protected override Widget createWidget()
        {
            return new ListenerTestRoute();
        }

        class ListenerTestRoute : StatefulWidget
        {
            public override State createState()
            {
                return new ListenerTestState();
            }
        }

        class ListenerTestState : State<ListenerTestRoute>
        {
            PointerEvent mEvent;
            
            public override Widget build(BuildContext context)
            {
                return new Listener(
                    child: new Container(
                        alignment: Alignment.center,
                        color: Colors.blue,
                        width: 300.0f,
                        height: 150.0f,
                        child: new Text(mEvent?.ToString() ?? "", style: new TextStyle(color: Colors.white))
                    ),
                    onPointerDown: (pointerEvent) => setState(() => mEvent = pointerEvent),
                    onPointerMove:
                    (pointerEvent) => setState(() => mEvent = pointerEvent),
                    onPointerUp:
                    (pointerEvent) => setState(() => mEvent = pointerEvent)
                );
            }
        }
    }
}