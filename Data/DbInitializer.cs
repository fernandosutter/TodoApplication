using TodoApplicationWebApi.Models;
using System;
using System.Linq;


namespace TodoApplicationWebApi.Data
{
    public class DbInitializer
    {
        public static void Initialize(TodoItemContext context)
        {
            context.Database.EnsureCreated();

            if (context.TodoItems.Any())
            {
                return;
            }

            var TodoItem = new TodoItem()
            {
                Id = 0,
                Title = "Teste de inicialização",
                CreatedAt = DateTime.Now,
                LastUpdatedAt = DateTime.Now,
                IsComplete = false
            };

            context.TodoItems.Add(TodoItem);

            context.SaveChanges();
        }
    }
}
