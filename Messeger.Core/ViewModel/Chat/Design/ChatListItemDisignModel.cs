namespace Messenger.Core
{
    public class ChatListItemDisignModel : ChatListItemViewModel
    {
        #region Singleton

        public static ChatListItemDisignModel Instanse => new ChatListItemDisignModel(); 

        #endregion


        #region Constructor

        public ChatListItemDisignModel()
        {
            Initials = "LM";
            Name = "Luke";
            Messege = "This new chat app is awesome! I bet it will be faaat too";
            ProfilePictureRGB = "5BBFB7";
        }

        #endregion
    }
}
