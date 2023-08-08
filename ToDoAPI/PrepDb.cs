using ToDoAPI.DbAccess;
using ToDoAPI.Models;

namespace ToDoAPI;

public static class PrepDb
{
    public static void PrepPopulation(IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.CreateScope();
        SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
    }

    private static void SeedData(AppDbContext? dbContext)
    {
        Console.WriteLine("Seeding Data");

        dbContext?.Todos.AddRange(
            new TodoModel { Title = "Example todo", Description = "Example todo description" },
            new TodoModel { Title = "Example todo - done", Description = "Example todo description", Done = true }
        );

        dbContext?.SaveChanges();
    }
}