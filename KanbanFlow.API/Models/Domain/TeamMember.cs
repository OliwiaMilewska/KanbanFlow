using Microsoft.AspNetCore.Identity;

namespace KanbanFlow.API.Models.Domain
{
    public class TeamMember
    {
        public Guid Id { get; set; }
        public Guid TeamId { get; set; }
        public string MemberId { get; set; }
        public IdentityUser Member { get; set; }
    }
}