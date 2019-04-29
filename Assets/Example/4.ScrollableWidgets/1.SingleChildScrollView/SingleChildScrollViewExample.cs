using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using QFramework.UIWidgets;
using Unity.UIWidgets.engine;
using Unity.UIWidgets.material;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.widgets;
using UnityEngine;

namespace LearnUIWidgets
{
    public class SingleChildScrollViewExample : UIWidgetsPanel
    {
        protected override Widget createWidget()
        {
            var str = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            return new MaterialApp(
                home:new Scaffold(
                    body:new Scrollbar(
                        child: new SingleChildScrollView(
                            padding: EdgeInsets.all(16.0f),
                            child: new Center(
                                child: QF.Column
                                    .Children(str.Select(c => QF.Text
                                        .Data(c.ToString())
                                        .TextScaleFactor(2)
                                        .EndText() as Widget).ToList())
                                    .EndColumn()
                            )
                        )
                    )
                    )
                );
        }
    }
}
