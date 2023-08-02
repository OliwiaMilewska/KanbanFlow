using Microsoft.AspNetCore.Identity;

namespace KanbanFlow.API.Models.Domain
{
    public class Project
    {
        public Guid Id { get; set; }
        public string ProjectName { get; set; }
        public string ProjectManagerId { get; set; }
        public IdentityUser ProjectManager { get; set; }
    }
}