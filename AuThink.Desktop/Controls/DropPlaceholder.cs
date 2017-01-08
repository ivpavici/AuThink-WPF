using System;
using System.Windows;
using System.Windows.Controls;

// The Templated Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234235

namespace Authink.Desktop.Controls
{
    public sealed class DropPlaceholder : Image
    {
        public bool IsFull { get; private set; }

        public DropPlaceholder()
        {
            this.DefaultStyleKey = typeof (DropPlaceholder);
        }

        public object ExpectedPairId
        {
            get { return (object) GetValue(ExpectedPairIdProperty); }
            set { SetValue(ExpectedPairIdProperty, value); }
        }

        public static readonly DependencyProperty ExpectedPairIdProperty =
            DependencyProperty.Register("ExpectedPairId", typeof (object), typeof (DropPlaceholder),
                                        new PropertyMetadata(null));

        public delegate void DropSuccessful(object sender, EventArgs e);
        public event DropSuccessful OnDropSuccessful;

        private void _OnDropSuccessful()
        {
            if (this.OnDropSuccessful != null)
            {
                this.OnDropSuccessful.Invoke(this, EventArgs.Empty);
            }
        }

        public bool DropElement(object draggableElementContent)
        {
	        var image = draggableElementContent as Image;

            if (image != null && !this.IsFull)
            {
                this.Source = image.Source;

                this.IsFull = true;

                _OnDropSuccessful();

                return true;
            }

            return false;
        }
    }
}
