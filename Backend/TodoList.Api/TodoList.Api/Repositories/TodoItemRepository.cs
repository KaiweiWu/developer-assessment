using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Api.Models;
using TodoList.Api.RepositoryInterfaces;

namespace TodoList.Api.Repositories
{
    public class TodoItemRepository :ITodoItemRepository
    {
        private readonly TodoContext _context;

        public TodoItemRepository(TodoContext context)
        {
            _context = context;
        }

        public async Task<List<TodoItem>> GetTodoItemList()
        {
            return await _context.TodoItems.Where(x => !x.IsCompleted).ToListAsync();
        }

        public async Task<TodoItem> GetTodoItemByID(Guid id)
        {
            return await _context.TodoItems.FindAsync(id);
        }

        public async Task<bool> InsertTodoItem(TodoItem item)
        {
            _context.TodoItems.Add(item);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateTodoItem(TodoItem item)
        {
            _context.Entry(item).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoItemIdExists(item.Id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }

            return true;
        }

        private bool TodoItemIdExists(Guid id)
        {
            return _context.TodoItems.Any(x => x.Id == id);
        }

        public bool TodoItemDescriptionExists(string description)
        {
            return _context.TodoItems.Any(x => x.Description.ToLowerInvariant() == description.ToLowerInvariant() && !x.IsCompleted);
        }
    }
}
