using ELC.Lite.Identity.Models.Identity;

namespace ELC.Lite.Identity.Infrastructure.Identities
{
    public interface IIdentityRepository
    {
        Task<UserModel> AddAsync(RegisterUserModel registerUserModel, CancellationToken cancellationToken);
        Task<UserAuthenicatedModel> LoginAsync(UserLoginModel userLoginModel, CancellationToken cancellationToken);
    }
}
