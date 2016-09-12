using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using AuThink.Desktop.Core;
using AuThink.Desktop.Core.Entities;
using AuThink.Desktop.Services;
using Authink.Desktop.Services;
using AuThink.Desktop.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace AuThink.Desktop.ViewModels.GameViewModels
{
    public partial class DetectDifferentItemsViewModel: ViewModelBase
    {
        private async void ItemClick(RoutedEventArgs e)
        {
            var list = (ListView)e.OriginalSource;
            var selectedPicture = (DetectSamePicture)e.Source;
            var container = list.Parent as StackPanel;

            //BravoTalker = (kontejner.Parent as Grid).Children.First(child => (child is MediaElement)) as MediaElement;

            //var picture = container.Children.FirstOrDefault(x => x is Image) as Image;

            if (selectedPicture.IsAnswer)
            {
                _counter++;
                //picture.Source = new BitmapImage(new Uri("/Resources/Nagradni ekran/checkmark.png", UriKind.RelativeOrAbsolute));
                //BravoTalker.Source = new Uri("ms-appx:///Resources/Sounds/bravo.mp3");
                //BravoTalker.Play();

                list.IsHitTestVisible = false;
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

        private List<DetectDifferentPicture> GeneratePicturesRow(List<Picture.AnswerPicture> picturesData)
        {
            var correctPicture = _workingCopy.Select(picture => new DetectDifferentPicture(picture.Url, picture.Id, true))
                                            .First();

            _workingCopy.Remove(_workingCopy.First());

            if (!_workingCopy.Any())
            {
                _workingCopy = picturesData.Select(picture => picture).ToList();
            }

            var result = new List<DetectDifferentPicture>();

            for (var i = 0; i < picturesData.Count; i++)
            {
                result.Add(_workingCopy.Select(picture => new DetectDifferentPicture(picture.Url, picture.Id, false)).First());
            }

            result.Add(correctPicture);
            result.Shuffle();

            return result;
        }

        private void TransformPicturesDataToModelData()
        {
            _workingCopy = new List<Picture.AnswerPicture>(_pictures);

            PicturesFirstList = new ObservableCollection<DetectDifferentPicture>(GeneratePicturesRow(_pictures));
            PicturesSecondList = new ObservableCollection<DetectDifferentPicture>(GeneratePicturesRow(_pictures));
            PicturesThirdList = new ObservableCollection<DetectDifferentPicture>(GeneratePicturesRow(_pictures));
            PicturesFourthList = new ObservableCollection<DetectDifferentPicture>(GeneratePicturesRow(_pictures));
        }

        private void Init()
        {
            _pictures = _pictureQueries.GetAllPicturesForTask(GameState.GetTask())
                                          .Select(picture => (Picture.AnswerPicture)picture)
                                          .ToList();

//            SoundUrl = SoundServices.GetInstructionsSoundUrl
//            (
//                sound: taskQueries.GetSingle_byId(GameState.GetTask()).VoiceCommand
//            );

            TransformPicturesDataToModelData();
        }
    }

    public partial class DetectDifferentItemsViewModel
    {
        public DetectDifferentItemsViewModel
        (
            IPictureQueries pictureQueries,
            ITaskQueries taskQueries,
            AuthinkNavigationService navigationService
        )
        {
            _taskQueries = taskQueries;
            _pictureQueries = pictureQueries;
            _navigationService = navigationService;

            ItemClickCommand = new RelayCommand<RoutedEventArgs>(ItemClick);

            Init();
        }

        private readonly ITaskQueries _taskQueries;
        private readonly IPictureQueries _pictureQueries;
        private readonly AuthinkNavigationService _navigationService;
        public Uri SoundUrl { get; set; }

        private List<Picture.AnswerPicture> _workingCopy { get; set; }
        private List<Picture.AnswerPicture> _pictures { get; set; }

        private static int _counter = 0;

        public DetectDifferentPicture CorrectFirstList { get; set; }
        public DetectDifferentPicture CorrectSecondList { get; set; }
        public DetectDifferentPicture CorrectThirdList { get; set; }
        public DetectDifferentPicture CorrectFourthList { get; set; }
        public ObservableCollection<DetectDifferentPicture> PicturesFirstList { get; set; }
        public ObservableCollection<DetectDifferentPicture> PicturesSecondList { get; set; }
        public ObservableCollection<DetectDifferentPicture> PicturesThirdList { get; set; }
        public ObservableCollection<DetectDifferentPicture> PicturesFourthList { get; set; }

        public RelayCommand<RoutedEventArgs> ItemClickCommand { get; set; }
    }

    public class DetectDifferentPicture
    {
        public DetectDifferentPicture
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
