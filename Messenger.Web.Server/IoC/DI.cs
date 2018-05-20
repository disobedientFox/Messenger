using Dna;
using Messenger.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Messenger.Web.Server
{
    public static class DI
    {

        public static ApplicationDbContext ApplicationDbContext => Framework.Provider.GetService<ApplicationDbContext>();

        public static IEmailSender EmailSender => Framework.Provider.GetService<IEmailSender>();

        public static IEmailTemplateSender EmailTemplateSender => Framework.Provider.GetService<IEmailTemplateSender>();
    }
}
