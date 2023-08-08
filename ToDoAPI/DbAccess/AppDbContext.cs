using Microsoft.EntityFrameworkCore;
using ToDoAPI.Models;

namespace ToDoAPI.DbAccess;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
    {
        
    }

    public DbSet<TodoModel> Todos { get; set; }
}