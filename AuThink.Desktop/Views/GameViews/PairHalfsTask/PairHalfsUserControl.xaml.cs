using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
        }

	    private void UIElement_OnDrop(object sender, DragEventArgs e)
	    {
		    
	    }

	    private bool _IsDragging = false;
	    private Image _DraggingImage;
		private void Image_MouseDown(object sender, MouseButtonEventArgs e)
		{
			var image = sender as Image;
			DragDrop.DoDragDrop(image, image, DragDropEffects.Copy);
			_DraggingImage = image;
			_IsDragging = true;
		}

	    private void PairHalfsUserControl_OnLoaded(object sender, RoutedEventArgs e)
	    {
			double left = (CanvasContainer.ActualWidth - MainContainer.ActualWidth) / 2;
			Canvas.SetLeft(MainContainer, left);

			double top = (CanvasContainer.ActualHeight - MainContainer.ActualHeight) / 2;
			Canvas.SetTop(MainContainer, top);
	    }
		
	    private void UIElement_OnDragOver(object sender, DragEventArgs e)
	    {
			DraggableImage.Source = _DraggingImage.Source;
			DraggableImage.Visibility = Visibility.Visible;
			var mousePosition = e.GetPosition(CanvasContainer);
			Canvas.SetLeft(DraggableImage, mousePosition.X);
			Canvas.SetTop(DraggableImage, mousePosition.Y);
	    }

    }
}
