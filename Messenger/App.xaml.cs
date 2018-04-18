﻿using Messenger.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Messenger
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ApplicationSetup();

            Current.MainWindow = new MainWindow();
            Current.MainWindow.Show();
        }

        /// <summary>
        /// Configures app ready for use
        /// </summary>
        private void ApplicationSetup()
        {
            IoC.Setup();

            IoC.Kernel.Bind<IUIManager>().ToConstant(new UIManager());
            
        }
    }
}
