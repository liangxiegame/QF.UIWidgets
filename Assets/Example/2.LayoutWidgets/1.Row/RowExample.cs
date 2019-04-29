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

namespace LearnUIWidgets
{
    public class RowExample : UIWidgetsPanel
    {
        protected override Widget createWidget()
        {
            return new MaterialApp(

                home: new Scaffold(body:
                    QF.Column
                        .CrossAxisAlignmentStart()
                        .Child(QF.Row
                            .MainAxisAlignmentCenter()
                            .Child(new Text(" hello world "))
                            .Child(new Text(" I am Jack "))
                            .EndRow())
                        .Child(QF.Row
                            .MainAxisSizeMin()
                            .MainAxisAlignmentCenter()
                            .Child(new Text(" hello world "))
                            .Child(new Text(" I am Jack "))
                            .EndRow())
                        .Child(
                            QF.Container.Color(Colors.red)
                                .Child(QF.Row
                                    .MainAxisAlignmentEnd()
                                    .TextDirectionRTL()
                                    .Child(
                                        new Expanded(child:
                                            QF.Container
                                                .Color(Colors.blue)
                                                .Child(new Text(" ok"))
                                                .EndContainer()
                                            ))
                                    .Child(new Text(" hello world "))
                                    .Child(new Text(" I am Jack "))
                                    .EndRow())
                                .EndContainer())
                        .Child(QF.Row
                            .CrossAxisAlignmentStart()
                            .VerticalDirectionUp()
                            .Child(
                                QF
                                    .Text
                                    .Data(" hello world ")
                                    .FontSize(30)
                                    .EndText())
                            .Child(new Text(" I am Jack "))
                            .EndRow())
                        .EndColumn()));
        }
    }
}