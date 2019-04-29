using System.Collections;
using System.Collections.Generic;
using QFramework.UIWidgets;
using Unity.UIWidgets.engine;
using Unity.UIWidgets.material;
using Unity.UIWidgets.widgets;
using UnityEngine;

namespace LearnUIWidgets
{
    public class ListViewTitleExample : UIWidgetsPanel
    {
        protected override Widget createWidget()
        {
            return new MaterialApp(
                home: new Scaffold(
                    body: new ListViewTitleWidget()
                )
            );
        }

        class ListViewTitleWidget : StatefulWidget
        {
            public override State createState()
            {
                return new ListViewTitleState();
            }
        }

        class ListViewTitleState : State<ListViewTitleWidget>
        {
            public override Widget build(BuildContext buildContext)
            {
                return QF.Column
                    .Child(new ListTile(title: new Text("商品列表")))
                    .Child(ListView.builder(
                        itemBuilder: ((context, index) => new ListTile(title: new Text("$index")))
                    ).Expanded())
                    .EndColumn();
            }
        }
    }
}