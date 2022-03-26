using System;

namespace TodoList.Api.Models
{
    public class TodoItemViewModel
    {
        public TodoItemViewModel(TodoItem item)
        {
            Guid = item.Id;
            Description = item.Description;
            IsCompleted = item.IsCompleted;
        }

        public Guid Guid { get; set; }

        public string Description { get; set; }

        public bool IsCompleted { get; set; }
    }
}
