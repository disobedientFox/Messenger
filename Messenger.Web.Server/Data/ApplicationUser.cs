using Microsoft.AspNetCore.Identity;

namespace Messenger.Web.Server
{
    public class ApplicationUser : IdentityUser
    {
        #region Public Properties

        public string FirstName { get; set; }

        public string LastName { get; set; }

        #endregion
    }
}
