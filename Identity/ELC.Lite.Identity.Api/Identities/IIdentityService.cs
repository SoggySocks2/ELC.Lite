using ELC.Lite.Identity.Models.Identity;

namespace ELC.Lite.Identity.Api.Identities
{
    public interface IIdentityService
    {
        Task<UserModel> AddAsync(RegisterUserModel registerUserModel, CancellationToken cancellationToken);
        Task<UserAuthenicatedModel> LoginAsync(UserLoginModel userLoginModel, CancellationToken cancellationToken);
        Task<bool> AddPasswordAsync(AddPasswordModel addPasswordModel, CancellationToken cancellationToken);
        Task<bool> ResetPasswordAsync(ResetPasswordModel resetPasswordModel, CancellationToken cancellationToken);
        Task LogoutAsync(CancellationToken cancellationToken);
    }
}
