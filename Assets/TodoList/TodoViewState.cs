
using System;
using System.Collections.Generic;

namespace TodoListUIWidgets
{
    [Serializable]
    public class TodoViewState
    {
        public TodoListPageMode TodoListPageMode = TodoListPageMode.List;
        
        public List<Todo> Todos = new List<Todo>();
    }
}