/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocatorTemplate xmlns:vm="clr-namespace:AuThink.Desktop.ViewModel"
                                   x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"
*/

using System;
using AuThink.Desktop.Core;
using AuThink.Desktop.Model;
using AuThink.Desktop.Model.Data.Local;
using AuThink.Desktop.Services;
using AuThink.Desktop.ViewModels.GameViewModels;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace AuThink.Desktop.ViewModels
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
            SimpleIoc.Default.Register<RewardViewModel>();
            SimpleIoc.Default.Register<EndTestViewModel>();
            SimpleIoc.Default.Register<LoginViewModel>();
            SimpleIoc.Default.Register<ChildrenViewModel>();

            SimpleIoc.Default.Register<ContinueSequenceViewModel>();
            SimpleIoc.Default.Register<PairHalfsViewModel>();
            SimpleIoc.Default.Register<DetectDifferentItemsHighDifficultyViewModel>();
            SimpleIoc.Default.Register<DetectSameItemsViewModel>();
            SimpleIoc.Default.Register<DetectDifferentItemsUserViewModel>();
            SimpleIoc.Default.Register<OrderBySizeViewModel>();
            SimpleIoc.Default.Register<DetectColorsViewModel>();
            SimpleIoc.Default.Register<PairSameItemsViewModel>();
            SimpleIoc.Default.Register<VoiceCommandsViewModel>();

            SimpleIoc.Default.Register<Random>(() => new Random());

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

        public LoginViewModel Login
        {
            get
            {
                Cleanup();
                return ServiceLocator.Current.GetInstance<LoginViewModel>(CurrentKey);
            }
        }

        public ChildrenViewModel Children
        {
            get
            {
                Cleanup();
                return ServiceLocator.Current.GetInstance<ChildrenViewModel>(CurrentKey);
            }
        }

        public ContinueSequenceViewModel ContinueSequence
        {
            get
            {
                Cleanup();
                return ServiceLocator.Current.GetInstance<ContinueSequenceViewModel>(CurrentKey);
            }
        }

        public DetectDifferentItemsHighDifficultyViewModel DetectDifferentItemsHighDifficulty
        {
            get
            {
                Cleanup();
                return ServiceLocator.Current.GetInstance<DetectDifferentItemsHighDifficultyViewModel>(CurrentKey);
            }
        }

        public DetectSameItemsViewModel DetectSame
        {
            get
            {
                Cleanup();
                return ServiceLocator.Current.GetInstance<DetectSameItemsViewModel>(CurrentKey);
            }
        }

        public PairSameItemsViewModel PairSameItems
        {
            get
            {
                Cleanup();
                return ServiceLocator.Current.GetInstance<PairSameItemsViewModel>(CurrentKey);
            }
        }

        public DetectDifferentItemsUserViewModel DetectDifferent
        {
            get
            {
                Cleanup();
                return ServiceLocator.Current.GetInstance<DetectDifferentItemsUserViewModel>(CurrentKey);
            }
        }

        public PairHalfsViewModel PairHalfs
        {
            get
            {
                Cleanup();
                return ServiceLocator.Current.GetInstance<PairHalfsViewModel>(CurrentKey);
            }
        }

        public OrderBySizeViewModel OrderBySize
        {
            get
            {
                Cleanup();
                return ServiceLocator.Current.GetInstance<OrderBySizeViewModel>(CurrentKey);
            }
        }

        public DetectColorsViewModel DetectColors
        {
            get
            {
                Cleanup();
                return ServiceLocator.Current.GetInstance<DetectColorsViewModel>(CurrentKey);
            }
        }

        public VoiceCommandsViewModel VoiceCommands
        {
            get
            {
                Cleanup();
                return ServiceLocator.Current.GetInstance<VoiceCommandsViewModel>(CurrentKey);
            }
        }

        public RewardViewModel Reward
        {
            get
            {
                Cleanup();
                return ServiceLocator.Current.GetInstance<RewardViewModel>();
            }
        }

        public EndTestViewModel EndTest
        {
            get
            {
                Cleanup();
                return ServiceLocator.Current.GetInstance<EndTestViewModel>(CurrentKey);
            }
        }

        public static void Cleanup()
        {
            SimpleIoc.Default.Unregister<ContinueSequenceViewModel>(CurrentKey);
            SimpleIoc.Default.Unregister<PairHalfsViewModel>(CurrentKey);
            SimpleIoc.Default.Unregister<DetectDifferentItemsHighDifficultyViewModel>(CurrentKey);
            SimpleIoc.Default.Unregister<DetectDifferentItemsUserViewModel>(CurrentKey);
            SimpleIoc.Default.Unregister<DetectSameItemsViewModel>(CurrentKey);
            SimpleIoc.Default.Unregister<OrderBySizeViewModel>(CurrentKey);
            SimpleIoc.Default.Unregister<DetectColorsViewModel>(CurrentKey);
            SimpleIoc.Default.Unregister<PairSameItemsViewModel>(CurrentKey);
            SimpleIoc.Default.Unregister<VoiceCommandsViewModel>(CurrentKey);

            SimpleIoc.Default.Unregister<ChildrenViewModel>(CurrentKey);
            SimpleIoc.Default.Unregister<LoginViewModel>(CurrentKey);
            SimpleIoc.Default.Unregister<EndTestViewModel>(CurrentKey);

            SimpleIoc.Default.Unregister<MainViewModel>(CurrentKey);
            SimpleIoc.Default.Unregister<GameViewModel>(CurrentKey);
            SimpleIoc.Default.Unregister<RewardViewModel>(CurrentKey);
            SimpleIoc.Default.Unregister<TestListViewModel>(CurrentKey);
            SimpleIoc.Default.Unregister<SettingsViewModel>(CurrentKey);
            SimpleIoc.Default.Unregister<AboutViewModel>(CurrentKey);

            CurrentKey = System.Guid.NewGuid().ToString();
        }
    }
}