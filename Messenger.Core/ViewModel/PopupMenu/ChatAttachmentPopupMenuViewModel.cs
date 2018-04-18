using System.Collections.Generic;

namespace Messenger.Core
{
    public class ChatAttachmentPopupMenuViewModel : BasePopupViewModel
    {
        #region Constructor

        public ChatAttachmentPopupMenuViewModel()
        {
            Content = new MenuViewModel
            {
                Items = new List<MenuItemViewModel>(new[]
                {
                    new MenuItemViewModel { Text = "Attach a file...", Type = MenuItemType.Header},
                    new MenuItemViewModel { Text = "From computer", Icon = IconType.File },
                    new MenuItemViewModel { Text = "From picture", Icon = IconType.Picture },
                })
            };
        }

        #endregion



    }
}
