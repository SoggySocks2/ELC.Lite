using ELC.Lite.Identity.Infrastructure.Identities;
using ELC.Lite.Identity.Models.Identity;
using ELC.Lite.SharedKernel.Exceptions.Helpers;

namespace ELC.Lite.Identity.Api.Identities
{
    public class IdentityService : IIdentityService
    {
        private readonly IIdentityRepository _identityRepository;

        public IdentityService(IIdentityRepository identityRepository)
        {
            _identityRepository = identityRepository;
        }

        public async Task<UserModel> AddAsync(RegisterUserModel registerUserModel, CancellationToken cancellationToken)
        {
            Check.For.Null(registerUserModel);

            var userModel = await _identityRepository.AddAsync(registerUserModel, cancellationToken);

            return userModel;
        }

        public async Task<UserAuthenicatedModel> LoginAsync(UserLoginModel userLoginModel, CancellationToken cancellationToken)
        {
            Check.For.Null(userLoginModel);

            var userAuthenicatedModel = await _identityRepository.LoginAsync(userLoginModel, cancellationToken);

            return userAuthenicatedModel;
        }

        public async Task<bool> AddPasswordAsync(AddPasswordModel addPasswordModel, CancellationToken cancellationToken)
        {
            Check.For.Null(addPasswordModel);

            var result = await _identityRepository.AddPasswordAsync(addPasswordModel, cancellationToken);

            return result;
        }

        public async Task<bool> ResetPasswordAsync(ResetPasswordModel resetPasswordModel, CancellationToken cancellationToken)
        {
            Check.For.Null(resetPasswordModel);

            var result = await _identityRepository.ResetPasswordAsync(resetPasswordModel, cancellationToken);

            return result;
        }

        public async Task LogoutAsync(CancellationToken cancellationToken)
        {
            await _identityRepository.LogoutAsync(cancellationToken);
        }
    }
}
