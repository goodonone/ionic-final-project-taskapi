using task_api.Models;
using task_api.Repositories;
using Microsoft.AspNetCore.Mvc;
using Task = task_api.Models.Task;

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

    [HttpGet]
    public ActionResult<IEnumerable<Task>> GetTask()
    {
        return Ok(_taskRepository.GetAllTasks());
    }

    [HttpGet]
    [Route("{taskId:int}")]
    public ActionResult<Task> GetTaskById(int taskId)
    {
        var task = _taskRepository.GetTaskById(taskId);
        if (task == null)
        {
            return NotFound();
        }
        return Ok(task);
    }

    [HttpPost]
    public ActionResult<Task> CreateTask(Task task)
    {
        if (!ModelState.IsValid || task == null)
        {
            return BadRequest();
        }
        var newTask = _taskRepository.CreateTask(task);
        return Created(nameof(GetTaskById), newTask);
    }

    [HttpPut]
    [Route("{taskId:int}")]
    public ActionResult<Task> UpdateTask(Task task)
    {
        if (!ModelState.IsValid || task == null)
        {
            return BadRequest();
        }
        return Ok(_taskRepository.UpdateTask(task));
    }

    [HttpDelete]
    [Route("{taskId:int}")]
    public ActionResult DeleteTask(int taskId)
    {
        _taskRepository.DeleteTaskById(taskId);
        return NoContent();
    }


}