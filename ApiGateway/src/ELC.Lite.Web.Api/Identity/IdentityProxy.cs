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
    }
}
