namespace Messenger.Core
{
    public class ChatListItemDesignModel : ChatListItemViewModel
    {
        #region Singleton

        public static ChatListItemDesignModel Instance => new ChatListItemDesignModel(); 

        #endregion


        #region Constructor

        public ChatListItemDesignModel()
        {
            Initials = "LM";
            Name = "Luke";
            Message = "This new chat app is awesome! I bet it will be faaat too";
            ProfilePictureRGB = "5BBFB7";
        }

        #endregion
    }
}
