using Messenger.Core;

namespace Messenger
{
    /// <summary>
    /// Locates view models from the IoC for use in binding in Xaml files
    /// </summary>
    public class ViewModelLocator 
    {
        #region Public Properties

        public static ViewModelLocator Instance { get; private set; } = new ViewModelLocator();
        public static ApplicationViewModel ApplicationViewModel => IoC.Get<ApplicationViewModel>();

        #endregion
    }
}
