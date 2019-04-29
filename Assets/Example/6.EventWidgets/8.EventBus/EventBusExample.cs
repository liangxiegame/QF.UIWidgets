using System.Collections;
using System.Collections.Generic;
using QFramework.UIWidgets;
using Unity.UIWidgets.engine;
using Unity.UIWidgets.widgets;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

namespace LearnUIWidgets
{
    public class EventBusExample : UIWidgetsPanel
    {
        protected override void OnEnable()
        {
            base.OnEnable();
              }

        protected override Widget createWidget()
        {
            EventBus.S.On("click",(args => Debug.Log(args[0])));

            
            return QF.RaisedButton
                .Child(QF.Text.Data("点击").EndText())
                .OnPressed(() =>
                {
                    EventBus.S.Emit("click","你好");
                })
                .EndRaisedButton();
        }

        delegate void EventCallback(params object[] args);

        class EventBus
        {
            private EventBus(){}
            
            private static EventBus mSingleton = new EventBus();

            public static EventBus S => mSingleton;

            private Dictionary<string, List<EventCallback>> mEMap = new Dictionary<string, List<EventCallback>>();

            public void On(string eventName, EventCallback f)
            {
                List<EventCallback> list = null;
                
                if (!mEMap.TryGetValue(eventName, out list))
                {
                    list = new List<EventCallback>();
                    mEMap.Add(eventName, list);
                }

                list.Add(f);
            }

            public void Off(string eventName, EventCallback f = null)
            {
                if (f == null)
                {
                    mEMap.Remove(eventName);
                }
                else
                {
                    List<EventCallback> list = null;

                    if (mEMap.TryGetValue(eventName, out list))
                    {
                        list.Remove(f);
                    }
                }
            }

            public void Emit(string eventName, params object[] args)
            {
                List<EventCallback> list = null;

                if (mEMap.TryGetValue(eventName, out list))
                {
                    list.ForEach(callback=>callback.Invoke(args));
                }
            }

        }
    }
}