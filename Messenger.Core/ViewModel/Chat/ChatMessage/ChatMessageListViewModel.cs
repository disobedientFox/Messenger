using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Messenger.Core
{
    public class ChatMessageListViewModel : BaseViewModel
    {
        #region Public Properties

        public ObservableCollection<ChatMessageListItemViewModel> Items { get; set; }

        public bool AttachmentMenuVisible { get; set; }

        public bool AnyPopupVisible => AttachmentMenuVisible;

        public ChatAttachmentPopupMenuViewModel AttachmentMenu { get; set; }

        public string PendingMessageText { get; set; }

        #endregion

        #region Public Commands

        public ICommand AttachButtonCommand { get; set; }

        public ICommand PupopClickawayCommand { get; set; }

        public ICommand SendCommand { get; set; }

        #endregion

        #region Cunstructor

        public ChatMessageListViewModel()
        {
            AttachButtonCommand = new RelayCommand(AttachmentButton);
            PupopClickawayCommand = new RelayCommand(PopupClickaway);
            SendCommand = new RelayCommand(Send);

            AttachmentMenu = new ChatAttachmentPopupMenuViewModel();
        }

        #endregion

        #region Command Methods

        public void AttachmentButton()
        {
            AttachmentMenuVisible ^= true;
        }

        public void PopupClickaway()
        {
            AttachmentMenuVisible = false;
        }

        public void Send()
        {
            if (PendingMessageText == string.Empty)
                return;

            if (Items == null)
                Items = new ObservableCollection<ChatMessageListItemViewModel>();

            Items.Add(new ChatMessageListItemViewModel
            {
                Initials = "LM",
                Message = PendingMessageText,
                MessageSentTime = DateTime.UtcNow,
                SentByMe = true,
                SenderName = "Alia Yarychevskaya",
                NewItem = true,
            });

            PendingMessageText = string.Empty;
        }

        #endregion
    }

}
