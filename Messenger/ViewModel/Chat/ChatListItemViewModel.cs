namespace Messenger
{
    class ChatListItemViewModel : BaseViewModel
    {
        public string Name { get; set; }

        public string Messege { get; set; }

        public string Initials { get; set; }

        public string ProfilePictureRGB { get; set; }

        public bool NewContentAvailable { get; set; }

        public bool IsSelected { get; set; }
    }
}
