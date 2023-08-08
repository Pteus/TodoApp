using AutoMapper;
using ToDoAPI.DbAccess.TodoRepository;
using ToDoAPI.Dtos;
using ToDoAPI.Models;

namespace ToDoAPI;

public static class TodoEndpoints
{
    public static void ConfigureToDoEndpoints(this WebApplication app)
    {
        app.MapGet("api/v1/todos", GetAllTodos);
        app.MapGet("api/v1/todos/{id:int}", GetTodoById);
        app.MapPost("api/v1/todos", CreateTodo);
        app.MapDelete("api/v1/todos/{id:int}", DeleteTodo);
        app.MapPut("api/v1/todos/{id:int}", UpdateTodo);
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

    private static async Task<IResult> CreateTodo(ITodoRepository todoRepository, IMapper mapper,
        CreateTodoRequest createTodoRequest)
    {
        var todoModel = mapper.Map<TodoModel>(createTodoRequest);

        await todoRepository.CreateTodo(todoModel);
        await todoRepository.SaveChanges();

        var createdTodo = mapper.Map<GetTodoResponse>(todoModel);

        return Results.Created($"api/v1/todos/{createdTodo.Id}", createdTodo);
    }

    private static async Task<IResult> DeleteTodo(ITodoRepository todoRepository, IMapper mapper, int id)
    {
        await todoRepository.DeleteTodo(id);
        await todoRepository.SaveChanges();
        return Results.NoContent();
    }

    private static async Task<IResult> UpdateTodo(ITodoRepository todoRepository, IMapper mapper, int id,
        UpdateTodoRequest updateTodoRequest)
    {
        var todo = await todoRepository.GetTodo(id);

        if (todo == null)
        {
            return Results.NotFound();
        }

        mapper.Map(updateTodoRequest, todo);

        await todoRepository.SaveChanges();

        return Results.NoContent();
    }
}