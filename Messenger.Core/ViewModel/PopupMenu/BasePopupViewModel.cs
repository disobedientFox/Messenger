namespace Messenger.Core
{
    public class BasePopupViewModel : BaseViewModel
    {
        #region Public Properties

        public string BubbleBackground { get; set; }

        public ElementHorizontalAlignment ArrowAlignment { get; set; }

        public BaseViewModel Content { get; set; }
        
        #endregion

        #region Constructor

        public BasePopupViewModel()
        {
            BubbleBackground = "ffffff";
            ArrowAlignment = ElementHorizontalAlignment.Left;
        }

        #endregion

    }
}
