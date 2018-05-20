namespace Messenger.Core
{

	public class ApiResponse<T>
    {
	    #region Public Properties

        public bool Successful => ErrorMessage == null;


        public string ErrorMessage { get; set; }

        public T Response { get; set; }

        #endregion

        #region Constructor


        public ApiResponse()
        {
            
        }

        #endregion
    }
}