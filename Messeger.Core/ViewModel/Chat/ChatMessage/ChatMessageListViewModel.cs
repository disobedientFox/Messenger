using System.Collections.Generic;

namespace Messenger.Core
{
    public class ChatMessageListViewModel : BaseViewModel
    {
        public List<ChatMessageListItemViewModel> Items { get; set; }
    }
}
