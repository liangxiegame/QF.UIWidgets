using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace TodoListUIWidgets
{
    public class Todo
    {
        public string Content = string.Empty;

        public bool Finished = false;
    }


    public static class Model
    {
        public static List<Todo> Load()
        {
            var todoListStringContent = PlayerPrefs.GetString("TODO_LIST_KEY", string.Empty);

            var splitDatas = todoListStringContent
                .Split(new[] {"@@@@"}, StringSplitOptions.None);

            return splitDatas
                .Where(splitData => !string.IsNullOrWhiteSpace(splitData))
                .Select(todoData =>
                {
                    var todo = new Todo();

                    var todoSplitDatas = todoData.Split(new[] {"::::"}, StringSplitOptions.None);

                    todo.Content = todoSplitDatas[0];

                    if (todoSplitDatas.Length > 1)
                    {
                        todo.Finished = bool.Parse(todoSplitDatas[1]);
                    }

                    return todo;
                })
                .ToList();
        }

        public static void Save(this List<Todo> self)
        {
            var stringBuilder = new StringBuilder();
            self.ForEach(todoData =>
            {
                stringBuilder.Append(todoData.Content);
                stringBuilder.Append("::::");
                stringBuilder.Append(todoData.Finished);
                stringBuilder.Append("@@@@");
            });

            PlayerPrefs.SetString("TODO_LIST_KEY", stringBuilder.ToString());
        }
    }
}