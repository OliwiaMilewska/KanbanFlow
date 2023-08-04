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
            return await _dbContext.Tasks
                .Include(t => t.Owner)
                .Include(t => t.Reporter)
                .Include(t => t.Comments)
                .ThenInclude(c => c.Commentator)
                .ToListAsync();
        }

        public async Task<Models.Domain.Task?> GetTask(Guid id)
        {
            return await _dbContext.Tasks
                .Include(t => t.Owner)
                .Include(t => t.Reporter)
                .Include(x => x.Comments)
                .FirstOrDefaultAsync(task => task.Id == id);
        }

        public Task<Models.Domain.Task> UpdateTask(Models.Domain.Task newTask)
        {
            throw new NotImplementedException();
        }

        public Task<Models.Domain.Task> DeleteTask(Models.Domain.Task newTask)
        {
            throw new NotImplementedException();
        }
    }
}
