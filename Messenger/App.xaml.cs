using Messenger.Core;
using System.Windows;

namespace Messenger
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ApplicationSetup();

            IoC.Logger.Log("Application starting up", LogLevel.Debug);
            IoC.Logger.Log("Application starting up", LogLevel.Informative);
            IoC.Logger.Log("Application starting up", LogLevel.Error);
            IoC.Logger.Log("Application starting up", LogLevel.Success);
            IoC.Logger.Log("Application starting up", LogLevel.Warning);
            IoC.Logger.Log("Application starting up", LogLevel.Success);
            IoC.Logger.Log("Application starting up", LogLevel.Informative);
            IoC.Logger.Log("Application starting up", LogLevel.Verbose);

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
    }
}
