using Messenger.Core;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Messenger
{
    public class BaseDialogUserControl : UserControl
    {

        #region Private Members

        private DialogWindow mDialogWindow;

        #endregion

        #region Public Commands



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
        }

        #endregion

        #region Public Dialog show methods

        public Task ShowDialog<T>(T viewModel)
            where T : BaseViewModel
        {
            var tcs = new TaskCompletionSource<bool>();

            Application.Current.Dispatcher.Invoke(() =>
            {
                try
                {
                    mDialogWindow.ViewModel.WindowMinimumHeight = WindowMinimumHeight;
                    mDialogWindow.ViewModel.WindowMinimumWidth = WindowMinimumWidth;
                    mDialogWindow.ViewModel.TitleHeight = TitleHeight;
                    mDialogWindow.ViewModel.Title = Title;

                    DataContext = viewModel;

                    mDialogWindow.ShowDialog();
                }
                finally
                {
                    tcs.TrySetResult(true);
                }
            });

            return tcs.Task;
        }

        #endregion

    }
}
