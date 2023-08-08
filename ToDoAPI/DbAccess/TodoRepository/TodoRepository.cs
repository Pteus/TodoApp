using Microsoft.EntityFrameworkCore;
using ToDoAPI.Dtos;
using ToDoAPI.Models;

namespace ToDoAPI.DbAccess.TodoRepository;

public class TodoRepository : ITodoRepository
{
    private readonly AppDbContext _context;

    public TodoRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task SaveChanges()
    {
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<TodoModel>> GetAllTodos()
    {
        return await _context.Todos.ToListAsync();
    }

    public async Task<TodoModel?> GetTodo(int id)
    {
        return await _context.Todos.FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task CreateTodo(TodoModel todoModel)
    {
        if (todoModel == null)
        {
            throw new ArgumentNullException(nameof(todoModel));
        }

        await _context.AddAsync(todoModel);
    }

    public async Task DeleteTodo(int id)
    {
        var todoModel = await _context.Todos.FirstOrDefaultAsync(t => t.Id == id);
        
        if (todoModel != null) _context.Todos.Remove(todoModel);
    }

    public Task<TodoModel> UpdateTodo(TodoModel todoModel)
    {
        throw new NotImplementedException();
    }
}