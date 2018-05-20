using Messenger.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Messenger.Web.Server
{
    public static class IoC
    {

        public static ApplicationDbContext ApplicationDbContext => IoCContainer.Provider.GetService<ApplicationDbContext>();

        public static IEmailSender EmailSender => IoCContainer.Provider.GetService<IEmailSender>();

        public static IEmailTemplateSender EmailTemplateSender => IoCContainer.Provider.GetService<IEmailTemplateSender>();
    }

    public static class IoCContainer
    {

        public static ServiceProvider Provider { get; set; }

        public static IConfiguration Configuration { get; set; }
    }
}
