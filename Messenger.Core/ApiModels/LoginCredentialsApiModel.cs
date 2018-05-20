namespace Messenger.Core
{

    public class LoginCredentialsApiModel
    {
        #region Public Properties

        public string UsernameOrEmail { get; set; }

        public string Password { get; set; }

        #endregion

        #region Constructor

        public LoginCredentialsApiModel()
        {

        }

        #endregion
    }
}