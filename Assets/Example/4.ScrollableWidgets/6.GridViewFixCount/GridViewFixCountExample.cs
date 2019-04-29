using System.Collections;
using System.Collections.Generic;
using com.unity.uiwidgets.Runtime.rendering;
using Unity.UIWidgets.engine;
using Unity.UIWidgets.material;
using Unity.UIWidgets.ui;
using Unity.UIWidgets.widgets;
using UnityEngine;

namespace LearnUIWidgets
{
    public class GridViewFixCountExample : UIWidgetsPanel
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
                    body: GridView.count(
                        crossAxisCount: 3,
                        childAspectRatio: 1.0f,
                        children: new List<Widget>()
                        {
                            new Icon(Icons.ac_unit),
                            new Icon(Icons.airport_shuttle),
                            new Icon(Icons.all_inclusive),
                            new Icon(Icons.beach_access),
                            new Icon(Icons.cake),
                            new Icon(Icons.free_breakfast),
                            new Icon(Icons.free_breakfast)
                        }
                    )
                )
            );
        }
    }
}