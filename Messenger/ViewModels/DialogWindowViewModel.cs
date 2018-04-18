using System.Windows;
using System.Windows.Controls;

namespace Messenger
{

    public class DialogWindowViewModel : WindowViewModel
    {
        #region Public Properties

        public string Title { get; set; }

        public Control Content { get; set; }

        #endregion

        #region Constructor

        public DialogWindowViewModel(Window window) : base(window)
        {
            WindowMinimumHeight = 100;
            WindowMinimumWidth = 250;

            TitleHeight = 30;
        }

        #endregion
    }
}
