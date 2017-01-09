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
using AuThink.Desktop.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using PropertyChanged;

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

            var transformedPicturesData = picturesData.Select(picture =>
            {
	            var detectColorPicture = new DetectColorPicture
		            (
		            url: picture.Url,
		            id: picture.Id,
		            picturesCount: picturesData.Count(),
		            colors: picture.Colors
		            );

	            detectColorPicture.ColorDetected += async (sender, args) =>
	            {
		            if (PicturesWithColors.All(item => item.IsRight))
		            {
						SoundServices.Instance.PlayExcellent();

						await System.Threading.Tasks.Task.Delay(2000);

						_navigationService.NavigateTo(new RewardView());
		            }
		            else
		            {
						SoundServices.Instance.PlayExcellent();
		            }
	            };

	            return detectColorPicture;
            }
			).ToList();

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
	    private readonly AuthinkNavigationService _navigationService;

	    public DetectColorsViewModel
        (
            ITaskQueries taskQueries,
            IPictureQueries pictureQueries,
			AuthinkNavigationService navigationService
        )
        {
            this.taskQueries = taskQueries;
            this.pictureQueries = pictureQueries;
		    _navigationService = navigationService;

		    Init();
        }


        public Uri SoundUrl { get; set; }
        public ObservableCollection<DetectColorPicture> PicturesWithColors { get; set; }
    }

	[ImplementPropertyChanged]
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

        private int picturesCount;
        private readonly AuthinkNavigationService _navigationService;

        public string Url { get; set; }
        public int Id { get; set; }
        public List<Color> Colors { get; set; }
        public RelayCommand<object> EllipseButtonClickCommand { get; private set; }
		public bool IsRight { get; set; }

		public event EventHandler ColorDetected;

        private async void EllipseButtonClick(object e)
        {
	        var color = e as Color;
	        if (color.IsCorrect)
	        {
		        IsRight = true;

		        var colorDetectedEvent = ColorDetected;
				if(colorDetectedEvent != null)
					colorDetectedEvent.Invoke(this, null);
	        }
        }
    }
}
