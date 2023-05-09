using Example.Infrastructure;
using Example.Models;
using static Example.TodoItems;

namespace Example.Dtos
{
    public class TodoItemDto : IDto<TodoItemDto, TodoItem>
    {
        public Id Id { get; set; }

        public Name? Name { get; set; }

        public IsComplete IsComplete { get; set; }

        public Date? Date { get; set; }

        public static TodoItemDto From(TodoItem todo) =>
            new()
            {
                Id = todo.Id,
                Name = todo.Name,
                IsComplete = todo.IsComplete,
                Date = todo.Date,
            };

        public TodoItem AsValue() =>
            new()
            {
                Id = this.Id,
                Name = this.Name,
                IsComplete = this.IsComplete,
                Date = this.Date,
            };
    }
}
