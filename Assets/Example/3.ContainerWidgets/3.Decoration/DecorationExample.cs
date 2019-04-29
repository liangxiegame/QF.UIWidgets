using System.Collections.Generic;
using QFramework.UIWidgets;
using Unity.UIWidgets.engine;
using Unity.UIWidgets.material;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.ui;
using Unity.UIWidgets.widgets;
using Color = Unity.UIWidgets.ui.Color;

namespace LearnUIWidgets
{
    public class DecorationExample : UIWidgetsPanel
    {
        protected override Widget createWidget()
        {
            return new MaterialApp(
                home: new Scaffold(
                    body: QF.Text
                        .Data("Login")
                        .FontColor(Colors.white)
                        .EndText()
                        .Padding(EdgeInsets.symmetric(horizontal: 80.0f,
                            vertical: 18.0f))
                        .DecoratedBox(new BoxDecoration(
                            gradient: new LinearGradient(colors: new List<Color>()
                            {
                                Colors.red,
                                Colors.orange[700]
                            }),
                            borderRadius: BorderRadius.circular(3.0f),
                            boxShadow: new List<BoxShadow>()
                            {
                                new BoxShadow(
                                    color: Colors.black54,
                                    offset: new Offset(2.0f, 2.0f),
                                    blurRadius: 4.0f
                                )
                            }
                        ))
                )
            );
        }
    }
}