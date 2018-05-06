using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Messenger.Core
{
    public class ChatMessageListDesignModel : ChatMessageListViewModel
    {
        #region Singleton

        public static ChatMessageListDesignModel Instance => new ChatMessageListDesignModel();

        #endregion


        #region Constructor

        public ChatMessageListDesignModel()
        {
            Items = new ObservableCollection<ChatMessageListItemViewModel>
            {
                new ChatMessageListItemViewModel
                {
                    SenderName = "Parnall",
                    Initials = "PL",
                    Message = "I'm about to wipethe old server. We need to update the old server to Win 2016",
                    ProfilePictureRGB = "3099c5",
                    MessageSentTime = DateTimeOffset.UtcNow,
                    SentByMe = false,
                },

                new ChatMessageListItemViewModel
                {
                    SenderName = "Luke",
                    Initials = "LM",
                    Message = "Let me know when you manage to spin up the new 2016 server",
                    ProfilePictureRGB = "3099c5",
                    MessageSentTime = DateTimeOffset.UtcNow,
                    MessageReadTime = DateTimeOffset.UtcNow.Subtract(TimeSpan.FromDays(1.3)),
                    SentByMe = true,
                },

                new ChatMessageListItemViewModel
                {
                    SenderName = "Parnall",
                    Initials = "PL",
                    Message = "The new server is up. Go to 192.168.1.1. Username is admin, password is P8ssw0rd",
                    ProfilePictureRGB = "3099c5",
                    MessageSentTime = DateTimeOffset.UtcNow,
                    SentByMe = false,
                }
            };
        }

        #endregion
    }
}
