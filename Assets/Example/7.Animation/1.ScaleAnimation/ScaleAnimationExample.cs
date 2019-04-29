using System;
using System.Collections;
using System.Collections.Generic;
using QFramework.UIWidgets;
using Unity.UIWidgets.animation;
using Unity.UIWidgets.engine;
using Unity.UIWidgets.material;
using Unity.UIWidgets.scheduler;
using Unity.UIWidgets.widgets;
using UnityEngine;

namespace LearnUIWidgets
{
    public class ScaleAnimationExample : UIWidgetsPanel
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

        class AnimatedImage : AnimatedWidget
        {
            public AnimatedImage(Animation<float> animation) : base(listenable: animation)
            {

            }

            protected override Widget build(BuildContext context)
            {
                Animation<float> animation = listenable as Animation<float>;
                
                return new Center(
                    child: Image.asset("unity-white",
                        width: animation.value,
                        height: animation.value
                    )
                );
            }
        }

        class ScaleAnimationState : State<ScaleAnimationRoute>,TickerProvider
        {
            Animation<float> mAnimation;
            AnimationController mController;

            public override void initState()
            {
                base.initState();

                mController = new AnimationController(
                    duration: TimeSpan.FromSeconds(3),
                    vsync: this
                );
                
                mAnimation = new FloatTween(begin:0,end:300).animate(mController);
                
                //启动动画(正向执行)
                mController.forward();
                Debug.Log("on tap");
            }

            public override Widget build(BuildContext context)
            {
                return new AnimatedImage(animation: mAnimation);
            }

            public Ticker createTicker(TickerCallback onTick)
            {
                return new Ticker(onTick);
            }
        }
    }
}