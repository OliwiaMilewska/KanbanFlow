namespace KanbanFlow.API.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        Task<Models.Domain.Task> CreateTask(Models.Domain.Task newTask);
        Task<List<Models.Domain.Task>> GetAllTasks();
        Task<Models.Domain.Task?> GetTask(Guid id);
        Task<Models.Domain.Task> UpdateTask(Models.Domain.Task newTask);
        Task<Models.Domain.Task> DeleteTask(Models.Domain.Task newTask); 
    }
}