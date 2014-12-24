using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace AuThink.Desktop.Services
{
    public class AuthinkNavigationService
    {
        private Window currentWindow;

        #region Implementation of INavigationService

        public void NavigateTo(UserControl navigateTo)
        {
            currentWindow = System.Windows.Application.Current.MainWindow as Window;
            if (currentWindow != null)
            {
                currentWindow.Content = null;    
                currentWindow.Content =  navigateTo;
            }

        }

        #endregion

      
    }
}
