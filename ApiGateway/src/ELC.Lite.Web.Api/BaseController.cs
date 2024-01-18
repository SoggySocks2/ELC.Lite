using Microsoft.AspNetCore.Mvc;

namespace ELC.Lite.Web.Api
{
    public class BaseController : ControllerBase
    {
        protected BaseController() { }


        protected bool HasClaim(string claimType, string value)
        {
            return User.Claims.FirstOrDefault(x => x.Type == claimType && x.Value.Equals(value, StringComparison.InvariantCultureIgnoreCase)) != null;
        }
        protected bool IsInRole(string requiredClaim)
        {
            return User.IsInRole(requiredClaim);
        }
    }
}
