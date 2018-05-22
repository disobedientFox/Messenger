using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Core
{
    /// <summary>
    /// The UI Manager that handles any UI interaction in the application
    /// </summary>
    public interface IUIManager
    {
        Task ShowMessage(MessageBoxDialogViewModel viewModel);

    }
}
