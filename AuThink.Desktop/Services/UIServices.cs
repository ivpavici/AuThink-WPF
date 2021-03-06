﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using AuThink.Desktop.Core.Entities;


namespace AuThink.Desktop.Services
{
	public class PictureService
	{
		async static public Task<Tuple<ImageSource, ImageSource>> GetHalves(Picture picture)
		{
			//Stream imageStream;
			//if (picture.Url.StartsWith("https://") || picture.Url.StartsWith("http://"))
			//{
			//	var httpRequest = (HttpWebRequest)WebRequest.Create(picture.Url);
			//	var httpResponse = (HttpWebResponse)httpRequest.GetResponse();

			//	imageStream = httpResponse.GetResponseStream();
			//}
			//else
			//{
			//	imageStream = File.OpenRead(picture.Url);
			//}

			BitmapImage src = new BitmapImage();
			src.BeginInit();
			src.UriSource = new Uri(picture.Url, UriKind.Relative);
			src.CacheOption = BitmapCacheOption.OnLoad;
			src.EndInit();

			var leftImagePart = new CroppedBitmap(src, new Int32Rect(0, 0, (int)src.PixelWidth / 2, (int)src.PixelHeight));
			var rightImagePart = new CroppedBitmap(src, new Int32Rect((int)src.PixelWidth / 2, 0, (int)src.PixelWidth / 2 - 0, (int)src.PixelHeight));

			return new Tuple<ImageSource, ImageSource>(leftImagePart, rightImagePart);
		}

		//async static private Task<byte[]> _GetPixelData(BitmapDecoder decoder, uint startPointX, uint startPointY, uint width, uint height)
		//{
		//	return await _GetPixelData(decoder, startPointX, startPointY, width, height, decoder.PixelWidth, decoder.PixelHeight);
		//}

		//async static private Task<byte[]> _GetPixelData(BitmapDecoder decoder, uint startPointX, uint startPointY, uint width, uint height, uint scaledWidth, uint scaledHeight)
		//{
		//	var transform = new BitmapTransform();
		//	var bounds = new BitmapBounds
		//	{
		//		X = startPointX,
		//		Y = startPointY,
		//		Height = height,
		//		Width = width,
		//	};
		//	transform.Bounds = bounds;

		//	transform.ScaledWidth = scaledWidth;
		//	transform.ScaledHeight = scaledHeight;

		//	// Get the cropped pixels within the bounds of transform. 
		//	var pix = await decoder.GetPixelDataAsync(
		//		BitmapPixelFormat.Bgra8,
		//		BitmapAlphaMode.Straight,
		//		transform,
		//		ExifOrientationMode.IgnoreExifOrientation,
		//		ColorManagementMode.ColorManageToSRgb);
		//	var pixels = pix.DetachPixelData();

		//	return pixels;
		//}
	}

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
            _storyboard.Stop();
        }
    }

    public class SoundServices
    {
        private static volatile SoundServices _instance;
        private MediaElement _mediaElement;
	    private MediaElement _aplauzMediaElement;
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
			

            this.IsInitialized = true;
        }

        public void PlayExcellent()
        {
            if (!this.IsInitialized)
            {
                throw new InvalidOperationException("Player first needs to be initialized!");
            }

            if (AuThink.Desktop.Properties.Settings.Default.IsRewardSoundEnabled)
            {
				_mediaElement.Source = Properties.Settings.Default.Language == "En"
					? new Uri(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/excellent.mp3"))
					: new Uri(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/bravo.mp3"));
	            _mediaElement.Position = TimeSpan.Zero;
                _mediaElement.Play();
            }
        }

	    public void PlayAplauz()
	    {
			if (!this.IsInitialized)
			{
				throw new InvalidOperationException("Player first needs to be initialized!");
			}

			if (Properties.Settings.Default.IsRewardSoundEnabled)
			{
				_mediaElement.Source = Properties.Settings.Default.IsInstructionSoundEnabled
					? new Uri(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/aplauz-dugi.mp3"))
					: null;
				_mediaElement.LoadedBehavior = MediaState.Manual;
				_mediaElement.UnloadedBehavior = MediaState.Manual;
				_mediaElement.Position = TimeSpan.Zero;
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
