using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using AuThink.Desktop.Core;
using AuThink.Desktop.Core.Entities;
using AuThink.Desktop.Services;
using Authink.Desktop.Services;
using AuThink.Desktop.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace AuThink.Desktop.ViewModels.GameViewModels
{
    public partial class DetectSameItemsViewModel: ViewModelBase
    {
        //TODO check what is this
        public void LoadedUserControl(RoutedEventArgs e)
        {
            var majka = e.OriginalSource;
        }

        private async void ItemClick(RoutedEventArgs e)
        {
            var lista = (ListView)e.OriginalSource;
            var selectedPicture = (DetectSamePicture)e.Source;
            var container = lista.Parent as StackPanel;

            //BravoTalker = (kontejner.Parent as Grid).Children.First(child => (child is MediaElement)) as MediaElement;

            //var picture = container.Children.FirstOrDefault(x => x is Image) as Image;

            if (selectedPicture.IsAnswer)
            {
                _counter++;
                //picture.Source = new BitmapImage(new Uri("/Resources/Nagradni ekran/checkmark.png", UriKind.RelativeOrAbsolute));
                //BravoTalker.Source = new Uri("ms-appx:///Resources/Sounds/bravo.mp3");
                //BravoTalker.Play();

                lista.IsHitTestVisible = false;
            }
            else
            {
                //picture.Source = new BitmapImage(new Uri("/Resources/Nagradni ekran/crossmark.png", UriKind.RelativeOrAbsolute));
            }

            if (_counter == 4)
            {
                _counter = 0;
                await System.Threading.Tasks.Task.Delay(2000);
                _navigationService.NavigateTo(new RewardView());
            }
        }

        private List<DetectSamePicture> GeneratePicturesRow(List<Picture.AnswerPicture> picturesData)
        {
            var correctPicture = _workingCopy.Select(picture => new DetectSamePicture(picture.Url, picture.Id, true))
                                            .First();

            _workingCopy.Remove(_workingCopy.First());

            if (!_workingCopy.Any())
            {
                _workingCopy = picturesData.Select(picture => picture).ToList();
            }

            var result = new List<DetectSamePicture>();

            for (var i = 0; i < picturesData.Count; i++)
            {
                result.Add(_workingCopy.Select(picture => new DetectSamePicture(picture.Url, picture.Id, false)).First());
            }

            result.Add(correctPicture);
            result.Shuffle();

            return result;
        }

        private void TransformPicturesDataToModelData()
        {
            _workingCopy = new List<Picture.AnswerPicture>(_pictures);

            this.PicturesFirstList = new ObservableCollection<DetectSamePicture>(GeneratePicturesRow(_pictures));
            this.PicturesSecondList = new ObservableCollection<DetectSamePicture>(GeneratePicturesRow(_pictures));
            this.PicturesThirdList = new ObservableCollection<DetectSamePicture>(GeneratePicturesRow(_pictures));
            this.PicturesFourthList = new ObservableCollection<DetectSamePicture>(GeneratePicturesRow(_pictures));
        }

        private void Init()
        {
            _pictures = _pictureQueries.GetAllPicturesForTask(GameState.GetTask())
                                      .Select(picture => (Picture.AnswerPicture)picture)
                                      .ToList();

            SoundUrl = SoundServices.GetInstructionsSoundUrl
            (
                sound: _taskQueries.GetSingleById(GameState.GetTask()).VoiceCommand
            );

            TransformPicturesDataToModelData();
        }
    }

    public partial class DetectSameItemsViewModel
    {
        public DetectSameItemsViewModel
        (
            IPictureQueries pictureQueries,
            ITaskQueries taskQueries,
            AuthinkNavigationService navigationService
        )
        {
            _pictureQueries = pictureQueries;
            _taskQueries = taskQueries;
            _navigationService = navigationService;

            ItemClickCommand = new RelayCommand<RoutedEventArgs>(ItemClick);
            LoadedUserControlCommand = new RelayCommand<RoutedEventArgs>(LoadedUserControl);

            Init();
        }

        private static int _counter = 0;
        private readonly IPictureQueries _pictureQueries;
        private readonly ITaskQueries _taskQueries;
        private readonly AuthinkNavigationService _navigationService;
        public Uri SoundUrl { get; set; }

        private List<Picture.AnswerPicture> _workingCopy { get; set; }
        private List<Picture.AnswerPicture> _pictures { get; set; }

        public ObservableCollection<DetectSamePicture> PicturesFirstList { get; set; }
        public ObservableCollection<DetectSamePicture> PicturesSecondList { get; set; }
        public ObservableCollection<DetectSamePicture> PicturesThirdList { get; set; }
        public ObservableCollection<DetectSamePicture> PicturesFourthList { get; set; }

        public RelayCommand<RoutedEventArgs> ItemClickCommand { get; set; }
        public RelayCommand<RoutedEventArgs> LoadedUserControlCommand { get; set; }
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
