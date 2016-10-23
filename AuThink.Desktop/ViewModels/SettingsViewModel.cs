using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AuThink.Desktop.Services;
using AuThink.Desktop.Settings;
using AuThink.Desktop.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace AuThink.Desktop.ViewModels
{
    public partial class SettingsViewModel : ViewModelBase
    {
        public RelayCommand<string> ChangeLanguage { get; private set; }   
        private void LanguageSelectionChange(string languageAbbreviation)
        {
            AuThink.Desktop.Properties.Settings.Default.Language = languageAbbreviation;

            this.EnglishLanguage = Language.SettingsPage.Language.English();
            this.CroatianLanguage = Language.SettingsPage.Language.Croatian();
            this.SettingsText = Language.SettingsPage.SettingsText();
            this.BackButtonContent = Language.SettingsPage.BackButtonContent();
            this.ChooseLangText = Language.SettingsPage.ChooseLanText();
            this.RewardSoundButtonContentOff = Language.SettingsPage.SoundButtonContentOff();
            this.RewardSoundButtonContentOn = Language.SettingsPage.SoundButtonContentOn();
            this.RewardSoundText = Language.SettingsPage.RewardSoundText();
            this.InstructionsSoundText = Language.SettingsPage.InstructionSoundText();
            this.InstructionsSoundButtonContentOn = Language.SettingsPage.SoundButtonContentOn();
            this.InstructionsSoundButtonContentOff = Language.SettingsPage.SoundButtonContentOff();

            SetLanguageModel();
            AuThink.Desktop.Properties.Settings.Default.Save(); 
        }

        // Save language settings for Model
        private static void SetLanguageModel()
        {
            if (AuThink.Desktop.Properties.Settings.Default.Language == "Hr")
            {
                AuThink.Desktop.Model.Properties.Settings.Default.Language = "Hr";
                AuThink.Desktop.Model.Properties.Settings.Default.Save();
            }
            else
            {
                AuThink.Desktop.Model.Properties.Settings.Default.Language = "En";
                AuThink.Desktop.Model.Properties.Settings.Default.Save();
            }
        }

        public RelayCommand<string> ToggleRewardSoundEnableCommand { get; private set; }
        private void ToggleRewardSoundEnable(string isEnabled)
        {
            if (isEnabled == "true")
            {
                AuThink.Desktop.Properties.Settings.Default.IsRewardSoundEnabled = true;
                AuThink.Desktop.Properties.Settings.Default.Save();
            }
            else
            {
                AuThink.Desktop.Properties.Settings.Default.IsRewardSoundEnabled = false;
                AuThink.Desktop.Properties.Settings.Default.Save();
            }
        }

        public RelayCommand<string> ToggleInstructionSoundEnableCommand { get; private set; }
        private void ToggleInstructionSoundEnable(string isEnabled)
        {
            if (isEnabled == "true")
            {
                AuThink.Desktop.Properties.Settings.Default.IsInstructionSoundEnabled = true;
                AuThink.Desktop.Properties.Settings.Default.Save();
            }
            else
            {
                AuThink.Desktop.Properties.Settings.Default.IsInstructionSoundEnabled = false;
                AuThink.Desktop.Properties.Settings.Default.Save();
            }
        }

        public string CroatianLanguage
        {
            get { return _croatianLanguage; }
            set
            {
                if (_croatianLanguage == value)
                {
                    return;
                }

                _croatianLanguage = value;
                this.RaisePropertyChanged("CroatianLanguage");
            }
        }
        private string _croatianLanguage = Language.SettingsPage.Language.Croatian();
        
        public string EnglishLanguage
        {
            get { return _englishLanguage; }
            set
            {
                if (_englishLanguage == value)
                {
                    return;
                }

                _englishLanguage = value;
                this.RaisePropertyChanged("EnglishLanguage");
            }
        }
        private string _englishLanguage = Language.SettingsPage.Language.English();
        
        public string ChooseLangText
        {
            get { return _chooseLangText; }
            set
            {
                if (_chooseLangText == value)
                {
                    return;
                }

                _chooseLangText = value;
                this.RaisePropertyChanged("ChooseLangText");
            }
        }
        private string _chooseLangText = Language.SettingsPage.ChooseLanText();

        public string SettingsText
        {
            get { return _settingsText; }
            set
            {
                if (_settingsText == value)
                {
                    return;
                }

                _settingsText = value;
                this.RaisePropertyChanged("SettingsText");
            }
        }
        private string _settingsText = Language.SettingsPage.SettingsText();

        public string RewardSoundText
        {
            get { return _rewardSoundText; }
            set
            {
                if (_rewardSoundText == value)
                {
                    return;
                }

                _rewardSoundText = value;
                this.RaisePropertyChanged("RewardSoundText");
            }
        }
        private string _rewardSoundText = Language.SettingsPage.RewardSoundText();

        public string InstructionsSoundText
        {
            get { return _instructionsSoundText; }
            set
            {
                if (_instructionsSoundText == value)
                {
                    return;
                }

                _instructionsSoundText = value;
                this.RaisePropertyChanged("InstructionsSoundText");
            }
        }
        private string _instructionsSoundText = Language.SettingsPage.InstructionSoundText();

        public string RewardSoundButtonContentOn
        {
            get { return _rewardSoundButtonContentOn; }
            set
            {
                if (_rewardSoundButtonContentOn == value)
                {
                    return;
                }

                _rewardSoundButtonContentOn = value;
                this.RaisePropertyChanged("RewardSoundButtonContentOn");
            }
        }
        private string _rewardSoundButtonContentOn = Language.SettingsPage.SoundButtonContentOn();

        public string RewardSoundButtonContentOff
        {
            get { return _rewardSoundButtonContentOff; }
            set
            {
                if (_rewardSoundButtonContentOff == value)
                {
                    return;
                }

                _rewardSoundButtonContentOff = value;
                this.RaisePropertyChanged("RewardSoundButtonContentOff");
            }
        }
        private string _rewardSoundButtonContentOff = Language.SettingsPage.SoundButtonContentOff();

        public string InstructionsSoundButtonContentOn
        {
            get { return _instructionsSoundButtonContentOn; }
            set
            {
                if (_instructionsSoundButtonContentOn == value)
                {
                    return;
                }

                _instructionsSoundButtonContentOn = value;
                this.RaisePropertyChanged("InstructionsSoundButtonContentOn");
            }
        }
        private string _instructionsSoundButtonContentOn = Language.SettingsPage.SoundButtonContentOn();

        public string InstructionsSoundButtonContentOff
        {
            get { return _instructionsSoundButtonContentOff; }
            set
            {
                if (_instructionsSoundButtonContentOff == value)
                {
                    return;
                }

                _instructionsSoundButtonContentOff = value;
                this.RaisePropertyChanged("InstructionsSoundButtonContentOff");
            }
        }
        private string _instructionsSoundButtonContentOff = Language.SettingsPage.SoundButtonContentOff();

        public RelayCommand BackCommand { get; private set; }
        private void Back()
        {
            _navigationService.NavigateTo(new MainMenu());
        }

        public string BackButtonContent
        {
            get { return _backButtonContent; }
            set
            {
                if (_backButtonContent == value)
                {
                    return;
                }

                _backButtonContent = value;
                this.RaisePropertyChanged("BackButtonContent");
            }
        }
        private string _backButtonContent = Language.SettingsPage.BackButtonContent();
    }

    public partial class SettingsViewModel
    {
        private readonly AuthinkNavigationService _navigationService;

        public SettingsViewModel
        (
            AuthinkNavigationService navigationService
        )
        {
            _navigationService = navigationService;

            this.ChangeLanguage = new RelayCommand<string>(LanguageSelectionChange);
            this.ToggleRewardSoundEnableCommand = new RelayCommand<string>(ToggleRewardSoundEnable);
            this.ToggleInstructionSoundEnableCommand = new RelayCommand<string>(ToggleInstructionSoundEnable);
            this.BackCommand = new RelayCommand(Back);
        }
    }
}
