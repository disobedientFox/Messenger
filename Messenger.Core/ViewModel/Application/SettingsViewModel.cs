using System;
using System.Windows.Input;

namespace Messenger.Core
{
    public class SettingsViewModel : BaseViewModel
    {
        #region Public Properties

        public TextEntryViewModel Name { get; set; }

        public PasswordEntryViewModel Password { get; set; }

        public TextEntryViewModel Username { get; set; }

        public TextEntryViewModel Email { get; set; }

        #endregion

        #region Public Commands

        public ICommand CloseCommand { get; set; }
        
        public ICommand OpenCommand { get; set; }

        public ICommand LogoutCommand { get; set; }

        public ICommand ClearUserDataCommand { get; set; }

        #endregion

        #region Constructor

        public SettingsViewModel()
        {
            CloseCommand = new RelayCommand(Close);

            OpenCommand = new RelayCommand(Open);

            LogoutCommand = new RelayCommand(Logout);

            ClearUserDataCommand = new RelayCommand(ClearUserData);

            Name = new TextEntryViewModel { Label = "Name", OriginalText = $"Alia Yarychevskaya" };
            Username = new TextEntryViewModel { Label = "Username", OriginalText = "Alia" };
            Password = new PasswordEntryViewModel { Label = "Password", FakePassword = "********" };
            Email = new TextEntryViewModel { Label = "Email", OriginalText = "contact@me.com" };

        }

        #endregion
        public void Close()
        {
            IoC.Application.SettingsMenuVisible = false;
        }

        public void Open()
        {
            IoC.Application.SettingsMenuVisible = true;
        }

        public void Logout()
        {
            ClearUserData();

            IoC.Application.GoToPage(ApplicationPage.Login);
        }

        public void ClearUserData()
        {
            Name = null;
            Username = null;
            Password = null;
            Email = null;
        }
    }
}
