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
using GalaSoft.MvvmLight;

namespace AuThink.Desktop.ViewModels.GameViewModels
{
    public partial class PairSameItemsViewModel: ViewModelBase
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
    }
}
