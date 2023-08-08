using ToDoAPI.Dtos;
using ToDoAPI.Models;

namespace ToDoAPI.DbAccess.TodoRepository;

public interface ITodoRepository
{
    Task SaveChanges();
    Task<IEnumerable<TodoModel>> GetAllTodos();
    Task<TodoModel?> GetTodo(int id);
    Task CreateTodo(TodoModel todoModel);
    Task DeleteTodo(int id);
    Task<TodoModel> UpdateTodo(TodoModel todoModel);
}