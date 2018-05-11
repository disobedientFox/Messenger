using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Messenger.Core
{
    public class ChatMessageListViewModel : BaseViewModel
    {
        #region Protected Members

        protected string mLastSearchText;

        protected string mSearchText;

        protected ObservableCollection<ChatMessageListItemViewModel> mItems;

        protected bool mSearchIsOpen;

        #endregion

        #region Public Properties

        public ObservableCollection<ChatMessageListItemViewModel> Items
        {
            get => mItems;
            set
            {
                // Make sure list has changed
                if (mItems == value)
                    return;

                // Update value
                mItems = value;

                // Update filtered list to match
                FilteredItems = new ObservableCollection<ChatMessageListItemViewModel>(mItems);
            }
        }

        public ObservableCollection<ChatMessageListItemViewModel> FilteredItems { get; set; }

        public string DisplayTitle { get; set; }

        public bool AttachmentMenuVisible { get; set; }

        public bool AnyPopupVisible => AttachmentMenuVisible;

        public ChatAttachmentPopupMenuViewModel AttachmentMenu { get; set; }

        public string PendingMessageText { get; set; }

        public string SearchText
        {
            get => mSearchText;
            set
            {
                // Check value is different
                if (mSearchText == value)
                    return;

                // Update value
                mSearchText = value;

                // If the search text is empty...
                if (string.IsNullOrEmpty(SearchText))
                    Search();
            }
        }

        public bool SearchIsOpen
        {
            get => mSearchIsOpen;
            set
            {
                // Check value has changed
                if (mSearchIsOpen == value)
                    return;

                // Update value
                mSearchIsOpen = value;
                
                if (!mSearchIsOpen)
                    SearchText = string.Empty;
            }
        }

        #endregion

        #region Public Commands

        public ICommand AttachButtonCommand { get; set; }

        public ICommand PupopClickawayCommand { get; set; }

        public ICommand SendCommand { get; set; }

        public ICommand SearchCommand { get; set; }

        public ICommand OpenSearchCommand { get; set; }

        public ICommand CloseSearchCommand { get; set; }

        public ICommand ClearSearchCommand { get; set; }

        #endregion

        #region Cunstructor

        public ChatMessageListViewModel()
        {
            AttachButtonCommand = new RelayCommand(AttachmentButton);
            PupopClickawayCommand = new RelayCommand(PopupClickaway);
            SendCommand = new RelayCommand(Send);
            SearchCommand = new RelayCommand(Search);
            OpenSearchCommand = new RelayCommand(OpenSearch);
            CloseSearchCommand = new RelayCommand(CloseSearch);
            ClearSearchCommand = new RelayCommand(ClearSearch);

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
            if (string.IsNullOrEmpty(PendingMessageText))
                return;

            if (Items == null)
                Items = new ObservableCollection<ChatMessageListItemViewModel>();

            if (FilteredItems == null)
                FilteredItems = new ObservableCollection<ChatMessageListItemViewModel>();

            var message = new ChatMessageListItemViewModel
            {
                Initials = "LM",
                Message = PendingMessageText,
                MessageSentTime = DateTime.UtcNow,
                SentByMe = true,
                SenderName = "Alia Yarychevskaya",
                NewItem = true,
            };

            Items.Add(message);
            FilteredItems.Add(message);

            PendingMessageText = string.Empty;
        }

        public void Search()
        {
            // Make sure we don't re-search the same text
            if ((string.IsNullOrEmpty(mLastSearchText) && string.IsNullOrEmpty(SearchText)) ||
                string.Equals(mLastSearchText, SearchText))
                return;

            // If we have no search text, or no items
            if (string.IsNullOrEmpty(SearchText) || Items == null || Items.Count <= 0)
            {
                FilteredItems = new ObservableCollection<ChatMessageListItemViewModel>(Items);
                
                mLastSearchText = SearchText;

                return;
            }

            FilteredItems = new ObservableCollection<ChatMessageListItemViewModel>(
                Items.Where(item => item.Message.ToLower().Contains(SearchText)));

            // Set last search text
            mLastSearchText = SearchText;
        }

        public void ClearSearch()
        {
            if (!string.IsNullOrEmpty(SearchText))
                SearchText = string.Empty;
            else
                SearchIsOpen = false;
        }

        public void OpenSearch() => SearchIsOpen = true;

        public void CloseSearch() => SearchIsOpen = false;

    #endregion
}

}
