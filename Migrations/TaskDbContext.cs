using task_api.Models;
using Microsoft.EntityFrameworkCore;
using Task = task_api.Models.Task;

namespace task_api.Migrations;

public class TaskDbContext : DbContext
{
    public DbSet<Task> Tasks { get; set; }
    public TaskDbContext(DbContextOptions<TaskDbContext> options)
    : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasKey(e => e.TaskId);
            entity.Property(e => e.Title).IsRequired();
            entity.Property(e => e.Completed);
        });
    }
}