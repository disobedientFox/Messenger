using Dna;
using System.Threading.Tasks;
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

                var result = await WebRequests.PostAsync<ApiResponse<LoginResultApiModel>>(
                    "http://localhost:56748/api/login",
                    new LoginCredentialsApiModel
                    {
                        UsernameOrEmail = Email,
                        Password = (parameter as IHavePassword).SecurePassword.Unsecure()
                    });

                if (result == null || result.ServerResponse == null || !result.ServerResponse.Successful)
                {
                    var message = "Unknown error from server call";

                    if (result?.ServerResponse != null)
                    {
                        message = result.ServerResponse.ErrorMessage;
                    }
                    else if (string.IsNullOrWhiteSpace(result?.RawServerResponse))
                    {
                        message = $"Unexpected response from server. {result.RawServerResponse}";
                    }
                    else if (result != null)
                    {
                        message = $"Falied to communicate with server. Status code{result.StatusCode}. {result.StatusDescription}";
                    }

                    await IoC.UI.ShowMessage(new MessageBoxDialogViewModel
                    {
                        Title = "Login Failed",
                        Message = message
                    });

                    return;
                }

                var userData = result.ServerResponse.Response;

                IoC.Settings.Name = new TextEntryViewModel { Label = "Name", OriginalText = $"{userData.FirstName} {userData.LastName}"};
                IoC.Settings.Username = new TextEntryViewModel { Label = "Username", OriginalText = userData.Username };
                IoC.Settings.Password = new PasswordEntryViewModel { Label = "Password", FakePassword = "********" };
                IoC.Settings.Email = new TextEntryViewModel { Label = "Email", OriginalText = userData.Email };

                // Go to chat page
                IoC.Application.GoToPage(ApplicationPage.Chat);

                //var email = this.Email;
                //var pass = (parameter as IHavePassword).SecurePassword.Unsecure();
            });
        }

        public async Task Register()
        {

            IoC.Application.GoToPage(ApplicationPage.Register);

            await Task.Delay(1);
        }
    }
}
