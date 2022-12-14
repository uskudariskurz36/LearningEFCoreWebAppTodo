using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace LearningEFCoreWebAppTodo.Entities
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Todo> Todos { get; set; }

        public DatabaseContext()
        {
            
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

        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(50)]
        public string Category { get; set; }

        public bool Completed { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
