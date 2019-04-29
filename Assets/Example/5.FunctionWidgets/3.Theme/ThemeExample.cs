using System.Collections;
using System.Collections.Generic;
using Unity.UIWidgets.engine;
using Unity.UIWidgets.material;
using Unity.UIWidgets.rendering;
using Unity.UIWidgets.ui;
using Unity.UIWidgets.widgets;
using UnityEngine;

namespace LearnUIWidgets
{
    public class ThemeExample : UIWidgetsPanel
    {
        protected override void OnEnable()
        {
            base.OnEnable();
            FontManager.instance.addFont(Resources.Load<Font>("MaterialIcons-Regular"), "Material Icons");
        }

        protected override Widget createWidget()
        {
            return new MaterialApp(home:new ThemeTestRoute());
            
        }

        class ThemeTestRoute : StatefulWidget
        {
            public override State createState()
            {
                return new ThemeTestState();
            }
        }

        class ThemeTestState : State<ThemeTestRoute>
        {
            MaterialColor mThemeColor = Colors.teal; //当前路由主题色

            public override Widget build(BuildContext context)
            {
                ThemeData themeData = Theme.of(context);

                return new Theme(
                    data: new ThemeData(
                        primarySwatch: mThemeColor,
                        iconTheme: new IconThemeData(color: mThemeColor)
                    ),

                    child: new Scaffold(
                        appBar: new AppBar(title: new Text("主题测试")),
                        body: new Column(
                            mainAxisAlignment: MainAxisAlignment.center,
                            children: new List<Widget>()
                            {

                                //第一行Icon使用主题中的iconTheme
                                new Row(
                                    mainAxisAlignment: MainAxisAlignment.center,
                                    children: new List<Widget>
                                    {
                                        new Icon(Icons.favorite),
                                        new Icon(Icons.airport_shuttle),
                                        new Text("  颜色跟随主题")
                                    }
                                ),
                                //为第二行Icon自定义颜色（固定为黑色)
                                new Theme(
                                    data: themeData.copyWith(
                                        iconTheme: themeData.iconTheme.copyWith(
                                            color: Colors.black
                                        )
                                    ),
                                    child: new Row(
                                        mainAxisAlignment: MainAxisAlignment.center,
                                        children: new List<Widget>
                                        {
                                            new Icon(Icons.favorite),
                                            new Icon(Icons.airport_shuttle),
                                            new Text("  颜色固定黑色")
                                        }
                                    )
                                )
                            }
                        )
                        ,
                        floatingActionButton: new FloatingActionButton(
                            onPressed: () => //切换主题
                                setState(() =>
                                    mThemeColor =
                                        mThemeColor == Colors.teal ? Colors.blue : Colors.teal
                                ),
                            child: new Icon(Icons.palette)
                        )
                    )


                );
            }
        }
    }
}