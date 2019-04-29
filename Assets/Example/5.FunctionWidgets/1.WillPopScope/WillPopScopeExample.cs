using System;
using RSG;
using Unity.UIWidgets.engine;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.widgets;
using UnityEngine;

namespace LearnUIWidgets
{
    public class WillPopScopeExample : UIWidgetsPanel
    {
        protected override Widget createWidget()
        {
            return new WillPopScopeRoute();
        }

        class WillPopScopeRoute : StatefulWidget
        {
            public override State createState()
            {
                return new WillPopScopeState();
            }
        }

        class WillPopScopeState : State<WillPopScopeRoute>
        {
            DateTime? mLastPressedAt; //上次点击时间


            public override Widget build(BuildContext context)
            {
                return new WillPopScope(
                    onWillPop: () =>
                    {
                        Debug.Log("clicked");
                        if (mLastPressedAt == null ||
                            DateTime.Now - mLastPressedAt.Value > TimeSpan.FromSeconds(1))
                        {
                            //两次点击间隔超过1秒则重新计时
                            mLastPressedAt = DateTime.Now;
                            return Promise<bool>.Resolved(false);
                        }

                        return Promise<bool>.Resolved(true);
                    },
                    child: new Container(
                        alignment: Alignment.center,
                        child: new Text("1秒内连续按两次返回键退出")
                    )
                );
            }
        }
    }
}