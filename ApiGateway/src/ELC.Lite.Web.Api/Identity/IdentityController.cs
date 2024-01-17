using ELC.Lite.Identity.Models.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ELC.Lite.Web.Api.Identity
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IIdentityProxy _identityProxy;

        public IdentityController(IIdentityProxy identityProxy)
        {
            _identityProxy = identityProxy;
        }

        [HttpPost]
        public async Task<UserModel> AddAsync(RegisterUserModel registerUserModel, CancellationToken cancellationToken)
        {
            return await _identityProxy.AddAsync(registerUserModel, cancellationToken);
        }

        [HttpPut]
        public async Task<bool> AddPasswordAsync(AddPasswordModel addPasswordModel, CancellationToken cancellationToken)
        {
            return await _identityProxy.AddPasswordAsync(addPasswordModel, cancellationToken);
        }

        [HttpPut]
        [Route("reset-password")]
        public async Task<bool> ResetPasswordAsync(ResetPasswordModel resetPasswordModel, CancellationToken cancellationToken)
        {
            return await _identityProxy.ResetPasswordAsync(resetPasswordModel, cancellationToken);
        }
    }
}
