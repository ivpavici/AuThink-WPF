using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AuThink.Desktop.Core;
using AuThink.Desktop.Core.Entities;
using AuThink.Desktop.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace AuThink.Desktop.ViewModels.GameViewModels
{
    public partial class DetectSameItemsViewModel: ViewModelBase
    {
        public void LoadedUserControl(RoutedEventArgs e)
        {
            var majka = e.OriginalSource;
        }
    }

    public partial class DetectSameItemsViewModel
    {
        private readonly AuthinkNavigationService _navigationService;
        private List<Picture.AnswerPicture> _workingCopy { get; set; }
        private List<Picture.AnswerPicture> _pictures { get; set; }

        public DetectSameItemsViewModel
        (
            IPictureQueries pictureQueries,
            AuthinkNavigationService navigationService
        )
        {

            _navigationService = navigationService;

            _pictures = pictureQueries.GetAllPicturesForTask(GameState.GetTask())
                .Select(picture => (Picture.AnswerPicture)picture)
                                         .ToList();
            _workingCopy = new List<Picture.AnswerPicture>(_pictures);

            PicturesFirstList = new ObservableCollection<DetectSamePicture>(GetPictures());
            PicturesSecondList = new ObservableCollection<DetectSamePicture>(GetPictures());
            PicturesThirdList = new ObservableCollection<DetectSamePicture>(GetPictures());
            PicturesFourthList = new ObservableCollection<DetectSamePicture>(GetPictures());

            //ItemClickCommand = new RelayCommand<ItemClickEventArgs>(ItemClick);
            LoadedUserControlCommand = new RelayCommand<RoutedEventArgs>(LoadedUserControl);
        }

        public ObservableCollection<DetectSamePicture> PicturesFirstList { get; set; }
        public ObservableCollection<DetectSamePicture> PicturesSecondList { get; set; }
        public ObservableCollection<DetectSamePicture> PicturesThirdList { get; set; }
        public ObservableCollection<DetectSamePicture> PicturesFourthList { get; set; }

        //public RelayCommand<ItemClickEventArgs> ItemClickCommand { get; set; }
        public RelayCommand<RoutedEventArgs> LoadedUserControlCommand { get; set; }

        public List<DetectSamePicture> GetPictures()
        {

        }
    }

    public class DetectSamePicture
    {
        public DetectSamePicture
        (
            string url,
            int id,
            bool isAnswer
        )
        {
            this.Url = url;
            this.Id = id;
            this.IsAnswer = isAnswer;
        }
        public string Url { get; set; }
        public int Id { get; set; }
        public bool IsAnswer { get; set; }
    }
}
