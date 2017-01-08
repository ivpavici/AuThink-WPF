using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AuThink.Desktop.Views.GameViews.PairHalfsTask
{
    /// <summary>
    /// Interaction logic for PairHalfsUserControl.xaml
    /// </summary>
    public partial class PairHalfsUserControl : UserControl
    {
        public PairHalfsUserControl()
        {
			InitializeComponent();
			//Mouse.AddMouseDownHandler(this, CanvasMouseLeftButtonDown);
			//Mouse.AddMouseUpHandler(this, CanvasMouseLeftButtonUp);
			//Mouse.AddMouseMoveHandler(this, CanvasMouseMove);
        }
		
		
		private Point mousePosition;
	    private Image _DraggingImage;

		private void CanvasMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			_DraggingImage = e.Source as Image;

//			if (_DraggingImage != null && CanvasContainer.CaptureMouse())
//			{
//				DraggableImage.Source = _DraggingImage.Source;
//				DraggableImage.Visibility = Visibility.Visible;
//				Canvas.SetLeft(DraggableImage, Canvas.GetLeft(_DraggingImage));
//				Canvas.SetTop(DraggableImage, Canvas.GetTop(_DraggingImage));
//				DraggableImage.Width = _DraggingImage.ActualWidth;
//				DraggableImage.Height = _DraggingImage.ActualHeight;
//				mousePosition = e.GetPosition(CanvasContainer);
//				//draggedImage = image;
//				//Panel.SetZIndex(DraggableImage, 1); // in case of multiple images
//				DragDrop.DoDragDrop(_DraggingImage, _DraggingImage, DragDropEffects.Copy);
//			}
		}

		private void CanvasMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
//			if (DraggableImage.Visibility == Visibility.Visible)
//			{
//				counter = 0;
//				DraggableImage.Visibility = Visibility.Collapsed;
//				CanvasContainer.ReleaseMouseCapture();
//				
//				//Panel.SetZIndex(DraggableImage, 0);
//				//DraggableImage = null;
//			}
		}

	    private int counter = 0;
		private void CanvasMouseMove(object sender, MouseEventArgs e)
		{
//			if (DraggableImage.Visibility == Visibility.Visible)
//			{
//				counter++;
//				var position = e.GetPosition(CanvasContainer);
//				var offset = position - mousePosition;
//				mousePosition = position;
//				Canvas.SetLeft(DraggableImage, mousePosition.X);
//				Canvas.SetTop(DraggableImage, mousePosition.Y);
//			}
		}
    }
}
