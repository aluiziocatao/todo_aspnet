using Microsoft.EntityFrameworkCore;
using TWTodos_ASP.NET.Models;

namespace TWTodos_ASP.NET.Contexts;

public class TWTodosContext : DbContext {
    public DbSet<Todo> Todos => Set<Todo>();

    public TWTodosContext(DbContextOptions<TWTodosContext> options) : base(options) {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Todo>().ToTable("Todo");
        base.OnModelCreating(modelBuilder);
    }
}