using System;
using System.Windows.Controls;
using AuThink.Desktop.Services;
using AuThink.Desktop.ViewModels.GameViewModels;

namespace AuThink.Desktop.Views.GameViews
{
    /// <summary>
    /// Interaction logic for PairSameItemsUserControl.xaml
    /// </summary>
    public partial class PairSameItemsUserControl : UserControl
    {
        public int numberOfSuccessfulDrops { get; set; }
        private PairSameItemsViewModel _vmodel;
        private AuthinkNavigationService _navigationService;

        public PairSameItemsUserControl()
        {
            InitializeComponent();
            _vmodel = (PairSameItemsViewModel)this.DataContext;
            _navigationService = new AuthinkNavigationService();
        }

        private async void DropSuccessful(object sender, EventArgs e)
        {
            numberOfSuccessfulDrops++;
            if (numberOfSuccessfulDrops == _vmodel.ItemsSelectionList.Count)
            {
                await System.Threading.Tasks.Task.Delay(2000);
                _navigationService.NavigateTo(new RewardView());
            }
        }
    }
}
