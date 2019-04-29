using QFramework.UIWidgets;
using Unity.UIWidgets.engine;
using Unity.UIWidgets.material;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.ui;
using Unity.UIWidgets.widgets;
using UnityEngine;
using Transform = Unity.UIWidgets.widgets.Transform;

namespace LearnUIWidgets
{
    public class TransformExample : UIWidgetsPanel
    {
        protected override Widget createWidget()
        {
            return new MaterialApp(
                home: new Scaffold(
                    body:
                    QF.Column
                        .Child(QF.Container
                            .Height(100)
                            .EndContainer())
                        .Child(
                            QF.Container
                                .Color(Colors.black)
                                .Child(new Transform(
                                    alignment: Alignment.topRight,
                                    transform: Matrix3.makeSkew(0, 0.3f),
                                    child: QF.Container
                                        .Child(QF.Text
                                            .Data("Apartment for rent!")
                                            .EndText()
                                            .Padding(EdgeInsets.all(8.0f))
                                        )
                                        .Color(Colors.deepOrange)
                                        .EndContainer()
                                ))
                                .EndContainer())
                        .Child(QF.Container
                            .Height(100)
                            .EndContainer())
                        .Child(Transform.translate(
                                offset: new Offset(-20.0f, -5.0f),
                                child: QF.Text
                                    .Data("Hello world")
                                    .EndText())
                            .DecoratedBox(new BoxDecoration(Colors.red)))
                        .Child(QF.Container
                            .Height(100)
                            .EndContainer())
                        .Child(Transform.rotate(
                            degree: Mathf.PI / 2,
                            child: QF.Text
                                .Data("Hello world")
                                .EndText()
                        ).DecoratedBox(new BoxDecoration(
                            Colors.red
                        )))
                        .Child(QF.Container
                            .Height(100)
                            .EndContainer())
                        .Child(Transform.scale(
                            scale: 1.5f,
                            child: QF.Text
                                .Data("Hello world")
                                .EndText()
                        ).DecoratedBox(new BoxDecoration(
                            Colors.red
                        )))
                        .EndColumn()
                )
            );
        }
    }
}