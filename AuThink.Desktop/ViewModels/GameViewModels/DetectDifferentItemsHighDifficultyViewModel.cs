using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuThink.Desktop.Core;
using AuThink.Desktop.Core.Entities;
using AuThink.Desktop.Services;
using Authink.Desktop.Services;
using AuThink.Desktop.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace AuThink.Desktop.ViewModels.GameViewModels
{
    public partial class DetectDifferentItemsHighDifficultyViewModel: ViewModelBase
    {
//        private async void PointerPressed(PointerRoutedEventArgs e)
//        {
//            var img = (Image)e.OriginalSource;
//
//            if (this.CorrectPicture.Id == Convert.ToInt32(img.Tag))
//            {
//                img.IsHitTestVisible = false;
//
//                SoundServices.Instance.PlayExcellent();
//
//                await System.Threading.Tasks.Task.Delay(2000);
//
//                _navigationService.NavigateTo(new RewardView());
//            }
//        }

        public void TransformPicturesDataToModelData(List<Picture.AnswerPicture> picturesData)
        {
            var pictureCorrectAnswer = picturesData.FirstOrDefault(picture => picture.IsAnswer);
            var pictureWrongAnswer = picturesData.FirstOrDefault(picture => !picture.IsAnswer);

            for (var i = 0; i < 7; i++)
            {
                Pictures.Add(pictureWrongAnswer);
            }

            Pictures.Add(pictureCorrectAnswer);

            this.CorrectPicture = pictureCorrectAnswer;

            this.Pictures.Shuffle();
        }

        private void Init()
        {
            var picturesData = _pictureQueries.GetAllPicturesForTask(GameState.GetTask())
                                             .Select(picture => (Picture.AnswerPicture)picture)
                                             .ToList();

            SoundUrl = SoundServices.GetInstructionsSoundUrl
            (
                sound: _taskQueries.GetSingleById(GameState.GetTask()).VoiceCommand
            );

            TransformPicturesDataToModelData(picturesData);
        }
    }

    public partial class DetectDifferentItemsHighDifficultyViewModel
    {
        public DetectDifferentItemsHighDifficultyViewModel
        (
            IPictureQueries   pictureQueries,
            ITaskQueries      taskQueries,
            AuthinkNavigationService navigationService
        )
        {
            _pictureQueries    = pictureQueries;
            _taskQueries       = taskQueries;
            _navigationService = navigationService;

            this.Pictures              = new ObservableCollection<Picture.AnswerPicture>();
            //this.PointerPressedCommand = new RelayCommand<PointerRoutedEventArgs>(PointerPressed);

            Init();
        }

        private readonly IPictureQueries _pictureQueries;
        private readonly ITaskQueries _taskQueries;
        private readonly AuthinkNavigationService _navigationService;

        public Uri SoundUrl { get; set; }

        public ObservableCollection<Picture.AnswerPicture> Pictures { get; set; }
        public Picture.AnswerPicture CorrectPicture { get; set; }

        //public RelayCommand<PointerRoutedEventArgs> PointerPressedCommand { get; set; }
    }
}
