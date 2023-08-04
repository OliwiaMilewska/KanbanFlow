using Microsoft.AspNetCore.Identity;

namespace KanbanFlow.API.Repositories.Interfaces
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, string[] roles);
    }
}
