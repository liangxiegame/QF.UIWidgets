using System.Collections;
using System.Collections.Generic;
using QFramework.UIWidgets;
using Unity.UIWidgets.engine;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.widgets;
using UnityEngine;

namespace LearnUIWidgets
{
    public class ListViewExample : UIWidgetsPanel
    {
        protected override Widget createWidget()
        {
            return QF.ListView
                .ShrinkWrap()
                .Padding(EdgeInsets.all(20.0f))
                .Child(new Text("I\'m dedicating every day to you"))
                .Child(new Text("Domestic life was never quite my style"))
                .Child(new Text("When you smile, you knock me out, I fall apart"))
                .Child(new Text("And I thought I was so smart"))
                .EndListView();
        }
    }
}