using task_api.Models;
using Task = task_api.Models.Task;
using task_api.Migrations;

namespace task_api.Repositories;

public class TaskRepository : ITaskRepository 
{
    private readonly TaskDbContext _context;

    public TaskRepository(TaskDbContext context)
    {
        _context = context;
    }

    public Task CreateTask(Task newTask)
    {
        _context.Tasks.Add(newTask);
        _context.SaveChanges();
        return newTask;
    }

    public void DeleteTaskById(int taskId)
    {
        var task = _context.Tasks.Find(taskId);
        if (task != null) {
            _context.Tasks.Remove(task); 
            _context.SaveChanges(); 
        }
    }

    public IEnumerable<Task> GetAllTasks()
    {
        return _context.Tasks.ToList();
    }

    public Task? GetTaskById(int taskId)
    {
        return _context.Tasks.SingleOrDefault(c => c.TaskId == taskId);
    }

    public Task? UpdateTask(Task newTask)
    {
        var originalTask = _context.Tasks.Find(newTask.TaskId);
        if (originalTask != null) {
            originalTask.Title = newTask.Title;
            originalTask.Completed = newTask.Completed;
            _context.SaveChanges();
        }
        return originalTask;
    }
}

