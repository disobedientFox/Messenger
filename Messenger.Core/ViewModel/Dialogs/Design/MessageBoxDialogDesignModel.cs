namespace Messenger.Core
{
    /// <summary>
    /// The desing-time for a <see cref="MessageBoxDialogDesignModel"/>
    /// </summary>
    public class MessageBoxDialogDesignModel : MessageBoxDialogViewModel
    {
        #region Singleton

        public static MessageBoxDialogDesignModel Instance => new MessageBoxDialogDesignModel();

        #endregion

        #region Constructor

        public MessageBoxDialogDesignModel()
        {
            OkText = "OK";
            Message = "Design time messages are fun :)";
        }

        #endregion
    }
}
