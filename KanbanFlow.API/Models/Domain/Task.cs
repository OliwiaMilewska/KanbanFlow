using KanbanFlow.API.Helpers.Enums;
using Microsoft.AspNetCore.Identity;

namespace KanbanFlow.API.Models.Domain
{
    public class Task
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string? OwnerId { get; set; }
        public IdentityUser? Owner { get; set; }
        public string ReporterId { get; set; }
        public IdentityUser Reporter { get; set; }
        public DateTime DateOfReport { get; set; }
        public Priority Priority { get; set; }
        public Status Status { get; set; }
        public Guid ProjectId { get; set; }
        public Guid TeamId { get; set; }

        public List<Comment> Comments { get; set; }
    }
}