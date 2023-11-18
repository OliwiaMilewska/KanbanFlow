namespace KanbanFlow.API.Models.DTOs.Comment
{
    public class CommentAddDto
    {
        public string CommentatorId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
    }
}
