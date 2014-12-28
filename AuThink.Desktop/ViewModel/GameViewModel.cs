using AuThink.Desktop.Services;
using AuThink.Desktop.Settings;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace AuThink.Desktop.ViewModel
{
    public class GameViewModel : ViewModelBase
    {
        public GameViewModel
        (
            AuthinkNavigationService navigation
        )
        {
            this.navigation = navigation;

            this.ClosePopupCommand = new RelayCommand(ClosePopup);
            this.OpenPopupCommand = new RelayCommand(OpenPopup);
            this.PopupButton_mainMenuCommand = new RelayCommand(PopupButton_mainMenu);
            this.PopupButton_testMenuCommand = new RelayCommand(PopupButton_testMenu);
            this.ExitCommand = new RelayCommand(Exit);
        }

        private readonly AuthinkNavigationService navigation;

        public string Popup_close
        {
            get { return _popup_close; }
            set
            {
                if (_popup_close == value)
                {
                    return;
                }

                this.RaisePropertyChanged("Popup_close");
                _popup_close = value;
            }
        }

        private string _popup_close = Language.PausePopup.ClosePopupButtonContent();
        public string Popup_mainMenu
        {
            get { return _popup_mainMenu; }
            set
            {
                if (_popup_mainMenu == value)
                {
                    return;
                }

                this.RaisePropertyChanged("Popup_mainMenu");
                _popup_mainMenu = value;
            }
        }
        private string _popup_mainMenu = Language.PausePopup.MainMenuButtonContent();

        public string Popup_testMenu
        {
            get { return _popup_testMenu; }
            set
            {
                if (_popup_testMenu == value)
                {
                    return;
                }

                this.RaisePropertyChanged("Popup_testMenu");
                _popup_testMenu = value;
            }
        }
        private string _popup_testMenu = Language.PausePopup.TestListButtonContent();

        public string Popup_settings
        {
            get { return _Popup_settings; }
            set
            {
                if (_Popup_settings == value)
                {
                    return;
                }

                this.RaisePropertyChanged("Popup_settings");
                _Popup_settings = value;
            }
        }
        private string _Popup_settings = Language.PausePopup.SettingsButtonContent();

        public RelayCommand OpenPopupCommand { get; set; }
        private void OpenPopup()
        {
            PopUpService.Instance.Show();
        }

        public RelayCommand ClosePopupCommand { get; set; }
        private void ClosePopup()
        {
            PopUpService.Instance.Close();
        }

        public RelayCommand ExitCommand { get; set; }
        private void Exit()
        {
            //Application.Current.Exit();
        }

        public RelayCommand PopupButton_mainMenuCommand { get; set; }
        private void PopupButton_mainMenu()
        {
            //navigation.NavigateTo(typeof(MainPage));
        }

        public RelayCommand PopupButton_testMenuCommand { get; set; }
        private void PopupButton_testMenu()
        {
            //navigation.NavigateTo(typeof(TestListView));
        }
    }
}
