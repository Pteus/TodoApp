using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using ToDoAPI.DbAccess.TodoRepository;
using ToDoAPI.Dtos;
using ToDoAPI.Models;

namespace ToDoAPI;

public static class TodoEndpoints
{
    public static void ConfigureToDoEndpoints(this WebApplication app)
    {
        app.MapGet("api/v1/Todos", GetAllTodos);
        app.MapGet("api/v1/Todos/{id:int}", GetTodoById);
    }

    private static async Task<IResult> GetAllTodos(ITodoRepository repository, IMapper mapper)
    {
        var results = await repository.GetAllTodos();
        return Results.Ok(mapper.Map<IEnumerable<GetTodoResponse>>(results));
    }

    private static async Task<IResult> GetTodoById(ITodoRepository repository, IMapper mapper, int id)
    {
        var result = await repository.GetTodo(id);
        
        return result != null ? Results.Ok(mapper.Map<GetTodoResponse>(result)) : Results.NotFound();
    }
}