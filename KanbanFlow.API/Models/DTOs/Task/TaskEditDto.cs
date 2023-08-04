
namespace KanbanFlow.API.Models.DTOs.Task
{
    public class TaskEditDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public UserDto? Owner { get; set; }
        public DateTime DateOfReport { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
    }
}
