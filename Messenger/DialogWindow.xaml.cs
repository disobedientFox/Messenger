using Messenger.Core;
using System.Windows;

namespace Messenger
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class DialogWindow : Window
    {
        #region Private Members

        private DialogWindowViewModel mViewModel;

        #endregion

        #region Public Members

        public DialogWindowViewModel ViewModel
        {
            get => mViewModel;
            set
            {
                mViewModel = value;

                DataContext = mViewModel;
            }
        }

        #endregion
        
        #region Constructor

        public DialogWindow()
        {
            InitializeComponent();
        } 

        #endregion
    }
}
