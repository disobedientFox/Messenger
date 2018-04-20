namespace Messenger.Core
{
    /// <summary>
    /// Details for a message box dialog
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
