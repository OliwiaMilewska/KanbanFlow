using KanbanFlow.API.Data;
using KanbanFlow.API.Models.Domain;
using KanbanFlow.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KanbanFlow.API.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly KanbanDbContext _dbContext;
        public CommentRepository(KanbanDbContext context)
        {
            _dbContext = context;
        }

        public async Task<Comment?> CreateCommentAsync(Guid taskId, Comment comment)
        {
            comment.TaskId = taskId;
            var task = await _dbContext.Tasks.Include(t => t.Comments).ThenInclude(x => x.Commentator).FirstOrDefaultAsync(t => t.Id == taskId);
            if (task == null)
                return null;

            if (task.Comments == null)
                task.Comments = new List<Comment>();

            task.Comments.Add(comment);
            await _dbContext.SaveChangesAsync();
            return comment;
        }

        public async Task<Comment?> UpdateCommentByIdAsync(Guid commentId, Comment comment)
        {
            var exisitingComment = await _dbContext.Comments.FirstOrDefaultAsync(c => c.Id == commentId);
            if (exisitingComment == null)
                return null;

            exisitingComment.Description = comment.Description;
            exisitingComment.Date = DateTime.Now;

            await _dbContext.SaveChangesAsync();
            return exisitingComment;
        }

        public async Task<Comment?> DeleteCommentByIdAsync(Guid commentId)
        {
            var comment = await _dbContext.Comments.FirstOrDefaultAsync(c => c.Id == commentId);
            if (comment == null)
                return null;

            _dbContext.Comments.Remove(comment);
            await _dbContext.SaveChangesAsync();

            return comment;
        }
    }
}
