using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using AuThink.Desktop.Core;
using AuThink.Desktop.Core.Entities;
using AuThink.Desktop.Services;
using Authink.Desktop.Services;
using AuThink.Desktop.Views;
using GalaSoft.MvvmLight;
using GongSolutions.Wpf.DragDrop;
using GongSolutions.Wpf.DragDrop.Utilities;
using PropertyChanged;


namespace AuThink.Desktop.ViewModels.GameViewModels
{
    public partial class PairHalfsViewModel: ViewModelBase, IDragSource, IDropTarget
    {
        async private void TransformPicturesDataToModelData(List<Picture> picturesData)
        {
            foreach (var picture in picturesData)
            {
                var halves = await PictureService.GetHalves(picture);

                this.PairPictureCollection.Add(new PairHalfsPicture(picture.Id, halves.Item2, halves.Item1, picture.Url, picture.Id.ToString()));

            }

            this.PairPictureCollection.Shuffle();
        }

        private void Init()
        {
            var pictures = _pictureQueries.GetAllPicturesForTask(GameState.GetTask())
                                         .Select(picture => picture)
                                         .ToList();

            SoundUrl = SoundServices.GetInstructionsSoundUrl
            (
                sound: _taskQueries.GetSingleById(GameState.GetTask()).VoiceCommand
            );

            TransformPicturesDataToModelData(pictures);

            PictureCount = pictures.Count();
        }

	    private IDragInfo _DragInfo;

		public virtual void StartDrag(IDragInfo dragInfo)
		{
			var itemCount = dragInfo.SourceItems.Cast<object>().Count();

			if (itemCount == 1)
			{
				dragInfo.Data = dragInfo.SourceItems.Cast<object>().First();
			}
			else if (itemCount > 1)
			{
				dragInfo.Data = TypeUtilities.CreateDynamicallyTypedList(dragInfo.SourceItems);
			}

			dragInfo.Effects = (dragInfo.Data != null) ?
								 DragDropEffects.Copy | DragDropEffects.Move :
								 DragDropEffects.None;

			_DragInfo = dragInfo;
		}

		/// <summary>
		/// Determines whether this instance [can start drag] the specified drag information.
		/// </summary>
		/// <param name="dragInfo">The drag information.</param>
		/// <returns></returns>
		public virtual bool CanStartDrag(IDragInfo dragInfo)
		{
			return true;
		}

		/// <summary>
		/// Notifies the drag handler that a drop has occurred.
		/// </summary>
		/// <param name="dropInfo">Information about the drop.</param>
		public virtual void Dropped(IDropInfo dropInfo)
		{
			var sourceItem = dropInfo.DragInfo.SourceItem as PairHalfsPicture;
			
			if (sourceItem != null && sourceItem.IsWholeImage)
				return;

			dropInfo.DragInfo.VisualSourceItem.Visibility = Visibility.Visible;
		}

		/// <summary>
		/// Notifies the drag handler that a drag has been aborted.
		/// </summary>
		public virtual void DragCancelled()
		{
			_DragInfo.VisualSourceItem.Visibility = Visibility.Visible;
		}

		/// <summary>
		/// Notifies that an exception has occurred upon dragging.
		/// </summary>
		/// <param name="exception">The exception that occurrred.</param>
		/// <returns>
		/// Boolean indicating whether the exception is handled in the drag handler.
		/// False will rethrow the exception.
		/// </returns>
		public virtual bool TryCatchOccurredException(Exception exception)
		{
			return false;
		}

	    public void DragOver(IDropInfo dropInfo)
	    {
		    var targetItem = dropInfo.TargetItem as PairHalfsPicture;
		    if (targetItem != null && !targetItem.IsWholeImage)
		    {
			    dropInfo.DropTargetAdorner = DropTargetAdorners.Highlight;
			    dropInfo.Effects = DragDropEffects.Move;
		    }
	    }

	    public async void Drop(IDropInfo dropInfo)
	    {
		    var targetItem = dropInfo.TargetItem as PairHalfsPicture;
		    var sourceItem = dropInfo.DragInfo.SourceItem as PairHalfsPicture;

		    if (targetItem == null || sourceItem == null)
		    {
				dropInfo.DragInfo.VisualSourceItem.Visibility = Visibility.Visible;
			    return;
		    }

		    if (targetItem.UniquePairId == sourceItem.UniquePairId)
		    {
				dropInfo.DragInfo.VisualSourceItem.Visibility = Visibility.Collapsed;
				targetItem.IsWholeImage = true;
				SoundServices.Instance.PlayExcellent();
		    }

		    if (PairPictureCollection.All(item => item.IsWholeImage))
		    {
				await System.Threading.Tasks.Task.Delay(2000);
				_navigationService.NavigateTo(new RewardView());
		    }
			
	    }
    }

    public partial class PairHalfsViewModel
    {
        public PairHalfsViewModel
        (
            ITaskQueries taskQueries,
            IPictureQueries pictureQueries,
			AuthinkNavigationService navigationService
        )
        {
            _pictureQueries = pictureQueries;
            _taskQueries = taskQueries;
	        _navigationService = navigationService;
            this.PairPictureCollection = new ObservableCollection<PairHalfsPicture>();

            Init();
        }

        private readonly ITaskQueries _taskQueries;
        private readonly IPictureQueries _pictureQueries;
	    private readonly AuthinkNavigationService _navigationService;

        public int PictureCount { get; set; }
        public ObservableCollection<PairHalfsPicture> PairPictureCollection { get; set; }
        public Uri SoundUrl { get; set; }
    }

	[ImplementPropertyChanged]
    public class PairHalfsPicture
    {
        public PairHalfsPicture
        (
            int id,
            ImageSource rightImageSource,
            ImageSource leftImageSource,
            string wholeImageSource,
            string uniquepairid
        )
        {
            this.Id = id;
            this.RightImageSource = rightImageSource;
            this.LeftImageSource = leftImageSource;
            this.WholeImageSource = wholeImageSource;
            this.UniquePairId = uniquepairid;
        }
        public int Id { get; private set; }
        public ImageSource RightImageSource { get; private set; }
        public ImageSource LeftImageSource { get; private set; }
        public string WholeImageSource { get; set; }
        public string UniquePairId { get; private set; }
		public bool IsWholeImage { get; set; }
    }
}
