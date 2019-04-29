using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TodoListUIWidgets;
using UnityEngine;

namespace LearnUIWidgets
{
    public class Reducers 
    {
        public static TodoViewState Reduce(TodoViewState previousState, object action)
        {
            switch (action)
            {
                case ListPageModeAction _:
                    return new TodoViewState()
                    {
                        TodoListPageMode = TodoListPageMode.List,
                        Todos = previousState.Todos,
                    };
                case FinishedPageModeAction _:

                    return new TodoViewState()
                    {
                        TodoListPageMode = TodoListPageMode.Finished,
                        Todos = previousState.Todos,
                    };
                case AddTodoAction addTodoAction:

                    var previousTodos = previousState.Todos;
                    previousTodos.Add(new Todo()
                    {
                        Content = addTodoAction.TodoContent
                    });

                    return new TodoViewState()
                    {
                        TodoListPageMode = previousState.TodoListPageMode,
                        Todos = previousTodos
                    };
                case DeleteTodoAction deleteTodoAction:
                    return new TodoViewState()
                    {
                        TodoListPageMode = previousState.TodoListPageMode,
                        Todos = previousState.Todos.Where(todo=>todo != deleteTodoAction.Todo).ToList()
                    };
                case FinishTodoAction finishTodoAction:
                    return new TodoViewState()
                    {
                        TodoListPageMode = previousState.TodoListPageMode,
                        Todos = previousState.Todos.Select(todo =>
                        {
                            if (todo == finishTodoAction.Todo)
                            {
                                todo.Finished = true;
                            }

                            return todo;
                        }).ToList()
                    };
                case UpdateTodoAction updateTodoAction:
                    return new TodoViewState
                    {
                        TodoListPageMode = previousState.TodoListPageMode,
                        Todos = previousState.Todos.Select(todo =>
                        {
                            if (todo == updateTodoAction.Todo)
                            {
                                todo.Content = updateTodoAction.NewContent;
                            }

                            return todo;
                        }).ToList()
                    };
                case NetworkRequestAction networkRequestAction:

                    Debug.Log(networkRequestAction.Result);
                    return previousState;
            }

            return previousState;
        }
    }
}
