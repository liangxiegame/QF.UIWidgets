using System.Collections.Generic;
using QFramework.UIWidgets;
using Unity.UIWidgets.engine;
using Unity.UIWidgets.gestures;
using Unity.UIWidgets.material;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.rendering;
using Unity.UIWidgets.ui;
using Unity.UIWidgets.widgets;
using UnityEngine;

namespace LearnUIWidgets
{
    public class TextExample : UIWidgetsPanel
    {
        protected override void OnEnable()
        {
            base.OnEnable();
            FontManager.instance.addFont(Resources.Load<Font>("_SourceHanSansCN-Regular"),"fangzheng");
        }

        protected override Widget createWidget()
        {
            return new ListView(children: new List<Widget>()
            {
                QF.Text
                    .Data("Hello world")
                    .FontSize(30)
                    .FontBold()
                    .TextAlignCenter()
                    .EndText(),
                QF.Text
                    .Data(
                        "Hello world! I'm Jack.Hello world! I'm Jack. Hello world! I'm Jack. Hello world! I'm Jack. Hello world! I'm Jack. ")
                    .FontBold()
                    .FontSize(30)
                    .MaxLines(1)
                    .OverflowEllipsis()
                    .EndText(),
                QF.Text
                    .Data("Hello world")
                    .FontBold()
                    .FontSize(30)
                    .EndText(),
                QF.Text
                    .Data("Hello world")
                    .FontColor(Colors.blue)
                    .FontSize(18.0f)
                    .Height(1.2f)
                    .FontFamily("Courier")
                    .BackgroundColor(Colors.yellow)
                    .Underline()
                    .DecorationStyleSolid()
                    .EndText(),
                Text.rich(
                    QF.TextSpan
                        .Child(
                            QF.TextSpan
                                .Text("Home：")
                                .EndTextSpan()
                        )
                        .Child(
                            QF.TextSpan
                                .Text("https://flutterchina.club")
                                .FontColor(Colors.blue)
                                .OnTap(() =>
                                {
                                    Application.OpenURL("https://flutterchina.club");
                                    Debug.Log("on tap");
                                })
                                .EndTextSpan()
                        )
                        .EndTextSpan()
                ),
                QF.Column
                    .CrossAxisAlignmentStart()
                    .Child(QF.Text.Data("hello world").EndText())
                    .Child(QF.Text.Data("I am jack").EndText())
                    .Child(QF.Text
                        .Data("I am jack")
                        .Inherit(false)
                        .FontColor(Colors.grey)
                        .EndText())
                    .EndColumn()
                    // 包一层 TextStyle
                    .DefaultTextStyle()
                    .TextStyle(QF.TextStyle
                        .FontColor(Colors.red)
                        .FontSize(20.0f)
                        .EndTextStyle())
                    .TextAlignLeft()
                    .EndDefaultTextStyle(),
                QF.Text
                    .Data("对这个 Text Widget 使用字体")
                    .FontFamily("fangzheng")
                    .EndText()
            });
        }
    }
}