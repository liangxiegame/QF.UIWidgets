using System.Collections;
using System.Collections.Generic;
using Unity.UIWidgets.engine;
using Unity.UIWidgets.material;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.rendering;
using Unity.UIWidgets.widgets;
using UnityEngine;

namespace LearnUIWidgets
{
    public class InheritedWidgetExample : UIWidgetsPanel
    {
        protected override Widget createWidget()
        {
            return new MaterialApp(
                home: new Scaffold(
                    body: new InheritWidgetTestRoute()
                )
            );
        }

        class ShareDataWidget : InheritedWidget
        {
            public int Data; //需要在子树中共享的数据，保存点击次数

            public ShareDataWidget(int data, Widget child) : base(child: child)
            {
                Data = data;
            }

            //定义一个便捷方法，方便子树中的widget获取共享数据  
            public static ShareDataWidget of(BuildContext context)
            {
                return context.inheritFromWidgetOfExactType(typeof(ShareDataWidget)) as ShareDataWidget;
            }

            public override bool updateShouldNotify(InheritedWidget oldWidget)
            {
                return (oldWidget as ShareDataWidget).Data != Data;
            }
        }

        class TestWidget : StatefulWidget
        {
            public override State createState()
            {
                return new TestWidgetState();
            }
        }

        class TestWidgetState : State<TestWidget>
        {
            public override Widget build(BuildContext context)
            {
                //使用InheritedWidget中的共享数据
                return new Text(
                    ShareDataWidget.of(context).Data.ToString());
            }

            public override void didChangeDependencies()
            {
                base.didChangeDependencies();
                //父或祖先widget中的InheritedWidget改变(updateShouldNotify返回true)时会被调用。
                //如果build中没有依赖InheritedWidget，则此回调不会被调用。
                print("Dependencies change");
            }
        }

        class InheritWidgetTestRoute : StatefulWidget
        {
            public override State createState()
            {
                return new InheritWidgetTestState();
            }
        }

        class InheritWidgetTestState : State<InheritWidgetTestRoute>
        {
            int mCount = 0;

            public override Widget build(BuildContext context)
            {
                return new Center(
                    child: new ShareDataWidget(
                        data: mCount,
                        child: new Column(
                            mainAxisAlignment: MainAxisAlignment.center,
                            children: new List<Widget>()
                            {
                                new Padding(
                                    padding: EdgeInsets.only(bottom: 20.0f),
                                    child: new TestWidget() //子widget中依赖ShareDataWidget
                                ),
                                new RaisedButton(
                                    child: new Text("Increment"),
                                    //每点击一次，将count自增，然后重新build,ShareDataWidget的data将被更新
                                    onPressed: () => setState(() => ++mCount)
                                )
                            }
                        )
                    )
                );
            }
        }
    }
}