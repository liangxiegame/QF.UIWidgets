using System.Collections;
using System.Collections.Generic;
using QFramework.UIWidgets;
using Unity.UIWidgets.engine;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.widgets;
using UnityEngine;

namespace LearnUIWidgets
{
    public class PaddingExample : UIWidgetsPanel
    {
        protected override Widget createWidget()
        {
            return QF.Column
                //显式指定对齐方式为左对齐，排除对齐干扰
                .CrossAxisAlignmentStart()
                .Child(
                    QF.Text
                        .Data("Hello world")
                        .EndText()
                        .Padding(EdgeInsets.only(left: 8.0f))
                )
                .Child(
                    QF.Text
                        .Data("I am Jack")
                        .EndText()
                        .Padding(EdgeInsets.symmetric(vertical: 8.0f))
                )
                .Child(
                    QF.Text
                        .Data("Your friend")
                        .EndText()
                        .Padding(EdgeInsets.fromLTRB(20.0f, 0.0f, 20.0f, 20.0f))
                )
                .EndColumn()
                .Padding(EdgeInsets.all(16.0f));
        }
    }
}