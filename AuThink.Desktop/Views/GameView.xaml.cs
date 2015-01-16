using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Authink.Desktop.Controls;
using AuThink.Desktop.Core;
using AuThink.Desktop.Services;
using GalaSoft.MvvmLight.Ioc;

namespace AuThink.Desktop.Views
{
    /// <summary>
    /// Interaction logic for GameView.xaml
    /// </summary>
    public partial class GameView : UserControl
    {
        private readonly ITaskQueries taskQueries;

        private DraggableElement draggingElement;
        private Point startPosition;

        private bool isDragging;
        private object draggingElement_content;
        private string taskKey;

        public GameView()
        {
            this.InitializeComponent();

            this.taskQueries = (ITaskQueries)SimpleIoc.Default.GetInstance(typeof(ITaskQueries));

            //this.AddHandler(UIElement.PointerPressedEvent, new PointerEventHandler(_DraggableElement_PointerPressed), true);
            //this.AddHandler(UIElement.PointerReleasedEvent, new PointerEventHandler(_DropPlaceholder_PointerReleased), true);

            //SoundServices.Instance.Initialize(this.mediaElement);
            //PopUpService.Instance.Initialize(this.PopupStoryboard);
        }

        private object FindParentOfElement<T>(DependencyObject element)
        {
            if (element == null) { return null; }
            if (element is T)
            {
                return element;
            }

            return FindParentOfElement<T>(VisualTreeHelper.GetParent(element));
        }

        //private void _DraggableElement_PointerPressed(object sender, PointerRoutedEventArgs e)
        //{
        //    if (isDragging)
        //    {
        //        CancelDragging();
        //        return;
        //    }

        //    if (!(e.OriginalSource is DependencyObject)) { return; }

        //    draggingElement = FindParentOfElement<DraggableElement>(e.OriginalSource as DependencyObject) as DraggableElement;

        //    if (draggingElement == null) { return; }

        //    if (draggingElement.Content is UIElement)
        //    {
        //        InitDraggingElement
        //        (
        //            pointerEventArgs: e,
        //            draggableElement: draggingElement
        //        );
        //    }

        //    TransferDraggingContentToDraggingElement
        //    (
        //        sourceElement: draggingElement
        //    );

        //    isDragging = true;
        //}
        //private void _DropPlaceholder_PointerReleased(object sender, PointerRoutedEventArgs e)
        //{
        //    if (!isDragging || draggingElement_content == null)
        //    {
        //        return;
        //    }

        //    var dropPlaceholder = FindParentOfElement<DropPlaceholder>(e.OriginalSource as DependencyObject) as DropPlaceholder;

        //    if (dropPlaceholder == null)
        //    {
        //        CancelDragging();
        //        return;
        //    }

        //    if (IsDropSuccessful(dropPlaceholder))
        //    {
        //        TransferDraggingContentToDropElement
        //        (
        //            destinationElement: dropPlaceholder
        //        );

        //        SoundServices.Instance.Play();

        //        isDragging = false;
        //    }
        //    else
        //    {
        //        CancelDragging();
        //    }
        //}
        //protected override void OnPointerMoved(PointerRoutedEventArgs e)
        //{
        //    if (!isDragging)
        //    {
        //        return;
        //    }

        //    base.OnPointerMoved(e);
        //    var position = e.GetCurrentPoint(this.Parent as UIElement).Position;

        //    draggingContentControl.Margin = new Thickness
        //    (
        //        left: position.X - startPosition.X,
        //        top: position.Y - startPosition.Y,
        //        right: 0,
        //        bottom: 0
        //    );
        //}

        //private void InitDraggingElement(PointerRoutedEventArgs pointerEventArgs, DraggableElement draggableElement)
        //{
        //    startPosition = pointerEventArgs.GetCurrentPoint(draggableElement.Content as UIElement).Position;
        //    var positionRelativeToParent = pointerEventArgs.GetCurrentPoint(this.Parent as UIElement).Position;

        //    draggingContentControl.Margin = new Thickness
        //    (
        //        left: positionRelativeToParent.X - startPosition.X,
        //        top: positionRelativeToParent.Y - startPosition.Y,
        //        right: 0,
        //        bottom: 0
        //    );
        //}
        private bool IsDropSuccessful(DropPlaceholder dropedOn)
        {
            if (taskKey == AuThink.Desktop.Model.Rules.Keys.PairHalves)
            {
                return dropedOn.ExpectedPairId == draggingElement.PairId;
            }
            else if (taskKey == AuThink.Desktop.Model.Rules.Keys.PairSameItems)
            {
                return dropedOn.ExpectedPairId.ToString() == draggingElement.PairId.ToString();
            }

            return false;
        }
        private void CancelDragging()
        {
            draggingContentControl.Content = null;
            draggingElement.Content = draggingElement_content;
            draggingElement = null;
            isDragging = false;
        }
        private void TransferDraggingContentToDraggingElement(DraggableElement sourceElement)
        {
            draggingElement = sourceElement;
            draggingElement_content = draggingElement.Content;
            draggingElement.Content = null;
            draggingContentControl.DataContext = draggingElement.DataContext;
            draggingContentControl.Content = draggingElement_content;
        }
        private void TransferDraggingContentToDropElement(DropPlaceholder destinationElement)
        {
            draggingContentControl.Content = null;

            //destinationElement.Content = draggingElement_content;
            destinationElement.DropElement(draggingElement_content);
            draggingElement.Visibility = Visibility.Collapsed;
            draggingElement = null;
        }

        private void Popup_continue_OnClick(object sender, RoutedEventArgs e)
        {
            MenuPopup.Visibility = Visibility.Collapsed;
        }
    }
}
