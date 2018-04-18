using Messenger.Core;
using System.Threading.Tasks;
using System.Windows;

namespace Messenger
{
    public class UIManager : IUIManager
    {
        /// <summary>
        /// Display a single message box to the user
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        public Task ShowMessage(MessageBoxDialogViewModel viewModel)
        {
            throw new System.NotImplementedException();
        }
    }
}
