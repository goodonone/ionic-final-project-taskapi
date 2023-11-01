using task_api.Models;
using task_api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace task.Controllers;

[ApiController]
[Route("[controller]")]
public class TaskController : ControllerBase 
{
    private readonly ILogger<TaskController> _logger;
    private readonly ITaskRepository _taskRepository;

    public TaskController(ILogger<TaskController> logger, ITaskRepository repository)
    {
        _logger = logger;
        _taskRepository = repository;
    }
}