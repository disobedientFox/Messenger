namespace Messenger.Core
{
    /// <summary>
    /// 
    /// </summary>
    public class LoginCredentialsApiModel
    {
        #region Public Properties

        /// <summary>
        /// The users username or email
        /// </summary>
        public string UsernameOrEmail { get; set; }

        /// <summary>
        /// The users password
        /// </summary>
        public string Password { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public LoginCredentialsApiModel()
        {

        }

        #endregion
    }
}