using System;
using System.Collections.Generic;
using QFramework.UIWidgets;
using Unity.UIWidgets.material;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.rendering;
using Unity.UIWidgets.ui;
using Unity.UIWidgets.widgets;

namespace TodoListUIWidgets
{
    public class TodoInputView : StatelessWidget
    {
        private Action<string> mOnAdd;

        private string mInputContent = string.Empty;

        public TodoInputView(Action<string> onAdd)
        {
            mOnAdd = onAdd;
        }

        void AddTodo()
        {
            if (!string.IsNullOrWhiteSpace(mInputContent))
            {
                mOnAdd(mInputContent);
            }
        }

        public override Widget build(BuildContext context)
        {
            return

                QF.Container
                    .Child(
                        new Row(children: new List<Widget>()
                            {
                                QF.Container
                                    .Width(530)
                                    .Height(50)
                                    .BorderColor(Color.black)
                                    .MarginLeftRight(10, 0)
                                    .Child(
                                        QF.EditableText
                                            .FontSize(30)
                                            .OnValueChanged((inputValue) => { mInputContent = inputValue; })
                                            .OnSubmit(inputValue => AddTodo())
                                            .EndEditableText()
                                    ).EndContainer(),

                                    new IconButton(
                                            icon:new Icon(Icons.add_box,color:new Color(0xff66bb6a)),
                                            iconSize:65,
                                            padding:EdgeInsets.only(right:20),
                                            onPressed:AddTodo)
                            },
                            mainAxisAlignment: MainAxisAlignment.spaceBetween
                        ))
                    .EndContainer();
        }
    }
}