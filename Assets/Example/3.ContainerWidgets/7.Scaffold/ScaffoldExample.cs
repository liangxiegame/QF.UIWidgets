using System.Collections;
using System.Collections.Generic;
using System.Linq;
using QFramework.UIWidgets;
using Unity.UIWidgets.engine;
using Unity.UIWidgets.material;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.scheduler;
using Unity.UIWidgets.ui;
using Unity.UIWidgets.widgets;
using UnityEngine;

namespace LearnUIWidgets
{
    public class ScaffoldExample : UIWidgetsPanel
    {
        protected override void OnEnable()
        {
            base.OnEnable();
            
            FontManager.instance.addFont(Resources.Load<Font>("MaterialIcons-Regular"), "Material Icons");
        }

        protected override Widget createWidget()
        {
            return new MaterialApp(
                home: new ScaffoldRoute()
            );
        }


        class ScaffoldRoute : StatefulWidget
        {
            public override State createState()
            {
                return new ScaffoldRouteState();
            }
        }

        class ScaffoldRouteState : State<ScaffoldRoute> ,TickerProvider
        {
            private int mSelectedIndex = 1;

            TabController mTabController;
            
            List<string> mTabs = new List<string>()
            {
                "新闻",
                "历史",
                "图片"
            };

            public override void initState()
            {
                base.initState();

                mTabController = new TabController(
                    length: mTabs.Count,
                    vsync: this
                );
            }

            public override Widget build(BuildContext context)
            {
                return new Scaffold(
                    appBar: new AppBar(
                        title: new Text("App Name"),
                        actions: new List<Widget>()
                        {
                            new IconButton(icon: new Icon(Icons.share), onPressed: () => { })
                        },
                        bottom:new TabBar(
                            controller:mTabController,
                            tabs:mTabs.Select(tab=>new Tab(text:tab) as Widget).ToList()
                            )
                    ),
                    floatingActionButton:new IconButton(icon:new Icon(Icons.add_circle)),
                    floatingActionButtonLocation:FloatingActionButtonLocation.centerDocked,
                    drawer:new MyDrawer(),
                    bottomNavigationBar:new BottomAppBar(
                        color:Colors.white,
                        shape: new CircularNotchedRectangle(), // 底部导航栏打一个圆形的洞
                        child:QF.Row
                            .MainAxisAlignmentSpaceAround()
                            .Child(new IconButton(icon: new Icon(Icons.home)))
                            .Child(new SizedBox())
                            .Child(new IconButton(icon: new Icon(Icons.business)))
                            .EndRow()
                        ),
                    body:new TabBarView(
                        controller:mTabController,
                        children:mTabs.Select(tab=>QF.Container
                            .AlignmentCenter()
                            .Child(QF.Text
                                .Data(tab)
                                .TextScaleFactor(5)
                                .EndText())
                            .EndContainer() as Widget).ToList()
                        )
                );
            }

            public Ticker createTicker(TickerCallback onTick)
            {
                return new Ticker(onTick);
            }
        }

        class MyDrawer : StatelessWidget
        {
            public override Widget build(BuildContext context)
            {
                return new Drawer(
                    child:QF.Column
                        .Child(new IconButton(
                            icon:new Icon(Icons.save)
                            ))
                        .Child(new IconButton(
                            icon:new Icon(Icons.save)
                        ))
                        .EndColumn()
                    );
            }
        }
    }
}