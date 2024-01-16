using ELC.Lite.Identity.Models.Identity;
using Microsoft.AspNetCore.Identity;

namespace ELC.Lite.Identity.Infrastructure.Identities
{
    public class IdentityRepository : IIdentityRepository
    {
        //private readonly SignInManager<ElcUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUserStore<IdentityUser> _userStore;
        private readonly IUserEmailStore<IdentityUser> _emailStore;
        //private readonly ElcIdentityDbContext _dbContext;

        public IdentityRepository(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, IUserStore<IdentityUser> userStore)
        {
            //_signInManager = signInManager;
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            //_dbContext = dbContext;
        }

        public async Task<UserModel> AddAsync(RegisterUserModel registerUserModel, CancellationToken cancellationToken)
        {
            var user = CreateUser();

            await _userStore.SetUserNameAsync(user, registerUserModel.Email, CancellationToken.None);
            await _emailStore.SetEmailAsync(user, registerUserModel.Email, CancellationToken.None);
            var result = await _userManager.CreateAsync(user, registerUserModel.Password);

            var userModel = new UserModel();
            if (result.Succeeded)
            {
                var userId = await _userManager.GetUserIdAsync(user);
                userModel.Id = userId;
                userModel.Email = registerUserModel.Email;
                userModel.TelNo = registerUserModel.TelNo;
            }

            return userModel;
        }

        private IdentityUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<IdentityUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(IdentityUser)}'. " +
                    $"Ensure that '{nameof(IdentityUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }

        private IUserEmailStore<IdentityUser> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<IdentityUser>)_userStore;
        }
    }
}
