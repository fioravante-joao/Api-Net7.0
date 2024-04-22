using Microsoft.EntityFrameworkCore;
using MinhasTarefas.Models;

namespace MinhasTarefas.Data
{
    public class AppDbContext:DbContext
    {
        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder) => 
            optionsBuilder.UseSqlite(connectionString:"DataSource=app.db;Cache=Shared");
    }
}
