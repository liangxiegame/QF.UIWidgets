using System;
using System.Collections;
using System.Collections.Generic;
using QFramework.UIWidgets;
using Unity.UIWidgets.animation;
using Unity.UIWidgets.engine;
using Unity.UIWidgets.material;
using Unity.UIWidgets.ui;
using Unity.UIWidgets.widgets;
using UnityEngine;

namespace LearnUIWidgets
{
    public class ScrollControllerExample : UIWidgetsPanel
    {
        protected override void OnEnable()
        {
            base.OnEnable();
            FontManager.instance.addFont(Resources.Load<Font>("MaterialIcons-Regular"), "Material Icons");
        }

        protected override Widget createWidget()
        {
            return new MaterialApp(
                home: new ScrollControllerRoute()
            );
        }

        class ScrollControllerRoute : StatefulWidget
        {
            public override State createState()
            {
                return new ScrollControllerState();
            }
        }

        class ScrollControllerState : State<ScrollControllerRoute>
        {
            ScrollController mController   = new ScrollController();
            bool             mShowToTopBtn = false; //是否显示“返回到顶部”按钮


            public override void initState()
            {
                base.initState();

                mController.addListener(() =>
                {
                    Debug.Log(mController.offset);
                    if (mController.offset < 1000 && mShowToTopBtn)
                    {
                        setState(() => { mShowToTopBtn = false; });
                    }
                    else if (mController.offset >= 1000 && mShowToTopBtn == false)
                    {
                        setState(() => { mShowToTopBtn = true; });
                    }
                });
            }

            public override void dispose()
            {
                mController.dispose();
                base.dispose();
            }

            public override Widget build(BuildContext context)
            {
                return new Scaffold(
                    appBar: new AppBar(title: new Text("滚动控制")),
                    body: new Scrollbar(
                        child: ListView.builder(
                            itemCount: 100,
                            itemExtent: 50.0f,
                            controller: mController,
                            itemBuilder: (buildContext, index) => new ListTile(title: new Text(index.ToString()))
                        )
                    ),
                    floatingActionButton: !mShowToTopBtn
                        ? null
                        : new FloatingActionButton(
                            child: new Icon(Icons.arrow_upward),
                            onPressed: () =>
                            {
                                //返回到顶部时执行动画
                                mController.animateTo(0.0f,
                                    duration: TimeSpan.FromMilliseconds(200),
                                    curve: Curves.ease
                                );
                            }
                        )
                );
            }
        }
    }
}