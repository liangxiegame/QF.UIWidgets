using System.Collections;
using System.Collections.Generic;
using Unity.UIWidgets.engine;
using Unity.UIWidgets.material;
using Unity.UIWidgets.widgets;
using UnityEngine;

namespace LearnUIWidgets
{
    public class NotificationExample : UIWidgetsPanel
    {
        protected override Widget createWidget()
        {
            return new MaterialApp(
                home: new Scaffold(
                    body: new NotificationListener<ScrollNotification>(
                        onNotification: (notification) =>
                        {
                            //print(notification);
                            switch (notification)
                            {
                                case ScrollStartNotification _:
                                    print("开始滚动");
                                    break;
                                case ScrollUpdateNotification _:
                                    print("正在滚动");
                                    break;
                                case ScrollEndNotification _:
                                    print("滚动停止");
                                    break;
                                case OverscrollNotification _:
                                    print("滚动到边界");
                                    break;
                            }

                            return true;
                        },
                        child: ListView.builder(
                            itemCount: 100,
                            itemBuilder: (context, index) => { return new ListTile(title: new Text("$index")); }
                        ))));

        }
    }
}