using System;
using System.Windows.Input;

namespace Messenger.Core
{
    public class SettingsViewModel : BaseViewModel
    {
        #region Public Commands

        public ICommand CloseCommand { get; set; }
        
        public ICommand OpenCommand { get; set; }

        #endregion

        #region Constructor

        public SettingsViewModel()
        {
            CloseCommand = new RelayCommand(Close);

            OpenCommand = new RelayCommand(Open);
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
    }
}
