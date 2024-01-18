using ELC.Lite.Identity.Models.Identity;

namespace ELC.Lite.Web.Api.Identity
{
    public interface IIdentityProxy
    {
        Task<UserModel> AddAsync(RegisterUserModel registerUserModel, CancellationToken cancellationToken);
        Task<UserAuthenicatedModel> LoginAsync(UserLoginModel userLoginModel, CancellationToken cancellationToken);
        Task<bool> AddPasswordAsync(AddPasswordModel addPasswordModel, CancellationToken cancellationToken);
        Task<bool> ResetPasswordAsync(ResetPasswordModel resetPasswordModel, CancellationToken cancellationToken);
        Task LogoutAsync(CancellationToken cancellationToken);
    }
}
