using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoList.Api.Models;

namespace TodoList.Api.RepositoryInterfaces
{
    public interface ITodoItemRepository
    {
        Task<List<TodoItem>> GetTodoItemList();
        Task<TodoItem> GetTodoItemByID(Guid id);
        Task<bool> InsertTodoItem(TodoItem item);
        Task<bool> UpdateTodoItem(TodoItem item);
        bool TodoItemDescriptionExists(string description);
    }
}
