using System.Collections;
using System.Collections.Generic;
using Unity.UIWidgets.engine;
using Unity.UIWidgets.material;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.widgets;
using UnityEngine;

namespace LearnUIWidgets
{
    public class FormExample : UIWidgetsPanel
    {
        protected override Widget createWidget()
        {
            return new FormWidget();
        }


        class FormWidget : StatefulWidget
        {
            public override State createState()
            {
                return new FormWidgetState();
            }
        }

        class FormWidgetState : State<FormWidget>
        {
            TextEditingController mUnameController = new TextEditingController();
            TextEditingController mPwdController   = new TextEditingController();
//            GlobalKey             mFormKey         = new GlobalKey<FormState>();

            public override Widget build(BuildContext context)
            {
                return new Padding(
                    padding: EdgeInsets.symmetric(vertical: 16.0f, horizontal: 24.0f),
                    child: new Form(
//                        key: mFormKey, //设置globalKey，用于后面获取FormState
                        autovalidate: true, //开启自动校验
                        child: new Column(
                            children: new List<Widget>()
                            {
//                                    FormField<>
//              new FormField<TextField>(
//                  autofocus: true,
//                  controller: _unameController,
//                  decoration: InputDecoration(
//                      labelText: "用户名",
//                      hintText: "用户名或邮箱",
//                      icon: Icon(Icons.person)
//                  ),
//                  // 校验用户名
//                  validator: (v)) {
//                    return v
//                        .trim()
//                        .length > 0 ? null : "用户名不能为空";
//                  }
//
//              ),
//              TextFormField(
//                  controller: _pwdController,
//                  decoration: InputDecoration(
//                      labelText: "密码",
//                      hintText: "您的登录密码",
//                      icon: Icon(Icons.lock)
//                  ),
//                  obscureText: true,
//                  //校验密码
//                  validator: (v) {
//                    return v
//                        .trim()
//                        .length > 5 ? null : "密码不能少于6位";
//                  }
//              ),
                                // 登录按钮
//              new Padding(
//                padding: const EdgeInsets.only(top: 28.0),
//                child: Row(
//                  children: <Widget>[
//                    Expanded(
//                      child: RaisedButton(
//                        padding: EdgeInsets.all(15.0),
//                        child: Text("登录"),
//                        color: Theme
//                            .of(context)
//                            .primaryColor,
//                        textColor: Colors.white,
//                        onPressed: () {
//                          //在这里不能通过此方式获取FormState，context不对
//                          //print(Form.of(context));
//
//                          // 通过_formKey.currentState 获取FormState后，
//                          // 调用validate()方法校验用户名密码是否合法，校验
//                          // 通过后再提交数据。 
//                          if((_formKey.currentState as FormState).validate()){
//                            //验证通过提交数据
//                          }
//                        },
//                      ),
//                    ),
                            }
                        )));
            }
        }
    }
}