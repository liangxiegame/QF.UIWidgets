using System;
using System.Collections;
using System.Collections.Generic;
using com.unity.uiwidgets.Runtime.rendering;
using RSG;
using Unity.UIWidgets.engine;
using Unity.UIWidgets.material;
using Unity.UIWidgets.ui;
using Unity.UIWidgets.widgets;
using UnityEngine;


namespace LearnUIWidgets
{
    public class GridViewBuilderExample : UIWidgetsPanel
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
                    body: new GridViewBuilderWidget()
                )
            );
        }

        class GridViewBuilderWidget : StatefulWidget
        {
            public override State createState()
            {
                return new GridViewBuilderState();
            }
        }

        class GridViewBuilderState : State<GridViewBuilderWidget>
        {
            List<IconData> mIcons = new List<IconData>(); //保存Icon数据

            public override void initState()
            {
                base.initState();
                RetrieveIcons();
            }

            public override Widget build(BuildContext context)
            {
                return GridView.builder(
                    gridDelegate: new SliverGridDelegateWithFixedCrossAxisCount(
                        crossAxisCount: 3, //每行三列
                        childAspectRatio: 1.0f //显示区域宽高相等
                    ),
                    itemCount: mIcons.Count,
                    itemBuilder: (buildContext, index) =>
                    {
                        //如果显示到最后一个并且Icon总数小于200时继续获取数据
                        if (index == mIcons.Count - 1 && mIcons.Count < 200)
                        {
                            RetrieveIcons();
                        }

                        return new Icon(mIcons[index]);
                    }
                );
            }

            //模拟异步获取数据
            void RetrieveIcons()
            {
                Promise.Delayed(TimeSpan.FromMilliseconds(200)).Then(() =>
                {
                    setState(() =>
                    {
                        mIcons.AddRange(
                            new[]
                            {
                                Icons.ac_unit,
                                Icons.airport_shuttle,
                                Icons.all_inclusive,
                                Icons.beach_access, Icons.cake,
                                Icons.free_breakfast
                            });
                    });
                });
            }
        }
    }
}