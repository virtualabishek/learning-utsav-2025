using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore;
    using TodoApp.Models;

    namespace TodoApp.Data
    {
        public class TodoContext : IdentityDbContext
        {
            public TodoContext(DbContextOptions<TodoContext> options) : base(options)
            {

            }
            public DbSet<TodoItem> Todos { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<TodoItem>().HasOne<Microsoft.AspNetCore.Identity.IdentityUser>().WithMany().HasForeignKey(t => t.UserId);
        }
        }
    }