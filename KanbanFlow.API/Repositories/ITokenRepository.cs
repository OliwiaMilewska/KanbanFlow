using Microsoft.AspNetCore.Identity;

namespace KanbanFlow.API.Repositories
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, string[] roles);
    }
}
