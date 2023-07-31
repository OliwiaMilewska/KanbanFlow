using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KanbanFlow.API.Data
{
    public class KanbanDbAuthContext: IdentityDbContext
    {
        private readonly IConfiguration _configuration;

        public KanbanDbAuthContext(DbContextOptions<KanbanDbAuthContext> dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            _configuration = configuration;
        }

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
    }
}
