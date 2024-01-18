using ELC.Lite.Identity.Api.Identities;
using ELC.Lite.Identity.Models.Identity;

namespace ELC.Lite.Web.Api.Identity
{
    public class IdentityProxy : IIdentityProxy
    {
        private readonly IIdentityService _identityService;

        public IdentityProxy(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public Task<UserModel> AddAsync(RegisterUserModel registerUserModel, CancellationToken cancellationToken)
            => _identityService.AddAsync(registerUserModel, cancellationToken);

        public Task<UserAuthenicatedModel> LoginAsync(UserLoginModel userLoginModel, CancellationToken cancellationToken)
            => _identityService.LoginAsync(userLoginModel, cancellationToken);

        public Task<bool> AddPasswordAsync(AddPasswordModel addPasswordModel, CancellationToken cancellationToken)
            => _identityService.AddPasswordAsync(addPasswordModel, cancellationToken);

        public Task<bool> ResetPasswordAsync(ResetPasswordModel resetPasswordModel, CancellationToken cancellationToken)
            => _identityService.ResetPasswordAsync(resetPasswordModel, cancellationToken);

        public Task LogoutAsync(CancellationToken cancellationToken)
            => _identityService.LogoutAsync(cancellationToken);
    }
}
