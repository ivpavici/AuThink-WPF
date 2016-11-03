using AuThink.Desktop.Services;
using AuThink.Desktop.Settings;
using AuThink.Desktop.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace AuThink.Desktop.ViewModels
{
    public partial class GameViewModel : ViewModelBase
    {
        public string PopupClose
        {
            get { return _popupClose; }
            set
            {
                if (_popupClose == value)
                {
                    return;
                }

                this.RaisePropertyChanged("Popup_close");
                _popupClose = value;
            }
        }
        private string _popupClose = Language.PausePopup.ClosePopupButtonContent();

        public string PopupMainMenu
        {
            get { return _popupMainMenu; }
            set
            {
                if (_popupMainMenu == value)
                {
                    return;
                }

                this.RaisePropertyChanged("Popup_mainMenu");
                _popupMainMenu = value;
            }
        }
        private string _popupMainMenu = Language.PausePopup.MainMenuButtonContent();

        public string PopupTestMenu
        {
            get { return _popupTestMenu; }
            set
            {
                if (_popupTestMenu == value)
                {
                    return;
                }

                this.RaisePropertyChanged("Popup_testMenu");
                _popupTestMenu = value;
            }
        }
        private string _popupTestMenu = Language.PausePopup.TestListButtonContent();

        public string PopupSettings
        {
            get { return _popupSettings; }
            set
            {
                if (_popupSettings == value)
                {
                    return;
                }

                this.RaisePropertyChanged("Popup_settings");
                _popupSettings = value;
            }
        }
        private string _popupSettings = Language.PausePopup.SettingsButtonContent();

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

        public RelayCommand PopupButtonMainMenuCommand { get; set; }
        private void PopupButtonMainMenu()
        {
            _navigation.NavigateTo(new MainMenu());
        }

        public RelayCommand PopupButtonTestMenuCommand { get; set; }
        private void PopupButtonTestMenu()
        {
            _navigation.NavigateTo(new TestListView());
        }
    }

    public partial class GameViewModel
    {
        private readonly AuthinkNavigationService _navigation;

        public GameViewModel
        (
            AuthinkNavigationService navigation
        )
        {
            _navigation = navigation;

            this.ClosePopupCommand = new RelayCommand(ClosePopup);
            this.OpenPopupCommand = new RelayCommand(OpenPopup);
            this.PopupButtonMainMenuCommand = new RelayCommand(PopupButtonMainMenu);
            this.PopupButtonTestMenuCommand = new RelayCommand(PopupButtonTestMenu);
            this.ExitCommand = new RelayCommand(Exit);
        }
    }
}
