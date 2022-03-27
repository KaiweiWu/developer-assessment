using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoList.Api.Models;

namespace TodoList.Api.ServiceInterfaces
{
    public interface ITodoItemService
    {
        Task<List<TodoItemViewModel>> GetTodoItemList();
        Task<TodoItemViewModel> GetTodoItemByID(Guid id);
        Task<Response> InsertTodoItem(TodoItem item);
        Task<Response> UpdateTodoItem(TodoItem item);
    }
}
