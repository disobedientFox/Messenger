using System;
using Dna;
using System.Text;
using Messenger.Core;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Dna.AspNet;
using static Dna.FrameworkDI;

namespace Messenger.Web.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSendGridEmailSender();
            
            services.AddEmailTemplateSender();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Framework.Construction.Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication().
                AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateIssuerSigningKey = true,
                        ValidateLifetime = true,
                        ValidIssuer = Framework.Construction.Configuration["Jwt:Issuer"],
                        ValidAudience = Framework.Construction.Configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Framework.Construction.Configuration["Jwt:SecretKey"]))
                    };
                });

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 5;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/login";
                options.ExpireTimeSpan = TimeSpan.FromSeconds(15);
            });

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            app.UseDnaFramework();
            

            app.UseAuthentication();

            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{moreInfo?}");
            });

            //IoCContainer.Provider.GetService<IEmailTemplateSender>().SendGeneralEmailAsync(new SendEmailDetails
            DI.EmailTemplateSender.SendGeneralEmailAsync(new SendEmailDetails
            {
                Content = "This is our first HTML email <b>with some bold text</b>",
                IsHTML = true,
                FromEmail = "secret@website.com",
                ToEmail = "w57047@student.wsiz.rzeszow.pl",
                FromName = "Some girl",
                ToName = "Alia",
                Subject = "This is sent from my App"
            }, "Verify email",
            "Hi, Alia",
            "Thanks for creating an account with us.<br/> To continue please verify your email with us.",
            "Verify email",
            "http://www.google.com");
        }
        
    }
}
