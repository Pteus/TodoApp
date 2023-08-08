using System.ComponentModel.DataAnnotations;

namespace ToDoAPI.Models;

public class TodoModel
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required]
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool Done { get; set; }
}