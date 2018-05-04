using Messenger.Core;
using System.Security;

namespace Messenger
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class RegisterPage : BasePage<RegisterViewModel>, IHavePassword
    {
        #region Constructors

        public RegisterPage()
        {
            InitializeComponent();
        }

        public RegisterPage(RegisterViewModel specificViewModel) : base(specificViewModel)
        {
            InitializeComponent();
        }

        #endregion

        public SecureString SecurePassword => PasswordText.SecurePassword;
    }
}
