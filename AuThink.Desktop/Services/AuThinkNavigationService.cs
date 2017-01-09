using System.Windows;
using System.Windows.Controls;
using AuThink.Desktop.Views;

namespace AuThink.Desktop.Services
{
    public class AuthinkNavigationService
    {
        private Window _currentWindow;

        public void NavigateTo(UserControl navigateTo)
        {
            _currentWindow = Application.Current.MainWindow;

            if (_currentWindow == null) return;
            
			if(navigateTo is RewardView)
				SoundServices.Instance.PlayAplauz();

            _currentWindow.Content = null;    
            _currentWindow.Content =  navigateTo;
        }      
    }
}
