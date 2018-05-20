using Messenger.Core;
using System.Threading.Tasks;

namespace Messenger.Web.Server
{
    public class MessengerEmailSender
    {
        public static async Task<SendEmailResponse> SendUserVerificationEmailAsync(string displayName, string email, string verificationUrl)
        {
            return await IoC.EmailTemplateSender.SendGeneralEmailAsync(new SendEmailDetails
            {
                IsHTML = true,
                FromEmail = IoCContainer.Configuration["MessengerSettings:SendEmailFromEmail"],
                FromName = IoCContainer.Configuration["MessengerSettings:SendEmailFromName"],
                ToEmail = email,
                ToName = displayName,
                Subject = "Verify Your Email - Messenger"
            },
            "Verify Email",
            $"Hi {displayName ?? "stranger"},",
            "Thanks for creating an account with us.<br/>To continue please verify your email with us.",
            "Verify Email",
            verificationUrl
            );
        }
    }
}
