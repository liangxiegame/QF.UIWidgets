using System;
using System.Collections;
using System.Collections.Generic;
using Unity.UIWidgets.animation;
using Unity.UIWidgets.engine;
using Unity.UIWidgets.material;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.rendering;
using Unity.UIWidgets.scheduler;
using Unity.UIWidgets.ui;
using Unity.UIWidgets.widgets;

namespace LearnUIWidgets
{
    public class StaggerAnimationExample : UIWidgetsPanel
    {
        protected override Widget createWidget()
        {
            return new MaterialApp(
                home: new Scaffold(
                    body: new StaggerDemo()
                )
            );
        }

        class StaggerDemo : StatefulWidget
        {
            public override State createState()
            {
                return new StaggerDemoState();
            }
        }

        class StaggerAnimation : StatelessWidget
        {
            Animation<float> mController;
            Animation<float>     height;
            Animation<EdgeInsets> padding;
            Animation<Color>      color;

            public StaggerAnimation(Animation<float> controller) : base()
            {
                mController = controller;

                height = new FloatTween(begin: 0, end: 300)
                    .animate(new CurvedAnimation(
                        parent: mController,
                        curve: new Interval(
                            0.0f, 0.6f,
                            curve: Curves.ease
                        )
                    ));

                color = new ColorTween(begin: Colors.green, end: Colors.red)
                    .animate(new CurvedAnimation(
                        parent: mController,
                        curve: new Interval(
                            0.0f, 0.6f,
                            curve: Curves.ease
                        )
                    ));

                padding = new EdgeInsetsTween(
                    begin: EdgeInsets.only(left: 0.0f),
                    end: EdgeInsets.only(left: 100.0f)
                ).animate(new CurvedAnimation(
                    parent: mController,
                    curve: new Interval(
                        0.6f, 1.0f,
                        curve: Curves.ease
                    )
                ));
            }

            Widget _buildAnimation(BuildContext context, Widget child)
            {
                return new Container(
                    alignment: Alignment.bottomCenter,
                    padding: padding.value,
                    child: new Container(
                        color: color.value,
                        width: 50.0f,
                        height: height.value
                    )
                );
            }

            public override Widget build(BuildContext context)
            {
                return new AnimatedBuilder(
                    builder: _buildAnimation,
                    animation: mController
                );
            }
        }

        class StaggerDemoState :State<StaggerDemo>,TickerProvider
        {
            AnimationController mController;

            public override void initState()
            {
                base.initState();

                mController = new AnimationController(
                    duration: TimeSpan.FromMilliseconds(2000),
                    vsync: this
                );
            }
            
            void _playAnimation()
            {

                mController.forward().orCancel.Then(() =>
                {
                    
                    mController.reverse().orCancel.Then(() => { });
                });
            }

            public override Widget build(BuildContext context)
            {
                return new GestureDetector(
                    behavior: HitTestBehavior.opaque,
                    onTap: () =>
                    {
                        _playAnimation();                        
                    },
                    child: new Center(
                        child: new Container(
                            width: 300.0f,
                            height: 300.0f,
                            decoration: new BoxDecoration(
                                color: Colors.black.withOpacity(0.1f),
                                border: Border.all(
                                    color: Colors.black.withOpacity(0.5f)
                                ))
                            ,
                            child:
                            new StaggerAnimation(
                                controller: mController
                            )))
                );
            }

            public Ticker createTicker(TickerCallback onTick)
            {
                return new Ticker(onTick);
            }
        }
    }
}