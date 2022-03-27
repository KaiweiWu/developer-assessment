using System;

namespace TodoList.Api.Models
{
    public class TodoItemViewModel
    {
        public TodoItemViewModel(TodoItem item)
        {
            Id = item.Id;
            Description = item.Description;
            IsCompleted = item.IsCompleted;
        }

        public Guid Id { get; set; }

        public string Description { get; set; }

        public bool IsCompleted { get; set; }
    }
}
