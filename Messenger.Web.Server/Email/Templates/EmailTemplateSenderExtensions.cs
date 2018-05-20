using Messenger.Core;
using Microsoft.Extensions.DependencyInjection;

namespace Messenger.Web.Server
{
    public static class EmailTemplateSenderExtensions
    {
        public static IServiceCollection AddEmailTemplateSender(this IServiceCollection services)
        {
            // Inject the SendGridEmailSender
            services.AddTransient<IEmailTemplateSender, EmailTemplateSender>();

            // Return collection for chaining
            return services;
        }
}
}
