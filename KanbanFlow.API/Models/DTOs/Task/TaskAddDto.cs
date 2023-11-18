namespace KanbanFlow.API.Models.DTOs.Task
{
    public class TaskAddDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string? OwnerId { get; set; }
        public string ReporterId { get; set; }
        public DateTime DateOfReport { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
        public Guid ProjectId { get; set; }
        public Guid TeamId { get; set; }
    }
}
