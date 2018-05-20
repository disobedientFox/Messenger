using Messenger.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using static Dna.FrameworkDI;

namespace Messenger.Web.Server
{
    public class ApiController : Controller
    {
        #region Protected Member

        protected ApplicationDbContext mContext;
        protected UserManager<ApplicationUser> mUserManager;
        protected SignInManager<ApplicationUser> mSignInManager;

        #endregion

        #region Constructor

        public ApiController(ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            mContext = context;
            mUserManager = userManager;
            mSignInManager = signInManager;
        }

        #endregion

        [Route("api/register")]
        public async Task<ApiResponse<RegisterResultApiModel>> RegisterAsync([FromBody]RegisterCredentialsApiModel registerCredentials)
        {
            var invalidErrorMessage = "Please provide all required details to register for an account";
            
            var errorResponse = new ApiResponse<RegisterResultApiModel>
            {
                ErrorMessage = invalidErrorMessage
            };
            
            if (registerCredentials == null)
                return errorResponse;
            
            if (string.IsNullOrWhiteSpace(registerCredentials.Username))
                return errorResponse;
            
            var user = new ApplicationUser
            {
                UserName = registerCredentials.Username,
                FirstName = registerCredentials.FirstName,
                LastName = registerCredentials.LastName,
                Email = registerCredentials.Email
            };

            // Try and create a user
            var result = await mUserManager.CreateAsync(user, registerCredentials.Password);
            
            if (result.Succeeded)
            {
                var userIdentity = await mUserManager.FindByNameAsync(registerCredentials.Username);
                
                var emailVerificationCode = await mUserManager.GenerateEmailConfirmationTokenAsync(user);
                
                var confirmationUrl = $"http://{Request.Host.Value}/api/verify/email/{HttpUtility.UrlEncode(userIdentity.Id)}/{HttpUtility.UrlEncode(emailVerificationCode)}";
                
                await MessengerEmailSender.SendUserVerificationEmailAsync(user.UserName, userIdentity.Email, confirmationUrl);
                
                return new ApiResponse<RegisterResultApiModel>
                {
                    Response = new RegisterResultApiModel
                    {
                        FirstName = userIdentity.FirstName,
                        LastName = userIdentity.LastName,
                        Email = userIdentity.Email,
                        Username = userIdentity.UserName,
                        Token = userIdentity.GenerateJwtToken()
                    }
                };
            }
            else
                return new ApiResponse<RegisterResultApiModel>
                {
                    ErrorMessage = result.Errors?.ToList()
                        .Select(f => f.Description)
                        .Aggregate((a, b) => $"{a}{Environment.NewLine}{b}")
                };
        }

        [Route("api/login")]
        public async Task<ApiResponse<LoginResultApiModel>> LogIn([FromBody]LoginCredentialsApiModel loginCredentials)
        {
            var invalidErrorMessage = "Invalid username or password";

            var errorResponse = new ApiResponse<LoginResultApiModel>
            {
                ErrorMessage = invalidErrorMessage
            };

            if (loginCredentials?.UsernameOrEmail == null || string.IsNullOrWhiteSpace(loginCredentials.UsernameOrEmail))
                return errorResponse;

            var isEmail = loginCredentials.UsernameOrEmail.Contains("@");
            var user = isEmail ?
                await mUserManager.FindByEmailAsync(loginCredentials.UsernameOrEmail) :
                await mUserManager.FindByNameAsync(loginCredentials.UsernameOrEmail);

            if (user == null)
                return errorResponse;

            var isValidPassword = await mUserManager.CheckPasswordAsync(user, loginCredentials.Password);
            if (!isValidPassword)
                return errorResponse;

            var username = user.UserName;

            var claims = new[]
            {
                // Unique ID for this token
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),

                // The username using the Identity name so it fills out the HttpContext.User.Identity.Name value
                new Claim(ClaimsIdentity.DefaultNameClaimType, username),
            };

            // Create the credentials used to generate the token
            var credentials = new SigningCredentials(
                                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:SecretKey"])),
                                    SecurityAlgorithms.HmacSha256);

            // Generate the Jwt Token
            var token = new JwtSecurityToken(
                            issuer: Configuration["Jwt:Issuer"],
                            audience: Configuration["Jwt:Audience"],
                            claims: claims,
                            signingCredentials: credentials,
                            expires: DateTime.Now.AddMonths(3)
                );

            // Return token to user
            return new ApiResponse<LoginResultApiModel>
            {
                Response = new LoginResultApiModel
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Username = user.UserName,
                    Token = new JwtSecurityTokenHandler().WriteToken(token)
                }
            };
        }

        [Route("api/verify/email/{userId}/{emailToken}")]
        [HttpGet]
        public async Task<ActionResult> VerifyEmailAsync(string userId, string emailToken)
        {
            // Get the user
            var user = await mUserManager.FindByIdAsync(userId);

            emailToken = emailToken.Replace("%2f", "/").Replace("%2F", "/");
            
            if (user == null)
                return Content("User not found");
            

            // Verify the email token
            var result = await mUserManager.ConfirmEmailAsync(user, emailToken);

            // If succeeded...
            if (result.Succeeded)
                return Content("Email Verified :)");
            
            return Content("Invalid Email Verification Token :(");
        }

        /// <summary>
        /// Test private area for token-based authentication
        /// </summary>
        /// <returns></returns>
        [AuthorizeToken]
        [Route("api/private")]
        public IActionResult Private()
        {
            // Get the authenticated user
            var user = HttpContext.User;

            // Tell them a secret
            return Ok(new { privateData = $"some secret for {user.Identity.Name}" });
        }
    }
}
