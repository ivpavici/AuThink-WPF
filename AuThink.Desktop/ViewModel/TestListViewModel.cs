﻿using System.Collections.Generic;
using System.Linq;
using AuThink.Desktop.Model.Entities;
using AuThink.Desktop.Model.Model;
using AuThink.Desktop.Services;
using AuThink.Desktop.Settings;
using AuThink.Desktop.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace AuThink.Desktop.ViewModel
{
    public partial class TestListViewModel: ViewModelBase
    {
        public Test SelectedTest
        {
            get { return _selectedTest; }
            set
            {
                if (_selectedTest == value)
                {
                    return;
                }

                _selectedTest = value;
                RaisePropertyChanged("SelectedTest");
            }
        }
        private Test _selectedTest;

        public Task SelectedTask
        {
            get { return _selectedTask; }
            set
            {
                if (_selectedTask == value)
                {
                    return;
                }

                _selectedTask = value;
                RaisePropertyChanged("SelectedTask");
            }
        }
        private Task _selectedTask;

        public string SelectTestButtonContent
        {
            get { return _selectTestButtonContent; }
            set
            {
                if (_selectTestButtonContent == value)
                {
                    return;
                }

                _selectTestButtonContent = value;
                this.RaisePropertyChanged(this.SelectTestButtonContent);
            }
        }

        public string GoBackButtonContent
        {
            get { return _goBackButtonContent; }
            set
            {
                if (_goBackButtonContent == value)
                {
                    return;
                }

                _goBackButtonContent = value;
                this.RaisePropertyChanged(this.GoBackButtonContent);
            }
        }

        private string _selectTestButtonContent = Language.TestListPage.SelectTestButtonContent();
        private string _goBackButtonContent = Language.TestListPage.GoBackButtonContent();

        public RelayCommand RunTestCommand { get; private set; }
        private void RunTest()
        {
            var tasks_ids = taskQueries.GetAllTasksForTest(SelectedTest.Id).Select(task => task.Id).SkipWhile(x => SelectedTask != null && x != SelectedTask.Id).ToList();

            GameState.Start(SelectedTest.Id, tasks_ids);

            var view = new GameView(); 
            _navigationService.NavigateTo(view);
        }

        public RelayCommand GoBackCommand { get; private set; }
        private void GoBack()
        {
            var page = new MainMenu();
            _navigationService.NavigateTo(page);
        }
    }
    
    public partial class TestListViewModel 
    {
        private readonly AuthinkNavigationService _navigationService;

        public TestListViewModel(
            AuthinkNavigationService navigationService,
            ITestQueries testQueries,
            ITaskQueries taskQueries)
        {
            _navigationService = navigationService;

            this.taskQueries = taskQueries;
            Tests = new List<Test>(testQueries.GetAll());

            this.RunTestCommand = new RelayCommand(RunTest);
            this.GoBackCommand = new RelayCommand(GoBack);
        }

        private readonly ITaskQueries taskQueries;

        public IEnumerable<Test> Tests { get; set; }
    }
}