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

namespace LearnUIWidgets
{
    public class ButtonExample : UIWidgetsPanel
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
                    body: QF.ListView
                        .Child(QF.RaisedButton
                            .Child(QF.Text
                                .Data("Normal")
                                .EndText())
                            .OnPressed(() => { Debug.Log("on pressed"); })
                            .EndRaisedButton())
                        .Child(
                            QF.FlatButton
                                .Child(QF.Text
                                    .Data("Flat Normal")
                                    .EndText())
                                .OnPressed(() => { Debug.Log("on flat btn pressed"); })
                                .EndFlatButton()
                        )
                        .Child(
                            QF.OutlineButton
                                .Child(QF.Text
                                    .Data("Normal")
                                    .EndText())
                                .OnPressed(() => { Debug.Log("on outline btn pressed"); })
                                .EndOutlineButton()
                        )
                        .Child(
                            QF.IconButton
                                .Icon(new Icon(Icons.save))
                                .OnPressed(() => { Debug.Log("on icon btn pressed"); })
                                .EndIconButton()
                        )
                        .Child(
                            QF.RaisedButton
                                .Color(Colors.blue)
                                .HighlightColor(Colors.blue[700])
                                .ColorBrightness(Brightness.dark)
                                .SplashColor(Colors.grey)
                                .Child(new Text("Submit"))
                                .Shape(new RoundedRectangleBorder(borderRadius:BorderRadius.circular(20.0f)))
                                .OnPressed(() =>
                                {
                                    Debug.Log("on Submit buttton pressed");
                                })
                                .EndRaisedButton()
                            )
                        .EndListView()));
        }
    }
}