using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace task_api.Models;

public class Task 
{   [JsonIgnore]
    public int TaskId { get; set; }
    [Required]
    public string? Title { get; set; }
    [JsonIgnore]
    public bool Completed { get; set; }
    
}