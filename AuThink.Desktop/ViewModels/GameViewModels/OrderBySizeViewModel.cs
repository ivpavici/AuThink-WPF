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
    public partial class OrderBySizeViewModel: ViewModelBase
    {
        private async void ItemClick(RoutedEventArgs e)
        {
            var source = (ListView)e.Source;
            var selectedPicture = (OrderBySizePicture) source.SelectedItems[0];

            if (selectedPicture.Index == CurrentIndex)
            {
                //SoundServices.Instance.Play();

                this.SelectedPictures[CurrentIndex] = selectedPicture;
                this.Pictures.Remove(selectedPicture);

                CurrentIndex++;
            }

            if (!Pictures.Any())
            {
                await System.Threading.Tasks.Task.Delay(2000);

                _navigationService.NavigateTo(new RewardView());
            }
        }

        private void TransformPicturesDataToModelData(Picture.AnswerPicture pictureData, int taskDifficulty)
        {
            var knownImageSizeMappings = new Dictionary<int, int>()
            {
                {0, 75}, {1, 100}, {2, 125}, {3, 150}, {4, 175}, {5, 200}
            };

            for (var i = 0; i < taskDifficulty; i++)
            {
                Pictures.Add(new OrderBySizePicture(pictureData.Id, pictureData.Url, i, knownImageSizeMappings[i], knownImageSizeMappings[i]));
                this.SelectedPictures.Add(new OrderBySizePicture(0, "ms-appx:///Resources/placeholder.png", 0, 150, 150));
            }

            this.Pictures.Shuffle();
        }

        private void Init()
        {
            var task = _taskQueries.GetSingleById(GameState.GetTask()); ;
            var picture = _pictureQueries.GetAllPicturesForTask(GameState.GetTask())
                                         .Select(x => (Picture.AnswerPicture)x)
                                         .First();

            SoundUrl = SoundServices.GetInstructionsSoundUrl(task.VoiceCommand);

            TransformPicturesDataToModelData
            (
                pictureData: picture,
                taskDifficulty: task.Difficulty
            );
        }
    }

    public partial class OrderBySizeViewModel
    {
        public OrderBySizeViewModel
        (
            IPictureQueries pictureQueries,
            ITaskQueries taskQueries,
            AuthinkNavigationService navigationService 
        )
        {
            _pictureQueries = pictureQueries;
            _taskQueries = taskQueries;
            _navigationService = navigationService;

            this.CurrentIndex = 0;

            this.Pictures = new ObservableCollection<OrderBySizePicture>();
            this.SelectedPictures = new ObservableCollection<OrderBySizePicture>();

            this.ItemClickCommand = new RelayCommand<RoutedEventArgs>(ItemClick);

            Init();
        }

        private readonly IPictureQueries _pictureQueries;
        private readonly ITaskQueries _taskQueries;
        private readonly AuthinkNavigationService _navigationService;

        private int CurrentIndex { get; set; }

        public ObservableCollection<OrderBySizePicture> Pictures { get; set; }
        public ObservableCollection<OrderBySizePicture> SelectedPictures { get; set; }

        public RelayCommand<RoutedEventArgs> ItemClickCommand { get; set; }
        public Uri SoundUrl { get; set; }
    }

    public class OrderBySizePicture
    {
        public OrderBySizePicture
        (
            int id,
            string url,
            int index,
            int height,
            int width
         )
        {
            this.Id = id;
            this.Url = url;
            this.Index = index;
            this.Height = height;
            this.Width = width;
        }
        public int Id { get; private set; }
        public string Url { get; private set; }
        public int Index { get; private set; }
        public int Height { get; private set; }
        public int Width { get; private set; }
    }
}
