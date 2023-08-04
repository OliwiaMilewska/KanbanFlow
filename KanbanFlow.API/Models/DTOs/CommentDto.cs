namespace KanbanFlow.API.Models.DTOs
{
    public class CommentDto
    {
        public UserDto Commentator { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
    }
}
