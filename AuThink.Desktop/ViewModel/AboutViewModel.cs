using AuThink.Desktop.Services;
using AuThink.Desktop.Settings;
using AuThink.Desktop.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace AuThink.Desktop.ViewModel
{
    public class AboutViewModel: ViewModelBase
    {
        public string AboutTextContent
        {
            get { return _aboutTextContent; }
            set
            {
                if (_aboutTextContent == value)
                {
                    return;
                }

                _aboutTextContent = value;
                this.RaisePropertyChanged("AboutTextContent");
            }
        }
        private string _aboutTextContent = Language.AboutPage.AboutTextContent();

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
        private string _backButtonContent = Language.AboutPage.BackButtonContent();

        public RelayCommand BackButtonCommand { get; private set; }
        private void Back()
        {
            var page = new MainMenu();
            _navigationService.NavigateTo(page);
        }

        private readonly AuthinkNavigationService _navigationService;
        public AboutViewModel
            (
                AuthinkNavigationService navigationService
            )
        {
            this._navigationService = navigationService;
            this.BackButtonCommand = new RelayCommand(Back);
        }
    }
}
