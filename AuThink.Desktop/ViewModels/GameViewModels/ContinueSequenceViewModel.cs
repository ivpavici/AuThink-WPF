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
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace AuThink.Desktop.ViewModels.GameViewModels
{
    public partial class ContinueSequenceViewModel: ViewModelBase
    {
        private void ItemClicked(MouseButtonEventArgs e)
        {
            var picture = (Picture.AnswerPicture)e.OriginalSource;
            //var source = (ListView)e.OriginalSource;

            //if (picture.IsAnswer)
            //{
            //    var pictureToUpdate = Pictures_Sequence.Last();
            //    pictureToUpdate.Url = picture.Url;

            //    Pictures_Sequence[Pictures_Sequence.IndexOf(pictureToUpdate)] = pictureToUpdate;

            //    SoundServices.Instance.Play();

            //    source.IsHitTestVisible = false;

            //    await System.Threading.Tasks.Task.Delay(2000);

            //    _navigationService.NavigateTo(typeof(RewardView));
            //}
        }

        public void TransformPicturesDataToModelData(List<Picture.AnswerPicture> picturesData)
        {
            picturesData.Shuffle();

            var randomIndex = Random.Next(1, picturesData.Count);
            this.CorrectPicture = picturesData[randomIndex];

            foreach (var picture in picturesData)
            {
                Pictures_OfferedAnswers.Add(picture);
            }

            for (var i = 0; i < randomIndex; i++)
            {
                picturesData.Add(picturesData[i]);
            }

            foreach (var picture in picturesData)
            {
                Pictures_Sequence.Add(picture);
            }

            Pictures_Sequence.Add(new Picture.AnswerPicture());

            this.CorrectPicture.IsAnswer = true;

            for (var i = 0; i < Pictures_OfferedAnswers.Count; i++)
            {
                if (Pictures_OfferedAnswers[i].Id == this.CorrectPicture.Id)
                {
                    Pictures_OfferedAnswers[i].IsAnswer = true;
                }
            }

            this.Pictures_OfferedAnswers.Shuffle();
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

            this.Pictures_OfferedAnswers = new ObservableCollection<Picture.AnswerPicture>();
            this.Pictures_Sequence = new ObservableCollection<Picture.AnswerPicture>();

            //this.ItemClickCommand = new RelayCommand<MouseEventArgs>(ItemClicked);
            this.Random = random;

            Init();
        }

        public Picture.AnswerPicture CorrectPicture { get; set; }
        public ObservableCollection<Picture.AnswerPicture> Pictures_OfferedAnswers { get; set; }
        public ObservableCollection<Picture.AnswerPicture> Pictures_Sequence { get; set; }
        public RelayCommand<MouseEventArgs> ItemClickCommand { get; set; }
        public Uri SoundUrl { get; set; }
    }
}
