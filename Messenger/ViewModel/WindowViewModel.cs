using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Messenger
{
    class WindowViewModel : BaseViewModel
    {
        #region Private member

        private Window mWindow;

        #endregion

        #region Public Properties

        public string Test { get; set; } = "My string";

        #endregion

        #region Constructor
        public WindowViewModel(Window window)
        {
            mWindow = window;
        }

        #endregion
    }
}
