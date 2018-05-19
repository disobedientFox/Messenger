using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Messenger.Web.Server.Controllers
{
    public class HomeController : Controller
    {
        #region Protected Member

        protected ApplicationDbContext mContext;
        protected UserManager<ApplicationUser> mUserManager;
        protected SignInManager<ApplicationUser> mSignInManager;

        #endregion

        #region Constructor

        public HomeController(ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            mContext = context;
            mUserManager = userManager;
            mSignInManager = signInManager;
        }

        #endregion

        public IActionResult Index()
        {
            mContext.Database.EnsureCreated();

            if (!mContext.Settings.Any())
            {

                mContext.Settings.Add(new SettingsDataModel
                {
                    Name = "BackgroundColor",
                    Value = "Red"
                });

                //var settingsLocally = mContext.Settings.Local.Count();
                //var settingsDatabase = mContext.Settings.Count();

                //var firstLocal = mContext.Settings.Local.First();
                //var firstDatabase = mContext.Settings.First();

                mContext.SaveChanges();

            }

            return View();
        }

        [Route("create")]
        public async Task<IActionResult> CreateUser()
        {
            var result = await mUserManager.CreateAsync(new ApplicationUser
            {
                UserName = "Juliet",
                Email = "contact@me.com"
            }, "password");

            if (result.Succeeded)
                return Content("User was created", "text/html");

            return Content("User creation failed", "text/html");
        }

        [Authorize]
        [Route("private")]
        public IActionResult Private()
        {
            return Content($"This is a private area. Welcome {HttpContext.User.Identity.Name}", "text/html");
        }

        [Route("login")]
        public async Task<IActionResult> Login(string returnUrl)
        {
            await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);

            var result = await mSignInManager.PasswordSignInAsync("Juliet", "password", true, false);

            if (result.Succeeded)
            {

                if (string.IsNullOrEmpty(returnUrl))
                    return RedirectToAction(nameof(Index));

                return Redirect(returnUrl);
            }
            return Content("Falied to login", "text/html");
        }

        [Route("logout")]
        public async Task<IActionResult> SignOut(string returnUrl)
        {
            await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);

            return Content("done");
        }
    }
}
