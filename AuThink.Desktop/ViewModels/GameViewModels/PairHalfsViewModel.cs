using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using AuThink.Desktop.Core;
using AuThink.Desktop.Core.Entities;
using AuThink.Desktop.Services;
using Authink.Desktop.Services;
using GalaSoft.MvvmLight;

namespace AuThink.Desktop.ViewModels.GameViewModels
{
    public partial class PairHalfsViewModel: ViewModelBase
    {
        async private void TransformPicturesDataToModelData(List<Picture.PairHalfPicture> picturesData)
        {
            foreach (var picture in picturesData)
            {
//                var halves = await PictureService.GetHalves(picture);
//
//                this.PairPictureCollection.Add(new PairHalfsPicture(picture.Id, halves.Item2, halves.Item1, picture.Url, picture.Id.ToString()));

            }

            this.PairPictureCollection.Shuffle();
        }

        private void Init()
        {
            var pictures = _pictureQueries.GetAllPicturesForTask(GameState.GetTask())
                                         .Select(picture => (Picture.PairHalfPicture)picture)
                                         .ToList();

            SoundUrl = SoundServices.GetInstructionsSoundUrl
            (
                sound: _taskQueries.GetSingleById(GameState.GetTask()).VoiceCommand
            );

            TransformPicturesDataToModelData
            (
                picturesData: pictures
            );

            PictureCount = pictures.Count();
        }
    }

    public partial class PairHalfsViewModel
    {
        public PairHalfsViewModel
        (
            ITaskQueries taskQueries,
            IPictureQueries pictureQueries
        )
        {
            _pictureQueries = pictureQueries;
            _taskQueries = taskQueries;
            this.PairPictureCollection = new ObservableCollection<PairHalfsPicture>();

            Init();
        }

        private readonly ITaskQueries _taskQueries;
        private readonly IPictureQueries _pictureQueries;

        public int PictureCount { get; set; }
        public ObservableCollection<PairHalfsPicture> PairPictureCollection { get; set; }
        public Uri SoundUrl { get; set; }
    }

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
    }
}
