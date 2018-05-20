namespace Messenger.Core
{

	public class LoginResultApiModel
    {
		#region Public Properties

        public string Token { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        #endregion

        #region Constructor

        public LoginResultApiModel()
        {
            
        }

        #endregion
    }
}