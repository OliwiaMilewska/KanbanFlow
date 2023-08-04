namespace KanbanFlow.API.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        Task<Models.Domain.Task> CreateTask(Models.Domain.Task newTask);
        Task<List<Models.Domain.Task>> GetAllTasks();
        Task<Models.Domain.Task?> GetTask(Guid id);
        Task<Models.Domain.Task> UpdateTask(Guid id, Models.Domain.Task updatedTask);
        Task<Models.Domain.Task> DeleteTask(Guid id); 
    }
}