using Messenger.Core;

namespace Messenger
{
    /// <summary>
    /// Логика взаимодействия для ChatPage.xaml
    /// </summary>
    public partial class ChatPage : BasePage<ChatMessageListViewModel>
    {
        public ChatPage() : base()
        {
            InitializeComponent();
        }

        public ChatPage(ChatMessageListViewModel specificViewModel = null) : base(specificViewModel)
        {
            InitializeComponent();
        }
    }
}
