using System.Threading.Tasks;

namespace Messenger.Core
{ 
	public interface IEmailSender
	{
        Task<SendEmailResponse> SendEmailAsync(SendEmailDetails details);
    }
}