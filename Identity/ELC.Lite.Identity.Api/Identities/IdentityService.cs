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
    }
}
