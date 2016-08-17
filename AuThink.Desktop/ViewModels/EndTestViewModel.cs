using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuThink.Desktop.Core;
using AuThink.Desktop.Services;
using AuThink.Desktop.Settings;
using AuThink.Desktop.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace AuThink.Desktop.ViewModels
{
    public partial class EndTestViewModel : ViewModelBase
    {
        public string SuccessfullTextContent
        {
            get { return _successfullTextContent; }
            set
            {
                if (_successfullTextContent == value)
                {
                    return;
                }

                _successfullTextContent = value;
                this.RaisePropertyChanged(this.SuccessfullTextContent);
            }
        }
        private string _successfullTextContent = Language.EndTestPage.SuccessfullTextContent();

        public string ResetTestButtonContent
        {
            get { return _resetTestButtonContent; }
            set
            {
                if (_resetTestButtonContent == value)
                {
                    return;
                }

                _resetTestButtonContent = value;
                this.RaisePropertyChanged(this.ResetTestButtonContent);
            }
        }
        private string _resetTestButtonContent = Language.EndTestPage.ResetTestButtonContent();

        public string TestMenuButtonContent
        {
            get { return _testMenuButtonContent; }
            set
            {
                if (_testMenuButtonContent == value)
                {
                    return;
                }

                _testMenuButtonContent = value;
                this.RaisePropertyChanged(this.TestMenuButtonContent);
            }
        }
        private string _testMenuButtonContent = Language.EndTestPage.TestMenuButtonContent();

        public string ExitButtonContent
        {
            get { return _exitButtonContent; }
            set
            {
                if (_exitButtonContent == value)
                {
                    return;
                }

                _exitButtonContent = value;
                this.RaisePropertyChanged(this.ExitButtonContent);
            }
        }
        private string _exitButtonContent = Language.EndTestPage.ExitButtonContent();

        public RelayCommand ResetTestCommand { get; set; }
        public void ResetTest()
        {
            var taskIds = taskQueries.GetAllTasksForTest(GameState.CurrentTestId).Select(task => task.Id).ToList();
            GameState.Start(GameState.CurrentTestId, taskIds);
            var view = new GameView();
            navigationService.NavigateTo(view);
        }

        public RelayCommand GoToTestListCommand { get; set; }
        public void GoToTestList()
        {
            var view = new TestListView();
            navigationService.NavigateTo(view);
        }

        public RelayCommand ExitToMainCommand { get; set; }
        public void ExitToMain()
        {
            var view = new MainMenu();
            navigationService.NavigateTo(view);
        }

    }

    public partial class EndTestViewModel
    {
        public EndTestViewModel
        (
            AuthinkNavigationService navigationService,
            ITaskQueries taskQueries
        )
        {
            this.ResetTestCommand = new RelayCommand(ResetTest);
            this.GoToTestListCommand = new RelayCommand(GoToTestList);
            this.ExitToMainCommand = new RelayCommand(ExitToMain);

            this.navigationService = navigationService;
            this.taskQueries = taskQueries;
        }

        private readonly AuthinkNavigationService navigationService;
        private readonly ITaskQueries taskQueries;
    }
}
