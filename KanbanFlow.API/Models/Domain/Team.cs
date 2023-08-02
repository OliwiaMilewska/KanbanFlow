namespace KanbanFlow.API.Models.Domain
{
    public class Team
    {
        public Guid Id { get; set; }
        public string TeamName { get; set; }

        public List<TeamMember> TeamMembers { get; set; }
    }
}