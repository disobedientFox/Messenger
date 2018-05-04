using Messenger.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
namespace Messenger
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : BasePage<LoginViewModel>, IHavePassword
    {
        #region Constructors

        public LoginPage()
        {
            InitializeComponent();
        }

        public LoginPage(LoginViewModel specificViewModel) : base(specificViewModel)
        {
            InitializeComponent();
        }

        #endregion

        public SecureString SecurePassword => PasswordText.SecurePassword;
    }
}
