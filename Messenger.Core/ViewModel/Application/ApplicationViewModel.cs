﻿using Messenger.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Core
{
    public class ApplicationViewModel : BaseViewModel
    {
        public ApplicationPage CurrentPage { get; private set; } = ApplicationPage.Login;

        public BaseViewModel CurrentPageViewModel { get; set; }

        public bool SideMenuVisible { get; set; } = false;

        public bool SettingsMenuVisible { get; set; }

        public void GoToPage(ApplicationPage page, BaseViewModel viewModel = null)
        {
            SettingsMenuVisible = false;
            
            CurrentPageViewModel = viewModel;
            
            // Set the current page
            CurrentPage = page;

            OnPropertyChanged(nameof(CurrentPage));

            // Show side menu or not?
            SideMenuVisible = page == ApplicationPage.Chat;

        }

        public async Task HandleSuccessfulLoginAsync(LoginResultApiModel loginResult)
        {
            // Store this in the client data store
            await IoC.ClientDataStore.SaveLoginCredentialsAsync(new LoginCredentialsDataModel
            {
                Email = loginResult.Email,
                FirstName = loginResult.FirstName,
                LastName = loginResult.LastName,
                Username = loginResult.Username,
                Token = loginResult.Token
            });

            // Load new settings
            //await IoC.Settings.LoadAsync();

            // Go to chat page
            IoC.Application.GoToPage(ApplicationPage.Chat);
        }
    }
}
