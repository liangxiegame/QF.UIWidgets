using System;
using System.Collections;
using System.Collections.Generic;
using Unity.UIWidgets.engine;
using Unity.UIWidgets.material;
using Unity.UIWidgets.ui;
using Unity.UIWidgets.widgets;
using Canvas = Unity.UIWidgets.ui.Canvas;

namespace LearnUIWidgets
{
    public class CustomPaintExample : UIWidgetsPanel
    {
        protected override Widget createWidget()
        {
            return new MaterialApp(
                home: new Scaffold(
                    body: new CustomPaintRoute()
                )
            );
        }

        class CustomPaintRoute : StatelessWidget
        {
            public override Widget build(BuildContext context)
            {
                return new Center(
                    child: new CustomPaint(
                        size: new Size(300, 300),
                        painter: new MyPainter()
                    )
                );
            }
        }

        class MyPainter : AbstractCustomPainter
        {
            public override void paint(Canvas canvas, Size size)
            {
                var eWidth = size.width / 15;
                var eHeight = size.height / 15;

                var paint = new Paint
                {
                    style = PaintingStyle.fill,
                    color = new Color(0x77cdb175)
                };

                canvas.drawRect(Offset.zero & size, paint);

                //画棋盘网格
                paint.style = PaintingStyle.stroke; //线
                paint.color = Colors.black87;
                paint.strokeWidth = 1.0f;

                for (var i = 0; i <= 15; ++i)
                {
                    var dy = eHeight * i;
                    canvas.drawLine(new Offset(0, dy), new Offset(size.width, dy), paint);
                }

                for (int i = 0; i <= 15; ++i)
                {
                    var dx = eWidth * i;
                    canvas.drawLine(new Offset(dx, 0), new Offset(dx, size.height), paint);
                }

                paint.style = PaintingStyle.fill;
                paint.color = Colors.black;

                canvas.drawCircle(
                    new Offset(size.width / 2 - eWidth / 2, size.height / 2 - eHeight / 2),
                    Math.Min(eWidth / 2, eHeight / 2) - 2,
                    paint
                );

                //画一个白子
                paint.color = Colors.white;
                canvas.drawCircle(
                    new Offset(size.width / 2 + eWidth / 2, size.height / 2 - eHeight / 2),
                    Math.Min(eWidth / 2, eHeight / 2) - 2,
                    paint
                );

            }

            public override bool shouldRepaint(CustomPainter oldDelegate)
            {
                return true;
            }


        }
    }
}
