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
        public async Task<ActionResult<UserAuthenicatedModel>> LoginAsync(UserLoginModel loginModel, CancellationToken cancellationToken)
        {
            var userAuthenicatedModel = await _identityProxy.LoginAsync(loginModel, cancellationToken);
            if (string.IsNullOrEmpty(userAuthenicatedModel.Token)) { return Unauthorized(); }

            return Ok(userAuthenicatedModel);
        }

        [HttpPost("logout")]
        public async Task LogoutAsync(CancellationToken cancellationToken)
        {
            await _identityProxy.LogoutAsync(cancellationToken);
        }
    }
}
