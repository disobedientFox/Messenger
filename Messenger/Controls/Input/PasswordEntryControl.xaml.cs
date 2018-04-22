using Messenger.Core;
using System.Diagnostics;
using System.Security;
using System.Windows;
using System.Windows.Controls;

namespace Messenger
{
    /// <summary>
    /// Логика взаимодействия для PasswordEntryControl.xaml
    /// </summary>
    public partial class PasswordEntryControl : UserControl
    {
        #region Dependency Properties

        public GridLength LabelWidth
        {
            get => (GridLength)GetValue(LabelWidthProperty);
            set => SetValue(LabelWidthProperty, value);
        }

        // Using a DependencyProperty as the backing store for LabelWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LabelWidthProperty =
            DependencyProperty.Register("LabelWidth", typeof(GridLength), typeof(PasswordEntryControl), new PropertyMetadata(GridLength.Auto, LabelWidthChangedCallback));

        #endregion


        #region Constructor
        public PasswordEntryControl()
        {
            InitializeComponent();
        }
        #endregion

        #region Dependency callback

        public static void LabelWidthChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                (d as PasswordEntryControl).LabelColumnDefinition.Width = (GridLength)e.NewValue;
            }
            catch
            {
                Debugger.Break();

                (d as PasswordEntryControl).LabelColumnDefinition.Width = GridLength.Auto;
            }
        }

        #endregion

        private void CurrentPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is PasswordEntryViewModel viewModel)
                viewModel.CurrentPassword = CurrentPassword.SecurePassword;
        }

        private void NewPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is PasswordEntryViewModel viewModel)
                viewModel.NewPassword = NewPassword.SecurePassword;
        }

        private void ConfirmPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is PasswordEntryViewModel viewModel)
                viewModel.ConfirmPassword = ConfirmPassword.SecurePassword;
        }
    }
}
