using System.Collections.Generic;

namespace Messenger.Core
{
    public class ChatListViewModel : BaseViewModel
    {
        public List<ChatListItemViewModel> Items { get; set; }
    }
}
