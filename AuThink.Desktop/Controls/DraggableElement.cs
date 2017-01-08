using System.Windows;
using System.Windows.Controls;

namespace Authink.Desktop.Controls
{
    public sealed class DraggableElement : Image
    {
        public DraggableElement()
        {
            this.DefaultStyleKey = typeof(DraggableElement);
        }

        public object PairId
        {
            get { return (object)GetValue(PairIdProperty); }
            set { SetValue(PairIdProperty, value); }
        }
        public static readonly DependencyProperty PairIdProperty =
            DependencyProperty.Register("PairId", typeof(object), typeof(DraggableElement), new PropertyMetadata(null));
    }
}
