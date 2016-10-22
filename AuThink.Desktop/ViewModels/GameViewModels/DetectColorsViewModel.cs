using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuThink.Desktop.Core;
using AuThink.Desktop.Core.Entities;
using Authink.Desktop.Services;
using AuThink.Desktop.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace AuThink.Desktop.ViewModels.GameViewModels
{
    public partial class DetectColorsViewModel: ViewModelBase
    {
        private void Init()
        {
            var picturesData = pictureQueries.GetAllPicturesForTask(GameState.GetTask())
                                              .Select(picture => (Picture.ColorPicture)picture)
                                              .ToList();

            SoundUrl = SoundServices.GetInstructionsSoundUrl
            (
                sound: taskQueries.GetSingleById(GameState.GetTask()).VoiceCommand
            );

            TransformPicturesDataToModelData(picturesData);
        }

        private void TransformPicturesDataToModelData(List<Picture.ColorPicture> picturesData)
        {
            PicturesWithColors = new ObservableCollection<DetectColorPicture>();

            var transformedPicturesData = picturesData.Select(picture => new DetectColorPicture
            (
                url: picture.Url,
                id: picture.Id,
                picturesCount: picturesData.Count(),
                colors: picture.Colors
            )).ToList();

            foreach (var picture in transformedPicturesData)
            {
                this.PicturesWithColors.Add(picture);
            }
        }
    }

    public partial class DetectColorsViewModel
    {
        private readonly ITaskQueries taskQueries;
        private readonly IPictureQueries pictureQueries;

        public DetectColorsViewModel
        (
            ITaskQueries taskQueries,
            IPictureQueries pictureQueries
        )
        {
            this.taskQueries = taskQueries;
            this.pictureQueries = pictureQueries;

            Init();
        }

        public Uri SoundUrl { get; set; }
        public ObservableCollection<DetectColorPicture> PicturesWithColors { get; set; }
    }

    public class DetectColorPicture
    {
        public DetectColorPicture
        (
            string url,
            int id,
            int picturesCount,
            List<Color> colors
        )
        {
            this.Url = url;
            this.Id = id;
            this.picturesCount = picturesCount;
            this.Colors = colors;

            this.EllipseButtonClickCommand = new RelayCommand<object>(EllipseButtonClick);
            this._navigationService = new AuthinkNavigationService();

            this.Colors.Shuffle();
        }

        private static int _counter = 0;
        private int picturesCount;
        private readonly AuthinkNavigationService _navigationService;

        public string Url { get; set; }
        public int Id { get; set; }
        public List<Color> Colors { get; set; }
        public RelayCommand<object> EllipseButtonClickCommand { get; private set; }

        private async void EllipseButtonClick(object e)
        {
        }
    }
}
