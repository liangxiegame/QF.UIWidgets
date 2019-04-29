using System.Collections;
using System.Collections.Generic;
using QFramework.UIWidgets;
using Unity.UIWidgets.engine;
using Unity.UIWidgets.material;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.ui;
using Unity.UIWidgets.widgets;
using UnityEngine;
using Image = Unity.UIWidgets.widgets.Image;

namespace LearnUIWidgets
{
    public class ImageExample : UIWidgetsPanel
    {
        protected override Widget createWidget()
        {
            return QF.Column

                .Child(
                    Image.asset(
                        name: "Image",
                        width: 300))
                .Child(
                    Image.network(
                        "https://avatars2.githubusercontent.com/u/20411648?s=460&v=4",
                        width: 300.0f
                    ))
                .Child(
                    new Image(
                        image:new NetworkImage("https://avatars2.githubusercontent.com/u/20411648?s=460&v=4"),
                        width: 300,
                        color: Colors.blue,
                        colorBlendMode: BlendMode.difference))
                .Child(
                    new Image(
                        image: new AssetImage("Image"),
                        width: 100.0f,
                        height: 200.0f,
                        repeat: ImageRepeat.repeatY
                    )
                )
                .EndColumn();
        }
    }
}