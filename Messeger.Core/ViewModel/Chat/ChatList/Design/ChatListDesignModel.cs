using System.Collections.Generic;
namespace Messenger.Core
{
    public class ChatListDesignModel : ChatListViewModel
    {
        #region Singleton

        public static ChatListDesignModel Instance => new ChatListDesignModel();

        #endregion


        #region Constructor

        public ChatListDesignModel()
        {
            Items = new List<ChatListItemViewModel>
            {
                new ChatListItemViewModel
                {
                    Initials = "LM",
                    Name = "Luke",
                    Message = "This new chat app is awesome! I bet it will be faaat too",
                    ProfilePictureRGB = "5BBFB7",
                    NewContentAvailable = true
                },
                new ChatListItemViewModel
                {
                    Initials = "JA",
                    Name = "Jesse",
                    Message = "Hey dude!",
                    ProfilePictureRGB = "fe4503",
                    IsSelected = true
                },
                new ChatListItemViewModel
                {
                    Initials = "PL",
                    Name = "Parnell",
                    Message = "The new serser is up, got 192.0.18.20",
                    ProfilePictureRGB = "00d405",
                    NewContentAvailable = true
                },
                new ChatListItemViewModel
                {
                    Initials = "LM",
                    Name = "Luke",
                    Message = "This new chat app is awesome! I bet it will be faaat too",
                    ProfilePictureRGB = "5BBFB7"
                },
                new ChatListItemViewModel
                {
                    Initials = "JA",
                    Name = "Jesse",
                    Message = "Hey dude!",
                    ProfilePictureRGB = "fe4503"
                },
                new ChatListItemViewModel
                {
                    Initials = "PL",
                    Name = "Parnell",
                    Message = "The new serser is up, got 192.0.18.20",
                    ProfilePictureRGB = "00d405"
                },
                new ChatListItemViewModel
                {
                    Initials = "LM",
                    Name = "Luke",
                    Message = "This new chat app is awesome! I bet it will be faaat too",
                    ProfilePictureRGB = "5BBFB7"
                },
                new ChatListItemViewModel
                {
                    Initials = "JA",
                    Name = "Jesse",
                    Message = "Hey dude!",
                    ProfilePictureRGB = "fe4503"
                },
                new ChatListItemViewModel
                {
                    Initials = "PL",
                    Name = "Parnell",
                    Message = "The new serser is up, got 192.0.18.20",
                    ProfilePictureRGB = "00d405"
                },
            };
        }

        #endregion
    }
}
