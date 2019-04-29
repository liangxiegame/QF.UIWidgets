using System.Collections;
using System.Collections.Generic;
using com.unity.uiwidgets.Runtime.rendering;
using Unity.UIWidgets.engine;
using Unity.UIWidgets.material;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.widgets;

namespace LearnUIWidgets
{
    public class CustomScrollViewExample : UIWidgetsPanel
    {
        protected override Widget createWidget()
        {
            return new CustomScrollViewWidget();
        }

        class CustomScrollViewWidget : StatelessWidget
        {
            public override Widget build(BuildContext context)
            {
                return new MaterialApp(
                    home: new Scaffold(
                        body: new CustomScrollView(
                            slivers: new List<Widget>()
                            {
                                new SliverAppBar(
                                    pinned: true,
                                    expandedHeight: 250.0f,
                                    flexibleSpace: new FlexibleSpaceBar(
                                        title: new Text("Demo")
                                    )
                                ),
//                                new SliverPadding(
//                                    padding: EdgeInsets.all(8.0f),
//                                    sliver: new SliverGrid( //Grid
//                                        gridDelegate: new SliverGridDelegateWithFixedCrossAxisCount(
//                                            crossAxisCount: 2, //Grid按两列显示
//                                            mainAxisSpacing: 10.0f,
//                                            crossAxisSpacing: 10.0f,
//                                            childAspectRatio: 4.0f
//                                        ),
//                                        layoutDelegate: new SliverChildBuilderDelegate(
//                                            (buildContext, index) => new Container(
//                                                alignment: Alignment.center,
//                                                color: Colors.cyan[100 * (index % 9)],
//                                                child: new Text("grid item $index")
//                                            ),
//                                            childCount: 20
//                                        )
//                                    )
//                                ),
//List
//                                new SliverFixedExtentList(
//                                    itemExtent: 50.0f,
//                                    del: new SliverChildBuilderDelegate(
//                                        (buildContext, index) => new Container(
//                                            alignment: Alignment.center,
//                                            color: Colors.lightBlue[100 * (index % 9)],
//                                            child: new Text("list item $index")
//                                        ),
//                                        childCount: 50 //50个列表项
//                                    )
//                                )
                            })
                    )
                );
            }
        }
    }
}