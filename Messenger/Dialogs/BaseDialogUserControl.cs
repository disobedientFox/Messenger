using Messenger.Core;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Messenger
{
    public class BaseDialogUserControl : UserControl
    {

        #region Private Members

        private DialogWindow mDialogWindow;

        #endregion

        #region Public Commands

        public ICommand CloseCommand { get; private set; }

        #endregion

        #region Public Properties

        public int WindowMinimumWidth { get; set; } = 250;
        public int WindowMinimumHeight { get; set; } = 100;

        public int TitleHeight { get; set; } = 30;

        public string Title { get; set; } 

        #endregion

        #region Constructor

        public BaseDialogUserControl()
        {
            mDialogWindow = new DialogWindow();
            mDialogWindow.ViewModel = new DialogWindowViewModel(mDialogWindow);

            CloseCommand = new RelayCommand(() => mDialogWindow.Close());
        }

        #endregion

        #region Public Dialog show methods

        public Task ShowDialog<T>(T viewModel)
            where T : BaseDialogViewModel
        {
            // Create a task to await the dialog closing
            var tcs = new TaskCompletionSource<bool>();

            // Run on UI thread
            Application.Current.Dispatcher.Invoke(() =>
            {
                try
                {
                    // Match controls expected sizes to the dialog windows view model
                    mDialogWindow.ViewModel.WindowMinimumWidth = WindowMinimumWidth;
                    mDialogWindow.ViewModel.WindowMinimumHeight = WindowMinimumHeight;
                    mDialogWindow.ViewModel.TitleHeight = TitleHeight;
                    mDialogWindow.ViewModel.Title = string.IsNullOrEmpty(viewModel.Title) ? Title : viewModel.Title;

                    // Set this control to the dialog window content
                    mDialogWindow.ViewModel.Content = this;

                    // Setup this controls data context binding to the view model
                    DataContext = viewModel;

                    // Show dialog
                    mDialogWindow.ShowDialog();
                }
                finally
                {
                    // Let caller know we finished
                    tcs.TrySetResult(true);
                }
            });

            return tcs.Task;
        }


        #endregion

    }
}
