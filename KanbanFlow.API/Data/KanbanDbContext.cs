using KanbanFlow.API.Helpers.Enums;
using KanbanFlow.API.Models.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Task = KanbanFlow.API.Models.Domain.Task;

namespace KanbanFlow.API.Data
{
    public class KanbanDbContext: IdentityDbContext
    {
        private readonly IConfiguration _configuration;

        public KanbanDbContext(DbContextOptions<KanbanDbContext> dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            _configuration = configuration;
        }

        public DbSet<Task> Tasks { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var connectionString = _configuration.GetConnectionString("KanbanDbConnectionString");
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityRole>().HasData(SeedRoles());

            modelBuilder.Entity<Team>().HasData(SeedTeams());
            modelBuilder.Entity<TeamMember>().HasData(SeedTeamMembers());

            modelBuilder.Entity<Project>()
            .HasOne(p => p.ProjectManager)
            .WithMany()
            .HasForeignKey(p => p.ProjectManagerId);
            modelBuilder.Entity<Project>().HasData(SeedProjects());

            modelBuilder.Entity<Task>(entity =>
            {
                entity.HasMany(t => t.Comments)
                      .WithOne()
                      .HasForeignKey(c => c.TaskId)
                      .OnDelete(DeleteBehavior.NoAction);
            });
            modelBuilder.Entity<Task>()
            .HasOne(t => t.Owner)
            .WithMany()
            .HasForeignKey(t => t.OwnerId);
            modelBuilder.Entity<Task>()
            .HasOne(t => t.Reporter)
            .WithMany()
            .HasForeignKey(t => t.ReporterId);
            modelBuilder.Entity<Task>().HasData(SeedTasks());

            modelBuilder.Entity<Comment>().HasData(SeedComments());
        }

        private static List<IdentityRole> SeedRoles()
        {
            var developerRoleId = "60ea4963-1a46-403c-86be-625a6cf345f3";
            var managerRoleId = "3f971339-1a3d-4a59-870b-99cb38412835";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = developerRoleId,
                    ConcurrencyStamp = developerRoleId,
                    Name = "Developer",
                    NormalizedName = "Developer".ToUpper(),
                },
                new IdentityRole
                {
                    Id = managerRoleId,
                    ConcurrencyStamp = managerRoleId,
                    Name = "Manager",
                    NormalizedName = "Manager".ToUpper(),
                }
            };

