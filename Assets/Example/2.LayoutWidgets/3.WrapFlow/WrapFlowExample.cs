using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QFramework.UIWidgets;
using Unity.UIWidgets.engine;
using Unity.UIWidgets.rendering;
using Unity.UIWidgets.widgets;
using UnityEngine;

namespace LearnUIWidgets
{
    public class WrapFlowExample : UIWidgetsPanel
    {
        protected override Widget createWidget()
        {
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < 100; i++)
            {

                builder.Append("xxx");
            }

            return
                QF.Column
                    .Child(
                        QF.Wrap
                            .Spacing(8.0f)
                            .RunSpacing(4.0f)
                            .AlignmentCenter()
                            .Children(new List<Widget>()
                            {
                                new Text(builder.ToString()),
                                new Text(builder.ToString()),
                                new Text(builder.ToString()),
                                new Text(builder.ToString()),
                                new Text(builder.ToString()),
                                new Text("@@@"),
                                new Text("@@@"),
                                new Text("@@@"),
                                new Text("@@@"),
                                new Text("@@@"),
                                new Text("@@@"),
                                new Text("@@@"),
                                new Text("@@@"),
                                new Text("@@@"),
                                new Text("@@@"),
                                new Text("@@@"),
                                new Text("@@@"),
                                new Text("@@@"),
                                new Text("@@@"),
                                new Text("@@@"),
                                new Text("@@@"),
                            })
                            .EndWrap())
                    .EndColumn();
        }
    }
}