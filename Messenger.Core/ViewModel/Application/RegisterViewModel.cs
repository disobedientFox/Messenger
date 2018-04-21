using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Messenger.Core
{

    public class RegisterViewModel : BaseViewModel
    {
        #region Public Properties

        public string Email { get; set; }

        public bool RegisterIsRunning { get; set; }

        #endregion

        #region Commands

        public ICommand LoginCommand { get; set; }

        public ICommand RegisterCommand { get; set; }

        #endregion

        #region Constructor
        public RegisterViewModel()
        {
            RegisterCommand = new RelayParameterizeCommand(async (parameter) => await Register(parameter));

            LoginCommand = new RelayCommand(async () => await Login());

        }

        #endregion

        public async Task Register(object parameter)
        {
            await RunCommand(() => this.RegisterIsRunning, async () =>
            {
                await Task.Delay(5000);
            });
        }

        public async Task Login()
        {
            IoC.Application.GoToPage(ApplicationPage.Login);

            await Task.Delay(1);
        }
    }
}
