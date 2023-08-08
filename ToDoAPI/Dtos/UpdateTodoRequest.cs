using System.ComponentModel.DataAnnotations;

namespace ToDoAPI.Dtos;

public class UpdateTodoRequest
{
    [Required]
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool Done { get; set; }
}