using System;
using System.Threading.Tasks;

namespace Messenger.Core
{
    /// <summary>
    /// A view model for each chat message thread item's attachment
    /// (in this case an image) in a chat thread
    /// </summary>
    public class ChatMessageListItemImageAttachmentViewModel : BaseViewModel
    {
        #region Private Members

        private string mThumbnailUrl;

        #endregion

        public string Title { get; set; }

        public string FileName { get; set; }

        public long FileSize { get; set; }

        public string ThumbnailUrl
        {
            get => mThumbnailUrl;
            set
            {
                // If value hasn't changed, return
                if (value == mThumbnailUrl)
                    return;

                // Update value
                mThumbnailUrl = value;

                Task.Delay(2000).ContinueWith(t => LocalFilePath = "/Images/Samples/juliet.jpg");
                //LocalFilePath = "/Images/Samples/juliet.jpg";
            }
        }

        public string LocalFilePath { get; set; }
    }
}