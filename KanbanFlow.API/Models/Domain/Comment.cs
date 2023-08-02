using Microsoft.AspNetCore.Identity;

namespace KanbanFlow.API.Models.Domain
{
    public class Comment
    {
        public Guid Id { get; set; }
        public string CommentatorId { get; set; }
        public IdentityUser Commentator { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

        public Guid TaskId { get; set; }
    }
}