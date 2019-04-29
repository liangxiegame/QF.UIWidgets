using System.Collections;
using System.Collections.Generic;
using QFramework.UIWidgets;
using Unity.UIWidgets.engine;
using Unity.UIWidgets.material;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.service;
using Unity.UIWidgets.ui;
using Unity.UIWidgets.widgets;
using UnityEngine;
using Color = Unity.UIWidgets.ui.Color;

namespace LearnUIWidgets
{
    public class TextFieldExample : UIWidgetsPanel
    {
        protected override void OnEnable()
        {
            base.OnEnable();
            
            FontManager.instance.addFont(Resources.Load<Font>("MaterialIcons-Regular"), "Material Icons");
        }

        protected override Widget createWidget()
        {
            return new MaterialApp(
                home: new Scaffold(
                    body: new FormWidget()
                )
            );
        }

        class FormWidget : StatefulWidget
        {
            public override State createState()
            {
                return new FormState();
            }
        }

        class FormState : State<FormWidget>
        {
            public override Widget build(BuildContext context)
            {
                var controller = new TextEditingController("12345");

                controller.addListener(() => { Debug.LogFormat("@@{0}", controller.text); });

//            controller.selection = new TextSelection(
//                baseOffset:2,
//                extentOffset:4
//                );

                FocusNode focusNode1 = new FocusNode();
                FocusNode focusNode2 = new FocusNode();

                FocusScopeNode focusScopeNode = null;
                
                focusNode1.addListener(() =>
                {
                    Debug.Log(focusNode1.hasFocus);
                });

                return new Theme(
                    data: Theme.of(context).copyWith(
                        hintColor: Colors.black, //定义下划线颜色
                        inputDecorationTheme: new InputDecorationTheme(
                            labelStyle: new TextStyle(color: Colors.red), //定义label字体样式
                            hintStyle: new TextStyle(color: Colors.blue, fontSize: 14.0f) //定义提示文本样式
                        )
                    ),
                    child: QF.Column
                        .Child(
                            QF.TextField
                                .LabelText("用户名")
                                .HintText("用户名或邮箱")
                                .Controller(controller)
                                .FocusNode(focusNode1)
                                .PrefixIcon(new Icon(icon: Icons.person))
                                .OnValueChanged((value) => Debug.Log(value))
                                .EndTextField()
                        )
                        .Child(
                            QF.TextField
                                .LabelText("密码")
                                .HintText("您的登录密码")
                                .PrefixIcon(new Icon(icon: Icons.lock_icon))
                                .ObscureText()
                                .FocusNode(focusNode2)
                                .OnValueChanged((value) => Debug.Log(value))
                                .OnSubmit((_) => Debug.Log("submit"))
                                .EndTextField()
                        )
                        .Child(
                            QF.RaisedButton
                                .Child(QF.Text.Data("点击").EndText())
                                .OnPressed(() =>
                                {
                                    //将焦点从第一个TextField移到第二个TextField
                                    // 这是一种写法 FocusScope.of(context).requestFocus(focusNode2);
                                    // 这是第二种写法
                                    if (null == focusScopeNode)
                                    {
                                        focusScopeNode = FocusScope.of(context);
                                    }

                                    focusScopeNode.requestFocus(focusNode2);
                                })
                                .EndRaisedButton()
                        )
                        .Child(
                            QF.RaisedButton
                                .Child(QF.Text.Data("隐藏键盘").EndText())
                                .OnPressed(() =>
                                {
                                    // 当所有编辑框都失去焦点时键盘就会收起  
                                    focusNode1.unfocus();
                                    focusNode2.unfocus();
                                })
                                .EndRaisedButton()
                        )
                        .EndColumn());
            }
        }
    }
}