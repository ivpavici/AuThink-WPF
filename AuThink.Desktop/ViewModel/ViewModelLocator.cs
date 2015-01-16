/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocatorTemplate xmlns:vm="clr-namespace:AuThink.Desktop.ViewModel"
                                   x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"
*/

using AuThink.Desktop.Core;
using AuThink.Desktop.Model;
using AuThink.Desktop.Model.Data.Local;
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
            SimpleIoc.Default.Register<AboutViewModel>();
            SimpleIoc.Default.Register<TestListViewModel>();
            SimpleIoc.Default.Register<GameViewModel>();

            SimpleIoc.Default.Register<ITestQueries, TestQueries>();
            SimpleIoc.Default.Register<ITaskQueries, TaskQueries>();
            SimpleIoc.Default.Register<IPictureQueries, PictureQueries>();

            SimpleIoc.Default.Register<IDataProvider, DefaultDataFactory>();
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
                return ServiceLocator.Current.GetInstance<MainViewModel>(CurrentKey);
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

        public AboutViewModel About
        {
            get
            {
                Cleanup();
                return ServiceLocator.Current.GetInstance<AboutViewModel>(CurrentKey);
            }
        }

        public TestListViewModel List
        {
            get
            {
                Cleanup();
                return ServiceLocator.Current.GetInstance<TestListViewModel>(CurrentKey);
            }
        }

        public GameViewModel Game
        {
            get
            {
                Cleanup();
                return ServiceLocator.Current.GetInstance<GameViewModel>(CurrentKey);
            }
        }

        public static void Cleanup()
        {
            SimpleIoc.Default.Unregister<MainViewModel>(CurrentKey);

            //jel triba i ostale unregister?

            CurrentKey = System.Guid.NewGuid().ToString();
        }
    }
}