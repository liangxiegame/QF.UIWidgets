using System;
using System.Collections;
using System.Collections.Generic;
using Unity.UIWidgets.engine;
using Unity.UIWidgets.material;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.widgets;
using UnityEngine;

namespace LearnUIWidgets
{
    public class GestureDetectorExample : UIWidgetsPanel
    {
        protected override Widget createWidget()
        {
            return new GestureDetectorTestRoute();
        }

        class GestureDetectorTestRoute : StatefulWidget
        {
            public override State createState()
            {
                return new GestureDetectorTestState();
            }
        }

        class GestureDetectorTestState : State<GestureDetectorTestRoute>
        {
            string mOperation = "No Gesture detected!"; //保存事件名

            public override Widget build(BuildContext context)
            {
                return new Center(
                    child: new GestureDetector(
                        child: new Container(
                            alignment: Alignment.center,
                            color: Colors.blue,
                            width: 200.0f,
                            height: 100.0f,
                            child: new Text(mOperation,
                                style: new TextStyle(color: Colors.white)
                            ))
                        , onTap: () => UpdateText("Tap"), //点击
                        onDoubleTap: _ => UpdateText("DoubleTap"), //双击
                        onLongPress: () => UpdateText("LongPress") //长按

                    )

                );
            }

            void UpdateText(string text)
            {
                //更新显示的事件名
                setState(() => { mOperation = text; });
            }
        }
    }
}