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
    public class IconExample : UIWidgetsPanel
    {
        protected override void OnEnable()
        {
            base.OnEnable();

            FontManager.instance.addFont(Resources.Load<Font>("MaterialIcons-Regular"), "Material Icons");

        }

        protected override Widget createWidget()
        {
            var icons = "";
// accessible: &#xE914; or 0xE914 or E914
            icons += "\uE914";
// error: &#xE000; or 0xE000 or E000
            icons += " \uE000";
// fingerprint: &#xE90D; or 0xE90D or E90D
            icons += " \uE90D";

            return QF.Row
                .Child(
                    new Text(icons,
                        style: new TextStyle(
                            fontFamily: "Material Icons",
                            fontSize: 24.0f,
                            color: Colors.green
                        )
                    ))
                .Child(new Icon(Icons.accessible, color: Colors.green))
                .Child(new Icon(Icons.error, color: Colors.green))
                .Child(new Icon(Icons.fingerprint, color: Colors.green))
                .CrossAxisAlignmentCenter()
                .EndRow();
        }
    }
}