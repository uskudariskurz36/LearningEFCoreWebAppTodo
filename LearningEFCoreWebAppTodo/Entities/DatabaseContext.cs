using MFramework.Services.FakeData;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace LearningEFCoreWebAppTodo.Entities
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Todo> Todos { get; set; }

        public DatabaseContext()
        {
            // PM> install-package mframework.services.FakeData

            if (Database.EnsureCreated())
            {
                string[] categories = new string[] { "work","business","education","shopping","personal","code" };

                for (int i = 0; i < 100; i++)
                {
                    Todo todo = new Todo
                    {
                        Category = CollectionData.GetElement(categories),
                        Completed = BooleanData.GetBoolean(),
                        CreatedAt = DateTimeData.GetDatetime(DateTime.Now.AddYears(-1),DateTime.Now),
                        Title = TextData.GetSentence()
                    };

                    Todos.Add(todo);
                }

                SaveChanges();
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=Z36LearnEFCoreTodoAppDB;Trusted_Connection=true");
            }
        }
    }

    public class Todo
    {
        [Key]
        public int Id { get; set; }

        [StringLength(250)]
        public string Title { get; set; }

        [StringLength(250)]
        public string Category { get; set; }

        public bool Completed { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
