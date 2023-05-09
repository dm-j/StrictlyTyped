using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using static Example.TodoItems;
using StrictlyTyped.EntityFramework;
using Example.Infrastructure;
using Example.Dtos;

namespace Example.Models
{
    public class TodoItem : IHasDto<TodoItem, TodoItemDto>
    {
        public Id Id { get; set; }

        public Name? Name { get; set; }

        public IsComplete IsComplete { get; set; }

        public Secret? Secret { get; set; }

        public Date? Date { get; set; }

        public void UpdateFrom(TodoItemDto value)
        {
            Id = value.Id;
            Name = value.Name;
            IsComplete = value.IsComplete;
            Date = value.Date;
        }
    }

    public class TodoItemsConfiguration : IEntityTypeConfiguration<TodoItem>
    {
        public void Configure(EntityTypeBuilder<TodoItem> builder)
        {
            builder.Property(e => e.Id).GenerateStrictGuid();
            builder.Property(e => e.Name);
            builder.Property(e => e.IsComplete);
            builder.Property(e => e.Date).HasConversion<StrictDateOnlyConverter<Date>>();
        }
    }
}
