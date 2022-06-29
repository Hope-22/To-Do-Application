using Microsoft.EntityFrameworkCore;
using ToDoApplication.Models;

namespace ToDoApplication.Data
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions options) : base(options)
        {
        }

        //private readonly string _configure;

        //public TodoContext(DbContextOptions<TodoContext> options, IConfiguration config)
        //    : base(options)
        //{
        //    //_configure = config.GetConnectionString("Path");
        //}

        public DbSet<ToDo> Todos { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=DESKTOP-IU46U34;Database=TodoEF;Trusted_Connection=True;");

        //    base.OnConfiguring(optionsBuilder);
        //}
    }
}
