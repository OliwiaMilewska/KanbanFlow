using KanbanFlow.API.Data;
using KanbanFlow.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KanbanFlow.API.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly KanbanDbContext _dbContext;

        public TaskRepository(KanbanDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Models.Domain.Task> CreateTask(Models.Domain.Task newTask)
        {
            await _dbContext.Tasks.AddAsync(newTask);
            await _dbContext.SaveChangesAsync();
            return newTask;
        }

        public async Task<List<Models.Domain.Task>> GetAllTasks()
        {
            var tasks = await _dbContext.Tasks
                .Include(t => t.Owner)
                .Include(t => t.Reporter)
                .Include(t => t.Comments)
                .ThenInclude(c => c.Commentator)
                .ToListAsync();

            if (!tasks.Any())
                return null;

            return tasks;
        }

        public async Task<Models.Domain.Task?> GetTask(Guid id)
        {
            var task = await _dbContext.Tasks
                .Include(t => t.Owner)
                .Include(t => t.Reporter)
                .Include(t => t.Comments)
                .ThenInclude(c => c.Commentator)
                .FirstOrDefaultAsync(task => task.Id == id);

            if (task == null)
                return null;

            return task;
        }

        public async Task<Models.Domain.Task> UpdateTask(Guid id, Models.Domain.Task updatedTask)
        {
            var existingTask = await _dbContext.Tasks
                .Include(x => x.Comments)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (existingTask == null)
                return null;

            existingTask.Title = updatedTask.Title;
            existingTask.Owner = updatedTask.Owner;
            existingTask.DateOfReport = updatedTask.DateOfReport;
            existingTask.Priority = updatedTask.Priority;
            existingTask.Status = updatedTask.Status;
            existingTask.Description = updatedTask.Description;

            await _dbContext.SaveChangesAsync();
            return existingTask;
        }

        public async Task<Models.Domain.Task> DeleteTask(Guid id)
        {
            var task = await _dbContext.Tasks
                .FirstOrDefaultAsync(x => x.Id == id);
            if (task == null)
                return null;

            _dbContext.Tasks.Remove(task);
            await _dbContext.SaveChangesAsync();
            return task;
        }
    }
}
