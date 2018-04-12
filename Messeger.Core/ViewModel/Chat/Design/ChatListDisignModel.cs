using System.Collections.Generic;
namespace Messenger.Core
{
    public class ChatListDisignModel : ChatListViewModel
    {
        #region Singleton

        public static ChatListDisignModel Instanse => new ChatListDisignModel();

        #endregion


        #region ConstructoInstanser

        public ChatListDisignModel()
        {
            Items = new List<ChatListItemViewModel>
            {
                new ChatListItemViewModel
                {
                    Initials = "LM",
                    Name = "Luke",
                    Messege = "This new chat app is awesome! I bet it will be faaat too",
                    ProfilePictureRGB = "5BBFB7",
                    NewContentAvailable = true
                },
                new ChatListItemViewModel
                {
                    Initials = "JA",
                    Name = "Jesse",
                    Messege = "Hey dude!",
                    ProfilePictureRGB = "fe4503",
                    IsSelected = true
                },
                new ChatListItemViewModel
                {
                    Initials = "PL",
                    Name = "Parnell",
                    Messege = "The new serser is up, got 192.0.18.20",
                    ProfilePictureRGB = "00d405",
                    NewContentAvailable = true
                },
                new ChatListItemViewModel
                {
                    Initials = "LM",
                    Name = "Luke",
                    Messege = "This new chat app is awesome! I bet it will be faaat too",
                    ProfilePictureRGB = "5BBFB7"
                },
                new ChatListItemViewModel
                {
                    Initials = "JA",
                    Name = "Jesse",
                    Messege = "Hey dude!",
                    ProfilePictureRGB = "fe4503"
                },
                new ChatListItemViewModel
                {
                    Initials = "PL",
                    Name = "Parnell",
                    Messege = "The new serser is up, got 192.0.18.20",
                    ProfilePictureRGB = "00d405"
                },
                new ChatListItemViewModel
                {
                    Initials = "LM",
                    Name = "Luke",
                    Messege = "This new chat app is awesome! I bet it will be faaat too",
                    ProfilePictureRGB = "5BBFB7"
                },
                new ChatListItemViewModel
                {
                    Initials = "JA",
                    Name = "Jesse",
                    Messege = "Hey dude!",
                    ProfilePictureRGB = "fe4503"
                },
                new ChatListItemViewModel
                {
                    Initials = "PL",
                    Name = "Parnell",
                    Messege = "The new serser is up, got 192.0.18.20",
                    ProfilePictureRGB = "00d405"
                },
            };
        }

        #endregion
    }
}
