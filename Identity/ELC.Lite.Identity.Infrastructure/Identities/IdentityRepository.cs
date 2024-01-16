using ELC.Lite.Identity.Models.Identity;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ELC.Lite.Identity.Infrastructure.Identities
{
    public class IdentityRepository : IIdentityRepository
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUserStore<IdentityUser> _userStore;
        private readonly IUserEmailStore<IdentityUser> _emailStore;

        public IdentityRepository(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, IUserStore<IdentityUser> userStore)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
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

        public async Task<UserAuthenicatedModel> LoginAsync(UserLoginModel userLoginModel, CancellationToken cancellationToken)
        {
            var userAuthenicatedModel = new UserAuthenicatedModel();
            var result = await _signInManager.PasswordSignInAsync(userLoginModel.Email, userLoginModel.Password, userLoginModel.RememberMe, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByEmailAsync(userLoginModel.Email);

                if (user != null && await _userManager.CheckPasswordAsync(user, userLoginModel.Password))
                {
                    var userRoles = await _userManager.GetRolesAsync(user);

                    var authClaims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.UserName ?? string.Empty),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    };

                    foreach (var userRole in userRoles)
                    {
                        authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                    }

                    var token = await _userManager.GenerateUserTokenAsync(user, "Default", "Login");

                    userAuthenicatedModel.Email = user.Email ?? string.Empty;
                    userAuthenicatedModel.Token = token;
                }
            }

            return userAuthenicatedModel;
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
