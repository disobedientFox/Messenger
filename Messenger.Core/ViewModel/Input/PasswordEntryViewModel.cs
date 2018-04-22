using System.Security;
using System.Windows.Input;

namespace Messenger.Core
{
    /// <summary>
    /// The view model for a password entry to edit a string value
    /// </summary>
    public class PasswordEntryViewModel : BaseViewModel
    {

        #region Public Properties

        public string Label { get; set; }

        public string FakePassword { get; set; }

        public string CurrentPasswordHintText { get; set; }

        public string NewPasswordHintText { get; set; }

        public string ConfirmPasswordHintText { get; set; }

        public SecureString CurrentPassword { get; set; }

        public SecureString NewPassword { get; set; }

        public SecureString ConfirmPassword { get; set; }

        public bool Editing { get; set; }

        #endregion

        #region Public Commands

        public ICommand EditCommand { get; set; }

        public ICommand CancelCommand { get; set; }

        public ICommand SaveCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public PasswordEntryViewModel()
        {
            EditCommand = new RelayCommand(Edit);
            SaveCommand = new RelayCommand(Save);
            CancelCommand = new RelayCommand(Cancel);

            CurrentPasswordHintText = "Current password";
            NewPasswordHintText = "New password";
            ConfirmPasswordHintText = "Confirm password";
        }

        #endregion

        #region Command Methods

        public void Edit()
        {
            NewPassword = new SecureString();
            ConfirmPassword = new SecureString();

            Editing = true;
        }

        public void Save()
        {
            var storedPassword = "Testing";

            if (storedPassword != CurrentPassword.Unsecure())
            {
                IoC.UI.ShowMessage(new MessageBoxDialogViewModel
                {
                    Title = "Wrong password",
                    Message = "The current password is invalid",
                });
                return;
            }

            if (NewPassword.Unsecure() != ConfirmPassword.Unsecure())
            {
                IoC.UI.ShowMessage(new MessageBoxDialogViewModel
                {
                    Title = "Password mismatch",
                    Message = "The new and confirm password do not match",
                });
                return;
            }

            if (NewPassword.Unsecure().Length == 0)
            {
                IoC.UI.ShowMessage(new MessageBoxDialogViewModel
                {
                    Title = "Password too short",
                    Message = "You must enter a password!",
                });
                return;
            }

            CurrentPassword = new SecureString();

            foreach (var c in NewPassword.Unsecure().ToCharArray())
                CurrentPassword.AppendChar(c);
            Editing = false;
        }

        public void Cancel()
        {
            Editing = false;
        }
        #endregion
    }
}