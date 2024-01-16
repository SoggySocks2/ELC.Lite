using ELC.Lite.Identity.Models.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ELC.Lite.Web.Api.Identity
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
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
    }
}
