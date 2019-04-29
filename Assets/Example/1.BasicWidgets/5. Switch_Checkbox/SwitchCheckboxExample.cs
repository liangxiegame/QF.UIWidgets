using System.Collections;
using System.Collections.Generic;
using QFramework.UIWidgets;
using Unity.UIWidgets.engine;
using Unity.UIWidgets.material;
using Unity.UIWidgets.widgets;
using UnityEngine;

namespace LearnUIWidgets
{
    public class SwitchCheckboxExample : UIWidgetsPanel
    {
        protected override Widget createWidget()
        {
            return new MaterialApp(
                home: new Scaffold(
                    body: new SwitchCheckboxWidget()
                )
            );
        }

        class SwitchCheckboxWidget : StatefulWidget
        {
            public override State createState()
            {
                return new SwitchCheckboxState();
            }
        }

        class SwitchCheckboxState : State<SwitchCheckboxWidget>
        {
            private bool mSwitchValue   = false;
            private bool mCheckboxValue = false;

            public override Widget build(BuildContext context)
            {
                return QF.Column
                    .Child(
                        QF.Switch
                            .Value(mSwitchValue) //当前状态
                            .OnChanged((value) =>
                            {
                                //重新构建页面  
                                setState(() => { mSwitchValue = value.Value; });
                            })
                            .EndSwitch()
                    )
                    .Child(
                        QF.Checkbox
                            .Value(mCheckboxValue)
                            .ActiveColor(Colors.red)
                            .OnChanged((value) => { setState(() => { mCheckboxValue = value.Value; }); })
                            .EndCheckbox()
                    )
                    .EndColumn();
            }
        }
    }
}