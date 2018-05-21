using Dna;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Messenger.Core
{

    public class RegisterViewModel : BaseViewModel
    {
        #region Public Properties

        public string Email { get; set; }
        public string Username { get; set; }

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
                // Call the server and attempt to register with the provided credentials
                // TODO: Move all URLs and API routes to static class in core
                var result = await WebRequests.PostAsync<ApiResponse<RegisterResultApiModel>>(
                    "http://localhost:56748/api/register",
                    new RegisterCredentialsApiModel
                    {
                        Username = Username,
                        Email = Email,
                        Password = (parameter as IHavePassword).SecurePassword.Unsecure()
                    });

                // If the response has an error...
                //if (await result.DisplayErrorIfFailedAsync("Register Failed"))
                    //return;

                // OK successfully registered (and logged in)... now get users data
                var loginResult = result.ServerResponse.Response;

                // Let the application view model handle what happens
                // with the successful login
                await IoC.Application.HandleSuccessfulLoginAsync(loginResult);
            });
        }

        public async Task Login()
        {
            IoC.Application.GoToPage(ApplicationPage.Login);

            await Task.Delay(1);
        }
    }
}
