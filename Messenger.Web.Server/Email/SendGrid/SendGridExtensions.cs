using Messenger.Core;
using Microsoft.Extensions.DependencyInjection;

namespace Messenger.Web.Server
{
    public static class SendGridExtensions
    {
        public static IServiceCollection AddSendGridEmailSender(this IServiceCollection services)
        {
            // Inject the SendGridEmailSender
            services.AddTransient<IEmailSender, SendGridEmailSender>();

            // Return collection for chaining
            return services;
        }
    }
}
