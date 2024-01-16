using ELC.Lite.Identity.Models.Identity;

namespace ELC.Lite.Web.Api.Identity
{
    public interface IIdentityProxy
    {
        Task<UserModel> AddAsync(RegisterUserModel registerUserModel, CancellationToken cancellationToken);
        Task<UserAuthenicatedModel> LoginAsync(UserLoginModel userLoginModel, CancellationToken cancellationToken);
    }
}
