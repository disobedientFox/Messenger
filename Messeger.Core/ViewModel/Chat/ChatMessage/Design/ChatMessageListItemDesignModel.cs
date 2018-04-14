using System;

namespace Messenger.Core
{
    public class ChatMessageListItemDesignModel : ChatMessageListItemViewModel
    {
        #region Singleton

        public static ChatMessageListItemDesignModel Instanse => new ChatMessageListItemDesignModel(); 

        #endregion


        #region Constructor

        public ChatMessageListItemDesignModel()
        {
            Initials = "LM";
            SenderName = "Luke";
            Message = "This new chat app is awesome! I bet it will be faaat too";
            ProfilePictureRGB = "5BBFB7";

            SentByMe = true;
            MessageSentTime = DateTimeOffset.UtcNow;
            MessageReadTime = DateTimeOffset.UtcNow.Subtract(TimeSpan.FromDays(1.3));
        }

        #endregion
    }
}
