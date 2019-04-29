using System.Collections;
using System.Collections.Generic;
using Unity.UIWidgets.engine;
using Unity.UIWidgets.gestures;
using Unity.UIWidgets.material;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.widgets;
using UnityEngine;

namespace LearnUIWidgets
{
    public class GestureRecognizerExample : UIWidgetsPanel
    {
        protected override Widget createWidget()
        {
            return new GestureRecognizerTestRoute();
        }

        class GestureRecognizerTestRoute : StatefulWidget
        {
            public override State createState()
            {
                return new GestureRecognizerTestState();
            }
        }

        class GestureRecognizerTestState : State<GestureRecognizerTestRoute>
        {
            TapGestureRecognizer mTapGestureRecognizer = new TapGestureRecognizer();
            bool                 mToggle               = false; //变色开关

            public override void dispose()
            {
                mTapGestureRecognizer.dispose();
                base.dispose();
            }

            public override Widget build(BuildContext context)
            {
                mTapGestureRecognizer.onTap = () => { setState(() => { mToggle = !mToggle; }); };

                return new Center(
                    child: Text.rich(
                        new TextSpan(
                            children: new List<TextSpan>()
                            {
                                new TextSpan(text: "你好世界"),
                                new TextSpan(
                                    text: "点我变色",
                                    style: new TextStyle(
                                        fontSize: 30.0f,
                                        color: mToggle ? Colors.blue : Colors.red
                                    ),
                                    recognizer: mTapGestureRecognizer
                                ),
                                new TextSpan(text: "你好世界"),
                            }
                        )
                    )
                );
            }
        }
    }
}