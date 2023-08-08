using AutoMapper;
using ToDoAPI.Dtos;
using ToDoAPI.Models;

namespace ToDoAPI.Profiles;

public class TodosProfile : Profile
{
    public TodosProfile()
    {
        CreateMap<TodoModel, GetTodoResponse>();
        CreateMap<CreateTodoRequest, TodoModel>();
        CreateMap<UpdateTodoRequest, TodoModel>();
    }
}