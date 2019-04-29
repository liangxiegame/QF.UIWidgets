using System;
using System.Collections.Generic;
using QFramework.UIWidgets;
using Unity.UIWidgets.material;
using Unity.UIWidgets.ui;
using Unity.UIWidgets.widgets;

namespace TodoListUIWidgets
{
    public class TodoDetailScreen : StatefulWidget
    {
        public TodoDetailScreen(Todo data)
        {
            Data = data;
        }

        public Todo Data { get; }
        
        public override State createState()
        {
            return new TodoDetailScreenState(Data);
        }
    }

    public class TodoDetailScreenState : State<TodoDetailScreen>
    {
        public Todo Data { get; }

        private string mInputContent = string.Empty;


        public override void initState()
        {
            mInputContent = Data.Content;
        }

        public TodoDetailScreenState(Todo data)
        {
            Data = data;
        }

        private List<Widget> BtnSave
        {
            get
            {
//                if (Data.Content == mInputContent)
//                {
//                    return new List<Widget>();
//                }

                return new List<Widget>()
                {
                    new IconButton(icon: new Icon(Icons.save),
                        onPressed: () => { Navigator.pop(context, mInputContent); })
                };
            }
        }
        
        public override Widget build(BuildContext context)
        {
            
            return new Scaffold(
                appBar: new AppBar(actions:BtnSave),
                body:
                QF.Container
                    .MarginAll(30)
                    .BorderColor(Color.black)
                    .Child(
                        QF.EditableText
                            .FontSize(30)
                            .MaxLine(100)
                            .InitData(mInputContent)
                            .OnValueChanged(newInputContent =>
                            {
//                                this.setState(() =>
//                                {
                                    mInputContent = newInputContent;
//                                });
                            })
                            .EndEditableText())
                    .EndContainer());
        }
    }
}