            return roles;
        }

        private static List<Team> SeedTeams()
        {
            return new List<Team>()
            {
                new Team
                {
                    Id = Guid.Parse("25ef9129-9a40-4016-a1ac-e16c1bd6c307"),
                    TeamName = "Code Wizards"
                },
                new Team
                {
                    Id = Guid.Parse("987bc5f6-2999-4943-9e95-b2e4b74ed567"),
                    TeamName = "Tech Titans"
                },
                new Team
                {
                    Id = Guid.Parse("d354e006-50ca-471d-b768-42e37cb1d750"),
                    TeamName = "Bug Busters"
                },
                new Team
                {
                    Id = Guid.Parse("f4cf9c55-63b8-4a7f-9072-a9c3930b05ef"),
                    TeamName = "Pixel Pioneers"
                },
            };
        }

        private static List<TeamMember> SeedTeamMembers()
        {
            return new List<TeamMember>
            {
                new TeamMember
                {
                    Id = Guid.Parse("a816cee5-8c76-41eb-8d98-97b973d7d4ae"),
                    TeamId = Guid.Parse("25ef9129-9a40-4016-a1ac-e16c1bd6c307"),
                    MemberId = "4f2e8b12-fb8b-4f0d-891a-34afad4095f8"
                },
                new TeamMember
                {
                    Id = Guid.Parse("c9dea465-9682-471e-9417-a94802c901d5"),
                    TeamId = Guid.Parse("25ef9129-9a40-4016-a1ac-e16c1bd6c307"),
                    MemberId = "6c3357e6-f24e-487e-926a-d6cf266790c1"
                },
                new TeamMember
                {
                    Id = Guid.Parse("a163dbb9-8c52-4d9e-9146-c551d73ed683"),
                    TeamId = Guid.Parse("25ef9129-9a40-4016-a1ac-e16c1bd6c307"),
                    MemberId = "c75d74ac-587c-4793-89a2-c1aff590fef0"
                },
                new TeamMember
                {
                    Id = Guid.Parse("fd84ee40-5579-4433-97ae-a13498ea473f"),
                    TeamId = Guid.Parse("987bc5f6-2999-4943-9e95-b2e4b74ed567"),
                    MemberId = "6d018538-71da-4dbe-95a3-c334150375aa"
                },
                new TeamMember
                {
                    Id = Guid.Parse("9006d8b3-783c-40b5-acda-1ee97d12828d"),
                    TeamId = Guid.Parse("987bc5f6-2999-4943-9e95-b2e4b74ed567"),
                    MemberId = "785e3ed9-9388-4ca9-922b-ab69cbd9651c"
                },
                new TeamMember
                {
                    Id = Guid.Parse("758091fd-6ec8-4b9b-b78a-9471f42c484f"),
                    TeamId = Guid.Parse("987bc5f6-2999-4943-9e95-b2e4b74ed567"),
                    MemberId = "896cbb0f-ce93-43ec-8915-eb077fd3833d"
                },
                new TeamMember
                {
                    Id = Guid.Parse("e896018d-168d-4c76-a2b2-59e8df944970"),
                    TeamId = Guid.Parse("d354e006-50ca-471d-b768-42e37cb1d750"),
                    MemberId = "7a5b4d2b-a396-44e0-b918-4befcb2f9a4e"
                },
                new TeamMember
                {
                    Id = Guid.Parse("ea95ac6c-83ca-4221-85d1-f60011e8c103"),
                    TeamId = Guid.Parse("d354e006-50ca-471d-b768-42e37cb1d750"),
                    MemberId = "ea708fc7-69bb-4f37-bef8-5bb2e6731aa1"
                },
                new TeamMember
                {
                    Id = Guid.Parse("81d15f82-3e9c-47c3-b299-b1581cd65c2c"),
                    TeamId = Guid.Parse("f4cf9c55-63b8-4a7f-9072-a9c3930b05ef"),
                    MemberId = "ac77693f-523c-407f-ac9b-5730b9f2af62"
                },
                new TeamMember
                {
                    Id = Guid.Parse("da33d048-0f80-4699-a3d4-d96af6da8ddf"),
                    TeamId = Guid.Parse("f4cf9c55-63b8-4a7f-9072-a9c3930b05ef"),
                    MemberId = "c1e5da6e-e4e4-4a94-a79e-e65ef7bd6746"
                }
            };
        }

        private static List<Project> SeedProjects()
        {
            return new List<Project>
            {
                new Project
                {
                    Id = Guid.Parse("77876cb3-c59b-4259-84d6-ef97d0ef54c8"),
                    ProjectName = "AuroraX",
                    ProjectManagerId = "977890c6-ed82-44d2-89d1-e9bcbe044342"
                },
                new Project
                {
                    Id = Guid.Parse("59601d29-d1ca-4278-aa7f-61b9dd88f9cd"),
                    ProjectName = "Cybersphere",
                    ProjectManagerId = "977890c6-ed82-44d2-89d1-e9bcbe044342"
                },
            };
        }

        private static List<Task> SeedTasks()
        {
            return new List<Task>()
            {
                new Task
                {
                    Id = Guid.Parse("79705c41-29cb-4098-bb62-9bb3b099acb6"),
                    Title = "Init DB",
                    Description = "Create DbContext class to init the database.",
                    OwnerId = "977890c6-ed82-44d2-89d1-e9bcbe044342",
                    ReporterId = "977890c6-ed82-44d2-89d1-e9bcbe044342",
                    DateOfReport = DateTime.Now,
                    Priority = Priority.High,
                    Status = Status.InProgress,
                    ProjectId = Guid.Parse("77876cb3-c59b-4259-84d6-ef97d0ef54c8"),
                    TeamId = Guid.Parse("25ef9129-9a40-4016-a1ac-e16c1bd6c307")
                },
                new Task
                {
                    Id = Guid.Parse("30627367-6325-4503-b55e-c4584fc72cb6"),
                    Title = "Create mocks of UI",
                    Description = "Create first concept of UI that will be presented on a meeting.",
                    OwnerId = null,
                    ReporterId = "977890c6-ed82-44d2-89d1-e9bcbe044342",
                    DateOfReport = DateTime.Now,
                    Priority = Priority.High,
                    Status = Status.ToDo,
                    ProjectId = Guid.Parse("77876cb3-c59b-4259-84d6-ef97d0ef54c8"),
                    TeamId = Guid.Parse("f4cf9c55-63b8-4a7f-9072-a9c3930b05ef")
                },
                new Task
                {
                    Id = Guid.Parse("0f446d5b-d6b6-4830-bdd4-dd00ee577f4c"),
                    Title = "Create Auth Controller.",
                    Description = "We need to have options for login and register for users.",
                    OwnerId = null,
                    ReporterId = "977890c6-ed82-44d2-89d1-e9bcbe044342",
                    DateOfReport = DateTime.Now,
                    Priority = Priority.Urgent,
                    Status = Status.ToDo,
                    ProjectId = Guid.Parse("59601d29-d1ca-4278-aa7f-61b9dd88f9cd"),
                    TeamId = Guid.Parse("987bc5f6-2999-4943-9e95-b2e4b74ed567")
                },
                new Task
                {
                    Id = Guid.Parse("7559cedd-4c01-4cb7-89de-be64afa35df4"),
                    Title = "Fix bug with displaying sum up statistics.",
                    Description = "There is a bug when dispalying sum up statisitcs of a space ship. Sometimes the statistics won't load.",
                    OwnerId = "896cbb0f-ce93-43ec-8915-eb077fd3833d",
                    ReporterId = "7a5b4d2b-a396-44e0-b918-4befcb2f9a4e",
                    DateOfReport = DateTime.Now,
                    Priority = Priority.Urgent,
                    Status = Status.ToCheck,
                    ProjectId = Guid.Parse("59601d29-d1ca-4278-aa7f-61b9dd88f9cd"),
                    TeamId = Guid.Parse("d354e006-50ca-471d-b768-42e37cb1d750")
                },
            };
        }

        private static List<Comment> SeedComments()
        {
            return new List<Comment>
            {
                new Comment
                {
                    Id = Guid.Parse("17b7acc2-42b3-41ba-956c-7d7291f4a898"),
                    CommentatorId = "6c3357e6-f24e-487e-926a-d6cf266790c1",
                    Date = DateTime.Now,
                    Description = "We need to add new table to store logs!",
                    TaskId = Guid.Parse("79705c41-29cb-4098-bb62-9bb3b099acb6")
                },
                new Comment
                {
                    Id = Guid.Parse("8cc258cf-919f-45af-9cf4-b64069b4ead2"),
                    CommentatorId = "7a5b4d2b-a396-44e0-b918-4befcb2f9a4e",
                    Date = DateTime.Now,
                    Description = "I need help here from team @Tech Titans",
                    TaskId = Guid.Parse("7559cedd-4c01-4cb7-89de-be64afa35df4")
                },
            };
        }
    }
}
