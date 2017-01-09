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
    public partial class VoiceCommandsViewModel : ViewModelBase
    {
        private async void ItemClicked(RoutedEventArgs e)
        {
            var source = (ListView)e.Source;
            // Refactor using .frstOrDefault()
            var picture = (Picture.AnswerPicture)source.SelectedItems[0];

            if (picture.IsAnswer)
            {
                source.IsHitTestVisible = false;
                //SoundServices.Instance.PlayExcellent();

                await System.Threading.Tasks.Task.Delay(2000);

                _navigationService.NavigateTo(new RewardView());
            }

        }
        private void TransformPicturesDataToModelData(List<Picture.AnswerPicture> picturesData)
        {
            picturesData.Shuffle();

            foreach (var picture in picturesData)
            {
                Pictures.Add(picture);
            }

            var correctPicture = picturesData.SingleOrDefault(picture => picture.IsAnswer);

            for (var i = 0; i < Pictures.Count; i++)
            {
                if (Pictures[i].Id == correctPicture.Id)
                {
                    Pictures[i].IsAnswer = true;
                }
            }
        }
        private void Init()
        {
            var pictures = _pictureQueries.GetAllPicturesForTask(GameState.GetTask())
                                          .Select(picture => (Picture.AnswerPicture)picture)
                                          .ToList();

            SoundUrl = SoundServices.GetInstructionsSoundUrl
            (
                sound: _taskQueries.GetSingleById(GameState.GetTask()).VoiceCommand
            );

            TransformPicturesDataToModelData
            (
                picturesData: pictures
            );
        }
        /// <summary>
        /// HAX
        /// </summary>
        public RelayCommand<object> ReplayVoiceInstructionCommand { get; set; }
        public void ReplayVoiceInstruction(object element)
        {
            var sound = element as MediaElement;
            sound.Position = TimeSpan.Zero;
            sound.Play();
        }
        //TODO:REFACTORAT
    }

    public partial class VoiceCommandsViewModel
    {
        public VoiceCommandsViewModel(
            IPictureQueries pictureQueries,
            ITaskQueries taskQueries,
            AuthinkNavigationService navigationService
        )
        {
            _pictureQueries = pictureQueries;
            _taskQueries = taskQueries;
            _navigationService = navigationService;

            this.ItemClickCommand = new RelayCommand<RoutedEventArgs>(ItemClicked);
            this.Pictures = new ObservableCollection<Picture.AnswerPicture>();

            this.ReplayVoiceInstructionCommand = new RelayCommand<object>(ReplayVoiceInstruction);

            Init();
        }

        private readonly IPictureQueries _pictureQueries;
        private readonly ITaskQueries _taskQueries;
        private readonly AuthinkNavigationService _navigationService;

        public ObservableCollection<Picture.AnswerPicture> Pictures { get; set; }
        public Uri SoundUrl { get; set; }

        public RelayCommand<RoutedEventArgs> ItemClickCommand { get; set; }
        public RelayCommand OnNavigatedToCommand { get; set; }
    }
}
