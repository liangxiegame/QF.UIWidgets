using System;
using System.Collections;
using System.Collections.Generic;
using Unity.UIWidgets.engine;
using Unity.UIWidgets.material;
using Unity.UIWidgets.rendering;
using Unity.UIWidgets.widgets;
using UnityEngine;

namespace LearnUIWidgets
{
    public class CustomNotificationExample : UIWidgetsPanel
    {
        protected override Widget createWidget()
        {
            return new CustomNotificationTestRoute();
        }

        class CustomNotificationTestRoute : StatefulWidget
        {
            public override State createState()
            {
                return new CustomNotificationTestState();
            }
        }

        class MyNotification : Notification
        {
            public MyNotification(string msg)
            {
                this.Msg = msg;
            }

            public string Msg;
        }

        class CustomNotificationTestState : State<CustomNotificationTestRoute>
        {

            string mMsg = "";


            public override Widget build(BuildContext context)
            {
                return new NotificationListener<MyNotification>(
                    onNotification: (notification) =>
                    {
                        setState(() => { mMsg += notification.Msg + "  "; });
                        return true;
                    }
                    , child: new Center(
                        child: new Column(
                            mainAxisSize: MainAxisSize.min,
                            children: new List<Widget>
                            {
//          RaisedButton(
//           onPressed: () => MyNotification("Hi").dispatch(context),
//           child: Text("Send Notification"),
//          ),  
                                new Builder(
                                    builder: (buildContext) =>
                                    {
                                        return new RaisedButton(
                                            //按钮点击时分发通知  
                                            onPressed: () => new MyNotification("Hi").dispatch(buildContext),
                                            child: new Text("Send Notification")
                                        );
                                    }
                                ),
                                new Text(mMsg)
                            }
                        )
                    )
                );
            }
        }
    }
}