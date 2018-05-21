using Dna;
using Messenger.Core;
using Messenger.Relational;
using System.Threading.Tasks;
using System.Windows;

namespace Messenger
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override async void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            await ApplicationSetupAsync();
            

            // Setup the application view model based on if we are logged in
            /*IoC.Application.GoToPage(
                // If we are logged in...
                await IoC.ClientDataStore.HasCredentialsAsync() ?
                // Go to chat page
                ApplicationPage.Chat :
                // Otherwise, go to login page
                ApplicationPage.Login);*/
            
            Current.MainWindow = new MainWindow();
            Current.MainWindow.Show();
        }

        /// <summary>
        /// Configures app ready for use
        /// </summary>
        private void ApplicationSetup()
        {
            IoC.Setup();

            IoC.Kernel.Bind<IUIManager>().ToConstant(new UIManager());

            IoC.Kernel.Bind<ILogFactory>().ToConstant(new BaseLogFactory());
        }

        private async Task ApplicationSetupAsync()
        {
            // Setup the Dna Framework
            new DefaultFrameworkConstruction()
                .AddFileLogger()
                .UseClientDataStore()
                .Build();
            // Setup IoC
            IoC.Setup();

            IoC.Kernel.Bind<ILogFactory>().ToConstant(new BaseLogFactory());
            // Bind a UI Manager
            IoC.Kernel.Bind<IUIManager>().ToConstant(new UIManager());

            //IoC.Kernel.Bind<ITaskManager>().ToConstant(new TaskManager());

            // Bind a file manager
            //IoC.Kernel.Bind<IFileManager>().ToConstant(new FileManager());


            // Ensure the client data store 
            await IoC.ClientDataStore.EnsureDataStoreAsync();

            // Load new settings
            //await IoC.Settings.LoadAsync();
        }
    }
}
