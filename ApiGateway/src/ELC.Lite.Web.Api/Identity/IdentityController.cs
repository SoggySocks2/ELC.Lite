using ELC.Lite.Identity.Models.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ELC.Lite.Web.Api.Identity
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : BaseController
    {
        private readonly IIdentityProxy _identityProxy;

        public IdentityController(IIdentityProxy identityProxy)
        {
            _identityProxy = identityProxy;
        }

        [HttpPost]
        public async Task<ActionResult<UserModel>> AddAsync(RegisterUserModel registerUserModel, CancellationToken cancellationToken)
        {
            if (!HasClaim("Email", "peter.jones@home.com") && !IsInRole("Admin")) { return Unauthorized(); }

            var userModel = await _identityProxy.AddAsync(registerUserModel, cancellationToken);
            return Ok(userModel);
        }

        [HttpPut]
        public async Task<ActionResult<bool>> AddPasswordAsync(AddPasswordModel addPasswordModel, CancellationToken cancellationToken)
        {
            if (!HasClaim("Email", "peter.jones@home.com") && !IsInRole("Admin")) { return Unauthorized(); }

            var result = await _identityProxy.AddPasswordAsync(addPasswordModel, cancellationToken);
            return Ok(result);
        }

        [HttpPut]
        [Route("reset-password")]
        public async Task<ActionResult<bool>> ResetPasswordAsync(ResetPasswordModel resetPasswordModel, CancellationToken cancellationToken)
        {
            if (!HasClaim("Email", "peter.jones@home.com") && !IsInRole("Admin")) { return Unauthorized(); }

            var result = await _identityProxy.ResetPasswordAsync(resetPasswordModel, cancellationToken);
            return Ok(result);
        }
    }
}
