using KanbanFlow.API.Models.Domain;

namespace KanbanFlow.API.Repositories.Interfaces
{
    public interface ICommentRepository
    {
        Task<Comment?> CreateCommentAsync(Guid taskId, Comment comment);
        Task<Comment?> UpdateCommentByIdAsync(Guid commentId, Comment comment);
        Task<Comment?> DeleteCommentByIdAsync(Guid commentId);
    }
}
