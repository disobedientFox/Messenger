using System.Collections.Generic;
namespace Messenger.Core
{
    public class SettingsDesignModel : SettingsViewModel
    {
        #region Singleton

        public static SettingsDesignModel Instance => new SettingsDesignModel();

        #endregion


        #region Constructor

        public SettingsDesignModel()
        {
            Name = new TextEntryViewModel { Label = "Name", OriginalText = "Alia Yarychevskaya" };
            Username = new TextEntryViewModel { Label = "Username", OriginalText = "Alia" };
            Password = new PasswordEntryViewModel { Label = "Password", FakePassword = "********" };
            Email = new TextEntryViewModel { Label = "Email", OriginalText = "contact@me.com" };
        }

        #endregion
    }
}
