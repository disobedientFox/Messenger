using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Messenger.Web.Server
{
    public class ApiController : Controller
    {
        [Route("api/login")]
        public IActionResult LogIn()
        {
            var username = "Juliet";
            
            var claims = new[]
            {
                // Unique ID for this token
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),

                // The username using the Identity name so it fills out the HttpContext.User.Identity.Name value
                new Claim(ClaimsIdentity.DefaultNameClaimType, username),
            };

            // Create the credentials used to generate the token
            var credentials = new SigningCredentials(
                                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(IoCContainer.Configuration["Jwt:SecretKey"])),
                                    SecurityAlgorithms.HmacSha256);

            // Generate the Jwt Token
            var token = new JwtSecurityToken(
                            issuer: IoCContainer.Configuration["Jwt:Issuer"],
                            audience: IoCContainer.Configuration["Jwt:Audience"],
                            claims: claims,
                            signingCredentials: credentials,
                            expires: DateTime.Now.AddMonths(3)
                );

            // Return token to user
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
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
