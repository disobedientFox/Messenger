using System.Collections.Generic;

namespace Messenger.Core
{

	public class SendEmailResponse
    {

        public bool Successful => !(Errors?.Count > 0);

        public List<string> Errors { get; set; }
    }
}