using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
    public partial class PairSameItemsViewModel: ViewModelBase, IDragSource, IDropTarget
    {
        private void TransformTaskDataToViewModelData()
        {
            var pictures = _pictureQueries.GetAllPicturesForTask(GameState.GetTask())
                           .Select(picture => (Picture.AnswerPicture)picture)
                           .ToList();

            SoundUrl = SoundServices.GetInstructionsSoundUrl
            (
                sound: _taskQueries.GetSingleById(GameState.GetTask()).VoiceCommand
            );

            foreach (var picture in pictures)
            {
                var currentPictureIndex = pictures.ToList().IndexOf(picture);

                ItemsSelectionList.Add(new PairSameItemsPicture(picture.Id, picture.Url, currentPictureIndex.ToString()));

                if (currentPictureIndex < 3)
                {
                    this.ItemsLeftEmpty.Add(new PairSameItemsPicture(picture.Id, picture.Url, currentPictureIndex.ToString()));
                }
                else if (currentPictureIndex >= 3)
                {
                    this.ItemsRightEmpty.Add(new PairSameItemsPicture(picture.Id, picture.Url, currentPictureIndex.ToString()));
                }
            }

            foreach (var picture in pictures)
            {
                var currentPictureIndex = pictures.ToList().IndexOf(picture);

                if (currentPictureIndex < 3)
                {
                    this.ItemsLeft.Add
                    (
                        new PairSameItemsPicture(picture.Id, picture.Url, currentPictureIndex.ToString())
                    );
                }
                else if (currentPictureIndex >= 3)
                {
                    this.ItemsRight.Add
                    (
                       new PairSameItemsPicture(picture.Id, picture.Url, currentPictureIndex.ToString())
                    );
                }
            }
            this.ItemsSelectionList.Shuffle();
        }

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
			var sourceItem = dropInfo.DragInfo.SourceItem as PairSameItemsPicture;

			if (sourceItem != null && sourceItem.IsRight)
				return;

		}

		/// <summary>
		/// Notifies the drag handler that a drag has been aborted.
		/// </summary>
		public virtual void DragCancelled()
		{
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
			var targetItem = dropInfo.TargetItem as PairSameItemsPicture;
			if (targetItem != null && !targetItem.IsRight)
			{
				dropInfo.DropTargetAdorner = DropTargetAdorners.Highlight;
				dropInfo.Effects = DragDropEffects.Move;
			}
		}

		public async void Drop(IDropInfo dropInfo)
		{
			var targetItem = dropInfo.TargetItem as PairSameItemsPicture;
			var sourceItem = dropInfo.DragInfo.SourceItem as PairSameItemsPicture;

			if (targetItem == null || sourceItem == null)
			{
				dropInfo.DragInfo.VisualSourceItem.Visibility = Visibility.Visible;
				return;
			}

			if (targetItem.UniquePairId == sourceItem.UniquePairId)
			{
				dropInfo.DragInfo.VisualSourceItem.Visibility = Visibility.Collapsed;
				targetItem.IsRight = true;
				SoundServices.Instance.PlayExcellent();
			}

			if (ItemsLeftEmpty.All(item => item.IsRight) && (!ItemsRightEmpty.Any() || ItemsRightEmpty.All(item => item.IsRight)))
			{
				await System.Threading.Tasks.Task.Delay(2000);
				_navigationService.NavigateTo(new RewardView());
			}

		}
    }

    public partial class PairSameItemsViewModel
    {
        public PairSameItemsViewModel
        (
            IPictureQueries pictureQueries,
            ITaskQueries taskQueries,
            AuthinkNavigationService navigationService
        )
        {
            _pictureQueries = pictureQueries;
            _taskQueries = taskQueries;
            _navigationService = navigationService;

            this.ItemsLeft = new ObservableCollection<PairSameItemsPicture>();
            this.ItemsRight = new ObservableCollection<PairSameItemsPicture>();
            this.ItemsLeftEmpty = new ObservableCollection<PairSameItemsPicture>();
            this.ItemsRightEmpty = new ObservableCollection<PairSameItemsPicture>();
            this.ItemsSelectionList = new ObservableCollection<PairSameItemsPicture>();

            TransformTaskDataToViewModelData();
        }

        private readonly ITaskQueries _taskQueries;
        private readonly IPictureQueries _pictureQueries;
        private readonly AuthinkNavigationService _navigationService;
        public ObservableCollection<PairSameItemsPicture> ItemsLeft { get; private set; }
        public ObservableCollection<PairSameItemsPicture> ItemsLeftEmpty { get; private set; }

        public ObservableCollection<PairSameItemsPicture> ItemsRight { get; private set; }
        public ObservableCollection<PairSameItemsPicture> ItemsRightEmpty { get; private set; }

        public ObservableCollection<PairSameItemsPicture> ItemsSelectionList { get; set; }
        public Uri SoundUrl { get; set; }
    }

	[ImplementPropertyChanged]
    public class PairSameItemsPicture
    {
        public PairSameItemsPicture
        (
            int id,
            string url,
            string uniquepairid
        )
        {
            this.Id = id;
            this.Url = url;
            this.UniquePairId = uniquepairid;
        }

        public int Id { get; private set; }
        public string Url { get; private set; }
        public string UniquePairId { get; private set; }

		public bool IsRight { get; set; }
    }
}
