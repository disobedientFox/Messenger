using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Messenger
{
    /// <summary>
    /// A base page for all pages to gain base functionality
    /// </summary>
    class BasePage : Page
    {
        #region Public Properties

        public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.SlideAndFadeInFromRight;

        public PageAnimation PageUnloadAnimation { get; set; } = PageAnimation.SlideAndFadeOutToLeft;

        public float SlideSeconds { get; set; } = 0.8f;

        #endregion

        #region Constructor

        public BasePage()
        {
            this.Loaded += BasePage_Loaded;
        }

        #endregion

        #region Animation Load / Unload

        private void BasePage_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            
        }

        #endregion
    }
}
