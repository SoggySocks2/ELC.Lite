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
    }
}
