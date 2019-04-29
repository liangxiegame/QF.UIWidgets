using System.Collections.Generic;
using Unity.UIWidgets.engine;
using Unity.UIWidgets.material;
using Unity.UIWidgets.widgets;

namespace LearnUIWidgets
{
    public class DragExample : UIWidgetsPanel
    {
        protected override Widget createWidget()
        {
            return new MaterialApp(
                home: new Scaffold(
                    body: new DragTestRoute()
                )
            );
        }

        class DragTestRoute : StatefulWidget
        {
            public override State createState()
            {
                return new DragTestState();
            }
        }

        class DragTestState : State<DragTestRoute>
        {
            float mTop  = 0.0f; //距顶部的偏移
            float mLeft = 0.0f;//距左边的偏移
            
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
                                //手指按下时会触发此回调
                                onPanDown: (e) =>
                                {
                                    //打印手指按下的位置(相对于屏幕)
                                    print("用户手指按下：${e.globalPosition}");
                                },
                                //手指滑动时会触发此回调
                                onPanUpdate: (e) =>
                                {
                                    //用户手指滑动时，更新偏移，重新构建
                                    setState(() =>
                                    {
                                        mLeft += e.delta.dx;
                                        mTop += e.delta.dy;
                                    });
                                },
                                onPanEnd: (e) =>
                                {
                                    //打印滑动结束时在x、y轴上的速度
                                    print(e.velocity);
                                }
                            )
                        )
                    }
                );
            }
        }
    }
    
    
}