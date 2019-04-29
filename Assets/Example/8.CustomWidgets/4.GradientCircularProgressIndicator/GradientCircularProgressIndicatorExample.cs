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
    public class GradientCircularProgressIndicatorExample : UIWidgetsPanel
    {
        protected override Widget createWidget()
        {
            return new MaterialApp(
                home: new Scaffold(
                    body: new GradientCircularProgressRoute()));
        }

        class GradientCircularProgressRoute : StatefulWidget
        {
            public override State createState()
            {
                return new GradientCircularProgressState();
            }
        }

        class GradientCircularProgressState : State<GradientCircularProgressRoute>
        ,TickerProvider
        {
            private AnimationController _animationController;

            public override void initState()
            {
                base.initState();

                _animationController = new AnimationController(vsync: this, duration: TimeSpan.FromSeconds(3));
                bool isForward = true;


                _animationController.addStatusListener((status) =>
                {
                    if (status == AnimationStatus.forward)
                    {
                        isForward = true;
                    }
                    else if (status == AnimationStatus.completed ||
                             status == AnimationStatus.dismissed)
                    {
                        if (isForward)
                        {
                            _animationController.reverse();
                        }
                        else
                        {
                            _animationController.forward();
                        }
                    }
                    else if (status == AnimationStatus.reverse)
                    {
                        isForward = false;
                    }
                });

                _animationController.forward();
            }

            public override void dispose()
            {
                _animationController.dispose();
                _animationController = null;
                base.dispose();
            }

            public override Widget build(BuildContext context)
            {
                return new SingleChildScrollView(
                    child: new Center(

                        child: new Column(
                            crossAxisAlignment: CrossAxisAlignment.center,

                            children: new List<Widget>()
                            {
                                new AnimatedBuilder(
                                    animation:_animationController,
                                    builder:((buildContext, child) =>
                                    {
                                        return new Padding(
                                            padding: EdgeInsets.symmetric(vertical: 16.0f),
                                            child: new Column(
                                                children: new List<Widget>()
                                                {
                                                    new Wrap(
                                                        spacing: 10.0f,
                                                        runSpacing: 16.0f,
                                                        children: new List<Widget>()
                                                        {
                                                            new GradientCircularProgressIndicator(
                                                                // No gradient
                                                                colors: new List<Color>() {Colors.blue, Colors.blue},
                                                                radius: 50.0f,
                                                                strokeWidth: 3.0f,
                                                                value: _animationController.value
                                                            ),
                                                            new GradientCircularProgressIndicator(
                                                                colors: new List<Color> {Colors.red, Colors.orange},
                                                                radius: 50.0f,
                                                                strokeWidth: 3.0f,
                                                                value: _animationController.value
                                                            ),
                                                            new GradientCircularProgressIndicator(
                                                                colors: new List<Color>
                                                                    {Colors.red, Colors.orange, Colors.red},
                                                                radius: 50.0f,
                                                                strokeWidth: 3.0f,
                                                                value: _animationController.value
                                                            ),
                                                            new GradientCircularProgressIndicator(
                                                                colors: new List<Color> {Colors.teal, Colors.cyan},
                                                                radius: 50.0f,
                                                                strokeWidth: 5.0f,
                                                                strokeCapRound: true,
                                                                value: new CurvedAnimation(
                                                                        parent: _animationController,
                                                                        curve: Curves.decelerate)
                                                                    .value
                                                            ),
                                                            new TurnBox(
                                                                turns: 1.0f / 8.0f,
                                                                child: new GradientCircularProgressIndicator(
                                                                    colors: new List<Color>
                                                                        {Colors.red, Colors.orange, Colors.red},
                                                                    radius: 50.0f,
                                                                    strokeWidth: 5.0f,
                                                                    strokeCapRound: true,
                                                                    backgroundColor: Colors.red[50],
                                                                    totalAngle: (float) (1.5 * Math.PI),
                                                                    value: new CurvedAnimation(
                                                                            parent: _animationController,
                                                                            curve: Curves.ease)
                                                                        .value)
                                                            ),
//                                                           new RotatedBox(
//                                                                quarterTurns: 1,
//                                                                child: GradientCircularProgressIndicator(
//                                                                    colors: [Colors.blue[700], Colors.blue[200]],
//                                                                radius: 50.0,
//                                                                stokeWidth: 3.0,
//                                                                strokeCapRound: true,
//                                                                backgroundColor: Colors.transparent,
//                                                                value: _animationController.value),
//                                                            ),
                                                            new GradientCircularProgressIndicator(
                                                                colors: new List<Color>
                                                                {
                                                                    Colors.red,
                                                                    Colors.amber,
                                                                    Colors.cyan,
                                                                    Colors.green[200],
                                                                    Colors.blue,
                                                                    Colors.red
                                                                },
                                                                radius: 50.0f,
                                                                strokeWidth: 5.0f,
                                                                strokeCapRound: true,
                                                                value: _animationController.value
                                                            )

                                                        }
                                                    )
                                                }

                                            )
                                        );
                                    })
                                    
                                    )
                               
                            }

                        )
                    )
                );
            }

            public Ticker createTicker(TickerCallback onTick)
            {
                return new Ticker(onTick);
            }
        }
    }

    public class GradientCircularProgressIndicator : StatelessWidget
    {
        public GradientCircularProgressIndicator(
            float radius,
            List<Color> colors,
            float value,
            float strokeWidth = 2.0f,
            List<float> stops = null,
            bool strokeCapRound = false,
            Color backgroundColor = null,
            float totalAngle = float.MinValue
        )
        {
            mColors = colors;
            mStrokeWidth = strokeWidth;
            mRadius = radius;
            mStrokeCapRound = strokeCapRound;
            mStops = stops;
            this.mBackgroundColor = backgroundColor ?? new Color(0xFFEEEEEE);
            this.mValue = value;
            this.mTotalAngle = totalAngle == float.MinValue ? (float)(Math.PI * 2) : totalAngle;
        }

        ///粗细
        private float mStrokeWidth;

        /// 圆的半径
        private float mRadius;

        ///两端是否为圆角
        private bool mStrokeCapRound;

        /// 当前进度，取值范围 [0.0-1.0]
        private float mValue;

        /// 进度条背景色
        private Color mBackgroundColor;

        /// 进度条的总弧度，2*PI为整圆，小于2*PI则不是整圆
        private float mTotalAngle;

        /// 渐变色数组
        private List<Color> mColors;

        /// 渐变色的终止点，对应colors属性
        private List<float> mStops;
        
        public override Widget build(BuildContext context)
        {
            float offset = 0;

            if (mStrokeCapRound)
            {
                offset = (float) Math.Asin(mStrokeWidth / (mRadius * 2 - mStrokeWidth));
            }
            
            var _colors = mColors;

            if (_colors == null)
            {
                Color color = Theme
                    .of(context)
                    .accentColor;
                
                _colors = new List<Color>(){color, color};
            }

            return Transform.rotate(
                degree: (float) (-Math.PI / 2.0f - offset),
                child: new CustomPaint(
                    size: Size.fromRadius(mRadius),
                    painter: new GradientCircularProgressPainter(
                        stokeWidth: mStrokeWidth,
                        strokeCapRound: mStrokeCapRound,
                        backgroundColor: mBackgroundColor,
                        value: mValue,
                        total: mTotalAngle,
                        radius: mRadius,
                        colors: _colors
                    )
                ));
        }


        class GradientCircularProgressPainter : AbstractCustomPainter
        {
            public GradientCircularProgressPainter(
                float value,
                float radius,
                List<Color> colors,
                float stokeWidth = 10.0f,
                bool strokeCapRound = false,
                Color backgroundColor = null,
                float total = float.MinValue
            )
            {
                this.value = value;
                this.radius = radius;
                this.colors = colors;
                this.stokeWidth = stokeWidth;
                this.strokeCapRound = strokeCapRound;
                this.backgroundColor = backgroundColor ?? new Color(0xFFEEEEEE);
                this.total = total == float.MinValue ? (float) (Math.PI * 2) : total;
            }

            float stokeWidth;
           bool   strokeCapRound;
           float? value;
           Color backgroundColor;
           List<Color> colors;
           float total;
           float radius;
           List<float> stops;


           public override void paint(Canvas canvas, Size size)
           {
               if (radius != null)
               {
                   size = Size.fromRadius(radius);
               }

               float _offset = stokeWidth / 2.0f;
               float _value = (value ?? 0.0f);
               _value = _value.clamp(0.0f, 1.0f) * total;
               float _start = 0.0f;

               if (strokeCapRound)
               {
                   _start = (float) Math.Asin(stokeWidth / (size.width - stokeWidth));
               }

               Rect rect = new Offset(_offset, _offset) & new Size(
                               size.width - stokeWidth,
                               size.height - stokeWidth
                           );

               var paint = new Paint
               {
                   strokeCap = strokeCapRound ? StrokeCap.round : StrokeCap.butt,
                   style = PaintingStyle.stroke,
                   strokeWidth = stokeWidth
               };

               // 先画背景
               if (backgroundColor != Colors.transparent)
               {
                   paint.color = backgroundColor;
                   canvas.drawArc(
                       rect,
                       _start,
                       total,
                       false,
                       paint
                   );
               }

               // 再画前景，应用渐变
               if (_value > 0)
               {
                   paint.shader = new SweepGradient(
                       startAngle: 0.0f,
                       endAngle: _value,
                       colors: colors,
                       stops: stops
                   ).createShader(rect);

                   canvas.drawArc(
                       rect,
                       _start,
                       _value,
                       false,
                       paint
                   );
               }
           }

           public override bool shouldRepaint(CustomPainter oldDelegate)
            {
                return true;
            }
        }
    }
    
}