using Messenger.Core;
using System.Threading.Tasks;
using static Dna.FrameworkDI;

namespace Messenger.Web.Server
{
    public class MessengerEmailSender
    {
        public static async Task<SendEmailResponse> SendUserVerificationEmailAsync(string displayName, string email, string verificationUrl)
        {
            return await DI.EmailTemplateSender.SendGeneralEmailAsync(new SendEmailDetails
            {
                IsHTML = true,
                FromEmail = Configuration["MessengerSettings:SendEmailFromEmail"],
                FromName = Configuration["MessengerSettings:SendEmailFromName"],
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
