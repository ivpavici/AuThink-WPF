﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuThink.Desktop.Services;
using AuThink.Desktop.Settings;
using AuThink.Desktop.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace AuThink.Desktop.ViewModels
{
    public partial class RewardViewModel : ViewModelBase
    {
        public RelayCommand TempRewordCommand { get; private set; }
        public void Continue()
        {
            GameState.EndTask();
            //System.Threading.Tasks.Task.Delay(2000);
            if (GameState.TaskIds.Any())
            {
                var view = new GameView();
                _navigationService.NavigateTo(view);
            }

            else
            {
                var view = new EndTestView();
                _navigationService.NavigateTo(view);
            }
        }

        public string ContinueButtonContent
        {
            get { return _continueButtonContent; }
            set
            {
                if (_continueButtonContent == value)
                {
                    return;
                }

                _continueButtonContent = value;
                this.RaisePropertyChanged(this.ContinueButtonContent);
            }
        }
        private string _continueButtonContent = Language.RewardPage.ContinueButtonContent();

        public string RewardTextContent
        {
            get { return _rewardTextContent; }
            set
            {
                if (_rewardTextContent == value)
                {
                    return;
                }

                _rewardTextContent = value;
                this.RaisePropertyChanged(this.RewardTextContent);
            }
        }
        private string _rewardTextContent = Language.RewardPage.RewardTextContent();
    }

    public partial class RewardViewModel
    {
        private readonly AuthinkNavigationService _navigationService;
        public Uri SoundUrl { get; set; }

        public RewardViewModel(AuthinkNavigationService navigationService)
        {
            _navigationService = navigationService;
            this.TempRewordCommand = new RelayCommand(Continue);
            //this.SoundUrl = (bool)ApplicationData.Current.LocalSettings.Values["IsRewardSoundEnabled"] ? new Uri("ms-appx:///Resources/Sounds/aplauz-dugi.mp3") : null;
        }
    }
}