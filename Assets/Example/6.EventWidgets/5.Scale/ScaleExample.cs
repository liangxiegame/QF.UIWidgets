using System.Collections;
using System.Collections.Generic;
using QFramework.UIWidgets;
using Unity.UIWidgets.engine;
using Unity.UIWidgets.material;
using Unity.UIWidgets.widgets;
using UnityEngine;

namespace LearnUIWidgets
{
    public class ScaleExample : UIWidgetsPanel
    {
        protected override Widget createWidget()
        {
            return new ScaleTestRoute();
        }

        class ScaleTestRoute : StatefulWidget
        {
            public override State createState()
            {
                return new ScaleTestState();
            }
        }

        class ScaleTestState : State<ScaleTestRoute>
        {
            
            float mWidth = 200.0f; //通过修改图片宽度来达到缩放效果

            public override Widget build(BuildContext context)
            {
                return new Center(
                    child: new GestureDetector(
                        //指定宽度，高度自适应
                        child: QF.Container
                            .Color(Colors.blue)
                            .Width(mWidth)
                            .Height(mWidth)
                            .EndContainer()
//                        onScaleUpdate: (ScaleUpdateDetails details) {
//                    setState(() {
//                        //缩放倍数在0.8到10倍之间
//                        _width=200*details.scale.clamp(.8, 10.0);
//                    });
//                }
                )
                );
            }
        }
    }
}
