using System;
using System.Collections;
using System.Collections.Generic;
using Unity.UIWidgets.animation;
using Unity.UIWidgets.engine;
using Unity.UIWidgets.material;
using Unity.UIWidgets.scheduler;
using Unity.UIWidgets.widgets;
using UnityEngine;

namespace LearnUIWidgets
{
    public class AnimatedBuilderExample : UIWidgetsPanel
    {
        protected override Widget createWidget()
        {
            return new MaterialApp(
                home:new Scaffold(
                    body: new ScaleAnimationRoute()
                )
            );
        }

        class ScaleAnimationRoute : StatefulWidget
        {
            public override State createState()
            {
                return new ScaleAnimationState();
            }
        }

        class GrowTransition  : StatelessWidget
        {
            Widget mChild;
            Animation<float> mAnimation;
            
            public GrowTransition (Widget child,Animation<float> animation)
            {
                mChild = child;
                mAnimation = animation;
            }

            public override Widget build(BuildContext context)
            {
                return new AnimatedBuilder(
                    animation: mAnimation,
                    child:mChild,
                    builder: (ctx, child) => new Center(
                        child: new Container(
                            height: mAnimation.value,
                            width: mAnimation.value,
                            child: child
                        )
                    ));
            }
        }

        class ScaleAnimationState : State<ScaleAnimationRoute>,TickerProvider
        {
            Animation<float>    mAnimation;
            AnimationController mController;

            public override void initState()
            {
                base.initState();

                mController = new AnimationController(
                    duration: TimeSpan.FromSeconds(3),
                    vsync: this
                );
                
                mAnimation = new FloatTween(begin:0,end:300).animate(mController);
                
                mController.addStatusListener((status) =>
                {
                    Debug.Log(status);

                    if (status == AnimationStatus.completed)
                    {
                        mController.reverse();
                    }
                });
                
                //启动动画(正向执行)
                mController.forward();
                Debug.Log("on tap");
            }

            public override Widget build(BuildContext context)
            {
                return new GrowTransition(
                    child: Image.asset("unity-white"),
                    animation: mAnimation
                );
            }

            public Ticker createTicker(TickerCallback onTick)
            {
                return new Ticker(onTick);
            }
        }
    }
}