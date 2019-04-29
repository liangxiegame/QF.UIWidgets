using System.Collections;
using System.Collections.Generic;
using QFramework.UIWidgets;
using Unity.UIWidgets.engine;
using Unity.UIWidgets.material;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.widgets;
using UnityEngine;
using Transform = Unity.UIWidgets.widgets.Transform;

namespace LearnUIWidgets
{
    public class RotatedBoxExample : UIWidgetsPanel
    {
        protected override Widget createWidget()
        {
            return new MaterialApp(
                home: new Scaffold(
                    body: QF.Column
                        .Child(QF.Container
                            .Height(100)
                            .EndContainer())
                        .Child(QF.Row
                            .MainAxisAlignmentCenter()
                            .Child(Transform.scale(
                                scale: 1.5f,
                                child: QF.Text
                                    .Data("Hello world")
                                    .EndText()
                            ).DecoratedBox(new BoxDecoration(
                                Colors.red
                            )))
                            .Child(QF.Text
                                .Data("你好")
                                .FontSize(18.0f)
                                .FontColor(Colors.green)
                                .EndText())
                            .EndRow())
                        .EndColumn()
                )
            );
        }
    }
}