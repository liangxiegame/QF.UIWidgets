using System;
using System.Collections;
using System.Collections.Generic;
using Unity.UIWidgets.animation;
using Unity.UIWidgets.engine;
using Unity.UIWidgets.material;
using Unity.UIWidgets.scheduler;
using Unity.UIWidgets.ui;
using Unity.UIWidgets.widgets;
using UnityEngine;

namespace LearnUIWidgets
{
    public class TurnBoxExample : UIWidgetsPanel
    {
        protected override void OnEnable()
        {
            base.OnEnable();
            
            FontManager.instance.addFont(Resources.Load<Font>("MaterialIcons-Regular"), "Material Icons");

        }

        protected override Widget createWidget()
        {
            return new MaterialApp(
                home:new Scaffold(
                    body:new TurnBoxTestRoute()
                    )
                
                );
        }


        class TurnBoxTestRoute : StatefulWidget
        {
            public override State createState()
            {
                return new TurnBoxTestState();
            }
        }

        class TurnBoxTestState : State<TurnBoxTestRoute>
        {
            private float _turns = 0.0f;

            public override Widget build(BuildContext context)
            {
                return new Center(
                    child: new Column(
                        children: new List<Widget>
                        {
                            new TurnBox(
                                turns: _turns,
                                speed: 500,
                                child: new Icon(Icons.refresh, size: 50)
                            ),
                            new TurnBox(
                                turns: _turns,
                                speed: 1000,
                                child: new Icon(Icons.refresh, size: 150.0f)
                            ),
                            new RaisedButton(
                                child: new Text("顺时针旋转1/5圈"),
                                onPressed: () => { setState(() => { _turns += 0.2f; }); }
                            ),
                            new RaisedButton(
                                child: new Text("逆时针旋转1/5圈"),
                                onPressed: () => { setState(() => { _turns -= 0.2f; }); }
                            )
                        }
                    )
                );
            }
        }
    }
    
    public class TurnBox : StatefulWidget
    {
        public readonly float Turns;
        public readonly int? Speed;
        public readonly Widget Child;

        public TurnBox(float turns, Widget child,int? speed = null)
        {
            Turns = turns;
            Speed = speed;
            Child = child;
        }
        
        public override State createState()
        {
            return new TurnBoxState();
        }
        
        
        class TurnBoxState : State<TurnBox> ,TickerProvider
        {
            private AnimationController _controller;


            public override void initState()
            {
                base.initState();

                _controller = new AnimationController(
                    vsync: this,
                    value: widget.Turns,
                    lowerBound: float.NegativeInfinity,
                    upperBound: float.PositiveInfinity
                );
            }

            public override void dispose()
            {
                base.dispose();
                _controller.dispose();
            }

            public override Widget build(BuildContext context)
            {
                return new RotationTransition(
                    turns: _controller,
                    child: widget.Child
                );
            }


            public override void didUpdateWidget(StatefulWidget oldWidget)
            {
                base.didUpdateWidget(oldWidget);
                
                //旋转角度发生变化时执行过渡动画  
                if ((oldWidget as TurnBox).Turns != widget.Turns) {
                    _controller.animateTo(
                        widget.Turns,
                        duration: TimeSpan.FromMilliseconds(widget.Speed ?? 200),
                        curve: Curves.easeOut
                    );
                }
            }

            public Ticker createTicker(TickerCallback onTick)
            {
                return new Ticker(onTick);
            }
        }
    }
    

}