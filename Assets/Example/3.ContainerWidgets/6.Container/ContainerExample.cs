using System.Collections;
using System.Collections.Generic;
using QFramework.UIWidgets;
using Unity.UIWidgets.engine;
using Unity.UIWidgets.material;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.rendering;
using Unity.UIWidgets.ui;
using Unity.UIWidgets.widgets;
using UnityEngine;
using Color = Unity.UIWidgets.ui.Color;

namespace LearnUIWidgets
{
    public class ContainerExample : UIWidgetsPanel
    {
        protected override Widget createWidget()
        {
            return new MaterialApp(
                home: new Scaffold(
                    body: QF.Container
                        .MarginTop(5.0f)
                        .MarginLeftRight(left: 120.0f)
                        .Constraints(BoxConstraints.tightFor(width: 200, height: 150))
                        .Decoration(new BoxDecoration(
                            gradient: new RadialGradient(
                                colors: new List<Color>() {Colors.red, Colors.orange},
                                center: Alignment.topLeft,
                                radius: 98
                            ),
                            boxShadow: new List<BoxShadow>()
                            {
                                new BoxShadow(
                                    color: Colors.black54,
                                    offset: new Offset(2.0f, 2.0f),
                                    blurRadius: 4.0f
                                )
                            }))
                        .Transform(Matrix3.makeRotate(0.2f))
                        .AlignmentCenter()
                        .Child(QF.Text
                            .Data("5.20")
                            .FontColor(Colors.white)
                            .FontSize(40.0f)
                            .EndText())
                        .EndContainer()

                )

            );
        }
    }
}