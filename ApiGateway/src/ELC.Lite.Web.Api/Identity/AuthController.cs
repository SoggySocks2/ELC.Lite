using ELC.Lite.Identity.Models.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ELC.Lite.Web.Api.Identity
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        private readonly IIdentityProxy _identityProxy;

        public AuthController(IIdentityProxy identityProxy)
        {
            _identityProxy = identityProxy;
        }

        [HttpPost]
        public async Task<UserAuthenicatedModel> LoginAsync(UserLoginModel loginModel, CancellationToken cancellationToken)
        {
            return await _identityProxy.LoginAsync(loginModel, cancellationToken);
        }

        [HttpPost("logout")]
        public async Task LogoutAsync(CancellationToken cancellationToken)
        {
            await _identityProxy.LogoutAsync(cancellationToken);
        }
    }
}
