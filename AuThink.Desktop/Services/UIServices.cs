using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using AuThink.Desktop.Core.Entities;


namespace AuThink.Desktop.Services
{
//    public class PictureService
//    {
//        async static public Task<Tuple<ImageSource, ImageSource>> GetHalves(ent.Picture picture)
//        {
//            IRandomAccessStream stream;

//            if (picture.Url.StartsWith("https://"))
//            {
//                var client = new HttpClient();

//                var request = new HttpRequestMessage(HttpMethod.Get, picture.Url);
//                var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);

//                var randomAccessStream = new InMemoryRandomAccessStream();
//                var writer = new DataWriter(randomAccessStream.GetOutputStreamAt(0));
//                writer.WriteBytes(await response.Content.ReadAsByteArrayAsync());
//                await writer.StoreAsync();

//                stream = randomAccessStream;
//            }
//            else
//            {
//                var storageFile = await StorageFile.GetFileFromApplicationUriAsync(new Uri(picture.Url));

//                stream = await storageFile.OpenReadAsync();
//            }

//            using (stream)
//            {
//                var decoder = await BitmapDecoder.CreateAsync(stream);

//                var newWidth = decoder.PixelWidth / 2;
//                var newHeight = decoder.PixelHeight;

//                var leftPixels = await _GetPixelData(decoder, 0, 0, newWidth, newHeight);

//                // Stream the left part bytes into a WriteableBitmap 
//                var leftCropBmp = new WriteableBitmap((int)newWidth, (int)newHeight);
//                var leftPixStream = leftCropBmp.PixelBuffer.AsStream();
//                leftPixStream.Write(leftPixels, 0, (int)(newWidth * newHeight * 4));

//                var rightPixels = await _GetPixelData(decoder, newWidth, 0, newWidth, newHeight);

//                // Stream the right part bytes into a WriteableBitmap 
//                var rightCropBmp = new WriteableBitmap((int)newWidth, (int)newHeight);
//                var rightPixStream = rightCropBmp.PixelBuffer.AsStream();
//                rightPixStream.Write(rightPixels, 0, (int)(newWidth * newHeight * 4));

//                return new Tuple<ImageSource, ImageSource>(leftCropBmp, rightCropBmp);
//            }
//        }

//        async static private Task<byte[]> _GetPixelData(BitmapDecoder decoder, uint startPointX, uint startPointY, uint width, uint height)
//        {
//            return await _GetPixelData(decoder, startPointX, startPointY, width, height, decoder.PixelWidth, decoder.PixelHeight);
//        }

//        async static private Task<byte[]> _GetPixelData(BitmapDecoder decoder, uint startPointX, uint startPointY, uint width, uint height, uint scaledWidth, uint scaledHeight)
//        {
//            var transform = new BitmapTransform();
//            var bounds = new BitmapBounds
//            {
//                X = startPointX,
//                Y = startPointY,
//                Height = height,
//                Width = width,
//            };
//            transform.Bounds = bounds;

//            transform.ScaledWidth = scaledWidth;
//            transform.ScaledHeight = scaledHeight;

//            // Get the cropped pixels within the bounds of transform. 
//            var pix = await decoder.GetPixelDataAsync(
//                BitmapPixelFormat.Bgra8,
//                BitmapAlphaMode.Straight,
//                transform,
//                ExifOrientationMode.IgnoreExifOrientation,
//                ColorManagementMode.ColorManageToSRgb);
//            var pixels = pix.DetachPixelData();

//            return pixels;
//        }
//    }

    public class PopUpService
    {
        private static volatile PopUpService _instance;
        private Storyboard _storyboard;
        public bool IsInitialized { get; private set; }
    
        private PopUpService() { }
    
        public static PopUpService Instance
        {
            get { return _instance ?? (_instance = new PopUpService()); }
        }
    
        public void Initialize(Storyboard storyboard)
        {
            if (storyboard == null)
            {
                throw new ArgumentNullException("storyboard");
            }
    
            _storyboard = storyboard;
            this.IsInitialized = true;
        }
    
        public void Show()
        {
            if (!this.IsInitialized)
            {
                throw new InvalidOperationException("Storyboard first needs to be initialized!");
            }
    
            _storyboard.Begin();
        }
    
        public void Close()
        {
            _storyboard.Begin();
        }
    }

    public class SoundServices
    {
        private static volatile SoundServices _instance;
        private MediaElement _mediaElement;
        public bool IsInitialized { get; private set; }

        private SoundServices() { }

        public static SoundServices Instance
        {
            get { return _instance ?? (_instance = new SoundServices()); }
        }

        public void Initialize(MediaElement mediaElement)
        {
            if (mediaElement == null)
            {
                throw new ArgumentNullException("mediaElement");
            }

            _mediaElement = mediaElement;
            _mediaElement.Source = AuThink.Desktop.Properties.Settings.Default.Language == "En"
                                      ? new Uri(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/excellent.mp3"))
                                      : new Uri(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/bravo.mp3"));

            this.IsInitialized = true;
        }

        public void Play()
        {
            if (!this.IsInitialized)
            {
                throw new InvalidOperationException("Player first needs to be initialized!");
            }

            if (AuThink.Desktop.Properties.Settings.Default.IsRewardSoundEnabled)
            {
                _mediaElement.Play();
            }
        }

        public static Uri GetInstructionsSoundUrl(Sound sound)
        {
            return
                sound != null && AuThink.Desktop.Properties.Settings.Default.IsInstructionSoundEnabled
                ? new Uri(sound.Url)
                : null;
        }
    }
}
