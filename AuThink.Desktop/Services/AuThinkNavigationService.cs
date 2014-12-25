using System.Windows;
using System.Windows.Controls;

namespace AuThink.Desktop.Services
{
    public class AuthinkNavigationService
    {
        private Window _currentWindow;

        public void NavigateTo(UserControl navigateTo)
        {
            _currentWindow = Application.Current.MainWindow;

            if (_currentWindow == null) return;
            
            _currentWindow.Content = null;    
            _currentWindow.Content =  navigateTo;
        }      
    }
}
