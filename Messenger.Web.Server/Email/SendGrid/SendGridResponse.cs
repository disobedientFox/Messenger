using System.Collections.Generic;

namespace Messenger.Web.Server
{
    public class SendGridResponse
    {
        public List<SendGridResponseError> Errors { get; set; }
    }
}
