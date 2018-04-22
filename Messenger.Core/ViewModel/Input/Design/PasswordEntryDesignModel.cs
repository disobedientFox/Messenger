namespace Messenger.Core
{
    /// <summary>
    /// The desing-time for a <see cref="PasswordEntryDesignModel"/>
    /// </summary>
    public class PasswordEntryDesignModel : PasswordEntryViewModel
    {
        #region Singleton

        public static PasswordEntryDesignModel Instance => new PasswordEntryDesignModel();

        #endregion

        #region Constructor

        public PasswordEntryDesignModel()
        {
            Label = "Name";
            FakePassword = "********";
        }

        #endregion
    }
}
