namespace Messenger.Core
{
    /// <summary>
    /// The credentials for  an API client to register on the server 
    /// </summary>
    public class RegisterCredentialsApiModel
    {
        #region Public Properties

        public string Username { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }

        #endregion

        #region Constructor

        public RegisterCredentialsApiModel()
        {

        }

        #endregion
    }
}