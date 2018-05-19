using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace Messenger.Web.Server
{
    public class AuthorizeTokenAttribute : AuthorizeAttribute
    {
        #region Constructor

        public AuthorizeTokenAttribute()
        {
            // Add the JWT bearer authentication scheme
            AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme;
        }

        #endregion
    }
}
