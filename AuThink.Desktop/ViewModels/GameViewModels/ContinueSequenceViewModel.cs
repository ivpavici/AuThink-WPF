using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using AuThink.Desktop.Core;
using AuThink.Desktop.Core.Entities;
using AuThink.Desktop.Services;
using Authink.Desktop.Services;
using AuThink.Desktop.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace AuThink.Desktop.ViewModels.GameViewModels
{
    public partial class ContinueSequenceViewModel: ViewModelBase
    {
        private async void ItemClicked(RoutedEventArgs e)
        {
            var source = (ListView)e.Source;
            // Refactor using .frstOrDefault()
            var picture = (Picture.AnswerPicture)source.SelectedItems[0];

            if (picture.IsAnswer)
            {
                var pictureToUpdate = PicturesSequence.Last();
                pictureToUpdate.Url = picture.Url;

                PicturesSequence[PicturesSequence.IndexOf(pictureToUpdate)] = pictureToUpdate;

                //SoundServices.Instance.Play();

                source.IsHitTestVisible = false;

                await System.Threading.Tasks.Task.Delay(2000);

                _navigationService.NavigateTo(new RewardView());
            }
        }

        public void TransformPicturesDataToModelData(List<Picture.AnswerPicture> picturesData)
        {
            picturesData.Shuffle();

            var randomIndex = Random.Next(1, picturesData.Count);
            this.CorrectPicture = picturesData[randomIndex];

            foreach (var picture in picturesData)
            {
                PicturesOfferedAnswers.Add(picture);
            }

            for (var i = 0; i < randomIndex; i++)
            {
                picturesData.Add(picturesData[i]);
            }

            foreach (var picture in picturesData)
            {
                PicturesSequence.Add(picture);
            }

            PicturesSequence.Add(new Picture.AnswerPicture());

            this.CorrectPicture.IsAnswer = true;

            for (var i = 0; i < PicturesOfferedAnswers.Count; i++)
            {
                if (PicturesOfferedAnswers[i].Id == this.CorrectPicture.Id)
                {
                    PicturesOfferedAnswers[i].IsAnswer = true;
                }
            }

            this.PicturesOfferedAnswers.Shuffle();
        }

        private void Init()
        {
            var picturesData = _pictureQueries.GetAllPicturesForTask(GameState.GetTask())
                                             .Select(picture => (Picture.AnswerPicture)picture)
                                             .ToList();

            //SoundUrl = SoundServices.GetInstructionsSoundUrl
            //(
            //    sound: taskQueries.GetSingle_byId(GameState.GetTask()).VoiceCommand
            //);

            TransformPicturesDataToModelData(picturesData);
        }
    }

    public partial class ContinueSequenceViewModel
    {
        private readonly IPictureQueries _pictureQueries;
        private readonly ITaskQueries _taskQueries;
        private readonly AuthinkNavigationService _navigationService;
        private Random Random { get; set; }

        public ContinueSequenceViewModel
        (
            IPictureQueries pictureQueries,
            ITaskQueries taskQueries,
            AuthinkNavigationService navigationService,
            Random random
        )
        {
            _pictureQueries = pictureQueries;
            _taskQueries = taskQueries;
            _navigationService = navigationService;

            this.PicturesOfferedAnswers = new ObservableCollection<Picture.AnswerPicture>();
            this.PicturesSequence = new ObservableCollection<Picture.AnswerPicture>();

            this.ItemClickCommand = new RelayCommand<RoutedEventArgs>(ItemClicked);
            this.Random = random;

            Init();
        }

        public Picture.AnswerPicture CorrectPicture { get; set; }
        public ObservableCollection<Picture.AnswerPicture> PicturesOfferedAnswers { get; set; }
        public ObservableCollection<Picture.AnswerPicture> PicturesSequence { get; set; }
        public RelayCommand<RoutedEventArgs> ItemClickCommand { get; set; }
        public Uri SoundUrl { get; set; }
    }
}
