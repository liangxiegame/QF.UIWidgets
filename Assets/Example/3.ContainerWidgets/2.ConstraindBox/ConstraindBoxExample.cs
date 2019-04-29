using System.Collections;
using System.Collections.Generic;
using QFramework.UIWidgets;
using Unity.UIWidgets.engine;
using Unity.UIWidgets.material;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.rendering;
using Unity.UIWidgets.widgets;
using UnityEngine;

namespace LearnUIWidgets
{
    public class ConstraindBoxExample : UIWidgetsPanel
    {
        protected override Widget createWidget()
        {
            Widget redBox = new DecoratedBox(
                decoration: new BoxDecoration(color: Colors.red)
            );

            return new MaterialApp(
                home: new Scaffold(
                    body: QF.Column
                        .Child(QF.ConstrainedBox
                            .Constraints(new BoxConstraints(
                                minWidth: float.PositiveInfinity,
                                minHeight: 50.0f
                            ))
                            .Child(
                                QF.Container
                                    .Height(5)
                                    .Child(redBox)
                                    .EndContainer())
                            .EndConstrainedBox())
                        .Child(
                            redBox.SizedBox(width:80.0f,height:80.0f)
                        )
                        .EndColumn()
                )
            );
        }
    }
}