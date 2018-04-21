namespace Messenger.Core
{
    /// <summary>
    /// The desing-time for a <see cref="TextEntryViewModel"/>
    /// </summary>
    public class TextEntryDesignModel : TextEntryViewModel
    {
        #region Singleton

        public static TextEntryDesignModel Instance => new TextEntryDesignModel();

        #endregion

        #region Constructor

        public TextEntryDesignModel()
        {
            Label = "Name";
            OriginalText = "Alia Yarychevskaya";
            EditedText = "Editing :)";
        }

        #endregion
    }
}
