using ELC.Lite.Identity.Models.Identity;

namespace ELC.Lite.Identity.Api.Identities
{
    public interface IIdentityService
    {
        Task<UserModel> AddAsync(RegisterUserModel registerUserModel, CancellationToken cancellationToken);
    }
}
