namespace KanbanFlow.API.Models.DTOs.Task
{
    public class TaskDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public UserDto? Owner { get; set; }
        public UserDto Reporter { get; set; }
        public DateTime DateOfReport { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
        public Guid ProjectId { get; set; }
        public Guid TeamId { get; set; }

        public List<CommentDto> Comments { get; set; }
    }
}
