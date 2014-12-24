/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocatorTemplate xmlns:vm="clr-namespace:AuThink.Desktop.ViewModel"
                                   x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"
*/

using AuThink.Desktop.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace AuThink.Desktop.ViewModel
{
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (ViewModelBase.IsInDesignModeStatic)
            {
               // SimpleIoc.Default.Register<IDataService, Design.DesignDataService>();
            }
            else
            {
                //SimpleIoc.Default.Register<IDataService, DataService>();
            }

            SimpleIoc.Default.Register<AuthinkNavigationService>();
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<SettingsViewModel>();
        }

        private static string _currentKey = System.Guid.NewGuid().ToString();
        public static string CurrentKey
        {
            get
            {
                return _currentKey;
            }
            private set
            {
                _currentKey = value;
            }
        }

        public MainViewModel Main
        {
            get
            {
                Cleanup();
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
            
        }

        public SettingsViewModel Settings
        {
            get
            {
                Cleanup();
                return ServiceLocator.Current.GetInstance<SettingsViewModel>(CurrentKey);
            }
        }

        public static void Cleanup()
        {
            SimpleIoc.Default.Unregister<MainViewModel>(CurrentKey);
            CurrentKey = System.Guid.NewGuid().ToString();
        }
    }
}