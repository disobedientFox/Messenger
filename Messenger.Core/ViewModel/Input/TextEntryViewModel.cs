using System.Windows.Input;

namespace Messenger.Core
{
    /// <summary>
    /// The view model for a text entry to edit a string value
    /// </summary>
    public class TextEntryViewModel : BaseViewModel
    {

        #region Public Properties

        public string Label { get; set; }

        public string OriginalText { get; set; }

        public string EditedText { get; set; }

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
        public TextEntryViewModel()
        {
            EditCommand = new RelayCommand(Edit);
            SaveCommand = new RelayCommand(Save);
            CancelCommand = new RelayCommand(Cancel);
        }

        #endregion

        #region Command Methods

        public void Edit()
        {
            EditedText = OriginalText;
            Editing = true;
        }

        public void Save()
        {
            OriginalText = EditedText;
            Editing = false;
        }

        public void Cancel()
        {
            Editing = false;
        }
        #endregion
    }
}