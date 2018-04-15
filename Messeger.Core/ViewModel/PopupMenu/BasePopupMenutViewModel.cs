namespace Messenger.Core
{
    public class BasePopupMenuViewModel : BaseViewModel
    {
        #region Public Properties

        public string BubbleBackground { get; set; }

        public ElementHorizontalAlignment ArrowAlignment { get; set; }

        #endregion

        #region Constructor

        public BasePopupMenuViewModel()
        {
            BubbleBackground = "ffffff";
            ArrowAlignment = ElementHorizontalAlignment.Left;
        }

        #endregion

    }
}
