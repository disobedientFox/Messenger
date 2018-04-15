using System.Collections.Generic;
using System.Windows.Input;

namespace Messenger.Core
{
    public class ChatMessageListViewModel : BaseViewModel
    {
        #region Public Properties

        public List<ChatMessageListItemViewModel> Items { get; set; }

        public bool AttachmentMenuVisible { get; set; }

        public bool AnyPopupVisible => AttachmentMenuVisible;

        public ChatAttachmentPopupMenuViewModel AttachmentMenu { get; set; }

        #endregion

        #region Public Commands

        public ICommand AttachButtonCommand { get; set; }

        public ICommand PupopClickawayCommand { get; set; }

        #endregion

        #region Cunstructor

        public ChatMessageListViewModel()
        {
            AttachButtonCommand = new RelayCommand(AttachmentButton);
            PupopClickawayCommand = new RelayCommand(PopupClickaway);

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

        #endregion
    }

}
