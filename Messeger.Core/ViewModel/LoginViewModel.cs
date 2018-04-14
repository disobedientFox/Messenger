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

    public class LoginViewModel : BaseViewModel
    {
        #region Public Properties

        public string Email { get; set; }

        public bool LoginIsRunning { get; set; }

        #endregion

        #region Commands

        public ICommand LoginCommand { get; set; }

        public ICommand RegisterCommand { get; set; }

        #endregion

        #region Constructor
        public LoginViewModel()
        {
            LoginCommand = new RelayParameterizeCommand(async (parameter) => await Login(parameter));

            RegisterCommand = new RelayCommand(async () => await Register());

        }

        #endregion

        public async Task Login(object parameter)
        {
            await RunCommand(() => this.LoginIsRunning, async () =>
            {
                await Task.Delay(1000);

                // Go to chat page
                IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.Chat);

                //var email = this.Email;
                //var pass = (parameter as IHavePassword).SecurePassword.Unsecure();
            });
        }

        public async Task Register()
        {

            IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.Register);

            await Task.Delay(1);
        }
    }
}
