using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Api.Models;
using TodoList.Api.RepositoryInterfaces;
using TodoList.Api.ServiceInterfaces;

namespace TodoList.Api.Services
{
    public class TodoItemService : ITodoItemService
    {
        private readonly ITodoItemRepository _todoItemRepository;

        public TodoItemService(ITodoItemRepository todoItemRepository)
        {
            _todoItemRepository = todoItemRepository;
        }

        public async Task<List<TodoItemViewModel>> GetTodoItemList()
        {
            var itemList = await _todoItemRepository.GetTodoItemList();

            return itemList.Select(i => new TodoItemViewModel(i)).ToList();
        }

        public async Task<TodoItemViewModel> GetTodoItemByID(Guid id)
        {
            var item = await _todoItemRepository.GetTodoItemByID(id);

            return new TodoItemViewModel(item);
        }

        public async Task<Response> InsertTodoItem(TodoItem item)
        {
            if (string.IsNullOrEmpty(item?.Description))
            {
                return new Response("Description is required", true);
            }
            else if (_todoItemRepository.TodoItemDescriptionExists(item.Description))
            {
                return new Response("Description already exists", true);
            }

            var success = await _todoItemRepository.InsertTodoItem(item);

            if (!success)
                return new Response("Failed to add to do item", true);

            return new Response("Success");
        }

        public async Task<Response> UpdateTodoItem(TodoItem item)
        {
            var success = await _todoItemRepository.UpdateTodoItem(item);

            if (!success)
                return new Response("Failed to update to do item", true);

            return new Response("Success");
        }
    }
}
