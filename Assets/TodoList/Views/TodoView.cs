using System;
using QFramework.UIWidgets;
using Unity.UIWidgets.material;
using Unity.UIWidgets.widgets;
using UnityEditor;
using UnityEngine;
using Color = Unity.UIWidgets.ui.Color;

namespace TodoListUIWidgets
{
    public class TodoView : StatelessWidget
    {
        private readonly Todo mData;

        private readonly Action mOnFinish;
        private readonly Action mOnDelete;
        private readonly Action<string> mOnEdit;

        public TodoView(Todo data,Action onFinish, Action onDelete,Action<string> onEdit)
        {
            mData = data;
            mOnFinish = onFinish;
            mOnDelete = onDelete;
            mOnEdit = onEdit;
        }

        public override Widget build(BuildContext context)
        {
            return
                new ListTile(
                    leading: new IconButton(
                        icon:new Icon(Icons.check_box,color:new Color(0xff42a5f5)),
                        iconSize:65,
                        onPressed:()=>mOnFinish()),
                    trailing: new IconButton(
                        icon: new Icon(Icons.delete_outline, color: new Color(0xffef5350)),
                        iconSize:65,
                        onPressed:()=>mOnDelete()),
                    subtitle: new Text(DateTime.Now.ToString("yyyy 年 m 月 d 日 HH:mm:ss")),
                    title: QF.Text
                        .Data(mData.Content)
                        .FontSize(30)
                        .EndText(),
                    onTap: () =>
                    {
                        var callback = Navigator.push(context, new MaterialPageRoute(buildContext => new TodoDetailScreen(mData)));

                        callback.Then(result =>
                        {
                            var newContent = result as string;

                            if (string.IsNullOrEmpty(newContent))
                            {
                                
                            }
                            else
                            {
                                mOnEdit.Invoke(newContent);
                            }
                        });
                    });
        }
    }
}