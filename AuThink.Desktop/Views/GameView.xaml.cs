using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Authink.Desktop.Controls;
using AuThink.Desktop.Core;
using AuThink.Desktop.Services;
using AuThink.Desktop.Views.GameViews;
using AuThink.Desktop.Views.GameViews.PairHalfsTask;
using GalaSoft.MvvmLight.Ioc;

using rules = AuThink.Desktop.Model.Rules;

namespace AuThink.Desktop.Views
{
    public partial class GameView
    {
        private void onControl_Loaded(object sender, RoutedEventArgs e)
        {
            GameGrid.Children.Clear();

            var task = _taskQueries.GetSingleById(GameState.GetTask());
            _taskKey = task.Type;

            switch (task.Type)
            {
                case rules.Keys.DetectDifferentItems:
                    if (task.Pictures.Count() <= 2)
                    {
                        GameGrid.Children.Add(new DetectDifferentItemsHighDifficultyUserControl());
                    }
                    else
                    {
                        GameGrid.Children.Add(new DetectDifferentItemUserControl());
                    }
                    break;

                case rules.Keys.DetectColors:
                    GameGrid.Children.Add(new DetectColorsUserControl());
                    break;

                case rules.Keys.ContinueSequence:
                    GameGrid.Children.Add(new ContinueSequenceUserControl());
                    break;

                case rules.Keys.PairHalves:
                    GameGrid.Children.Add(new PairHalfsUserControl());
                    break;

                case rules.Keys.DetectSameItems:
                    GameGrid.Children.Add(new DetectSameItemsUserControl());
                    break;

                case rules.Keys.OrderBySize:
                    GameGrid.Children.Add(new OrderBySizeUserControl());
                    break;

                case rules.Keys.VoiceCommands:
                    GameGrid.Children.Add(new VoiceCommandsUserControl());
                    break;

                case rules.Keys.PairSameItems:
                    GameGrid.Children.Add(new PairSameItemsUserControl());
                    break;
            }
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

//        private void _DraggableElement_PointerPressed(object sender, MouseEventArgs e)
//        {
//            if (_isDragging)
//            {
//                CancelDragging();
//                return;
//            }
//
//            if (!(e.OriginalSource is DependencyObject)) { return; }
//
//            _draggingElement = FindParentOfElement<DraggableElement>(e.OriginalSource as DependencyObject) as DraggableElement;
//
//            if (_draggingElement == null) { return; }
//
//            if (_draggingElement.Content is UIElement)
//            {
//                InitDraggingElement
//                (
//                    e: e,
//                    draggableElement: _draggingElement
//                );
//            }
//
//            TransferDraggingContentToDraggingElement
//            (
//                sourceElement: _draggingElement
//            );
//
//            _isDragging = true;
//        }
//        private void _DropPlaceholder_PointerReleased(object sender, MouseEventArgs e)
//        {
//            if (!_isDragging || _draggingElementContent == null)
//            {
//                return;
//            }
//
//            var dropPlaceholder = FindParentOfElement<DropPlaceholder>(e.OriginalSource as DependencyObject) as DropPlaceholder;
//
//            if (dropPlaceholder == null)
//            {
//                CancelDragging();
//                return;
//            }
//
//            if (IsDropSuccessful(dropPlaceholder))
//            {
//                TransferDraggingContentToDropElement
//                (
//                    destinationElement: dropPlaceholder
//                );
//
//                SoundServices.Instance.Play();
//
//                _isDragging = false;
//            }
//            else
//            {
//                CancelDragging();
//            }
//        }
//        protected override void OnMouseMove(MouseEventArgs e)
//        {
//            if (!_isDragging)
//            {
//                return;
//            }
//
//            base.OnMouseMove(e);
//            var position = e.GetPosition(this.Parent as UIElement);
//
//            draggingContentControl.Margin = new Thickness
//            (
//                left: position.X - _startPosition.X,
//                top: position.Y - _startPosition.Y,
//                right: 0,
//                bottom: 0
//            );
//        }
//
//        private void InitDraggingElement(MouseEventArgs e, DraggableElement draggableElement)
//        {
//            _startPosition = e.GetPosition(draggableElement.Content as UIElement);
//            var positionRelativeToParent = e.GetPosition(this.Parent as UIElement);
//
//            draggingContentControl.Margin = new Thickness
//            (
//                left: positionRelativeToParent.X - _startPosition.X,
//                top: positionRelativeToParent.Y - _startPosition.Y,
//                right: 0,
//                bottom: 0
//            );
//        }
//        private bool IsDropSuccessful(DropPlaceholder dropedOn)
//        {
//            if (_taskKey == AuThink.Desktop.Model.Rules.Keys.PairHalves)
//            {
//                return dropedOn.ExpectedPairId == _draggingElement.PairId;
//            }
//            else if (_taskKey == AuThink.Desktop.Model.Rules.Keys.PairSameItems)
//            {
//                return dropedOn.ExpectedPairId.ToString() == _draggingElement.PairId.ToString();
//            }
//
//            return false;
//        }
//        private void CancelDragging()
//        {
//            draggingContentControl.Content = null;
//            _draggingElement.Content = _draggingElementContent;
//            _draggingElement = null;
//            _isDragging = false;
//        }
//        private void TransferDraggingContentToDraggingElement(DraggableElement sourceElement)
//        {
//            _draggingElement = sourceElement;
//            _draggingElementContent = _draggingElement.Content;
//            _draggingElement.Content = null;
//            draggingContentControl.DataContext = _draggingElement.DataContext;
//            draggingContentControl.Content = _draggingElementContent;
//        }
//        private void TransferDraggingContentToDropElement(DropPlaceholder destinationElement)
//        {
//            draggingContentControl.Content = null;
//
//            //destinationElement.Content = _draggingElementContent;
//            destinationElement.DropElement(_draggingElementContent);
//            _draggingElement.Visibility = Visibility.Collapsed;
//            _draggingElement = null;
//        }

        private void PopupContinueOnClick(object sender, RoutedEventArgs e)
        {
            MenuPopup.Visibility = Visibility.Collapsed;
        }
    }

    public partial class GameView
    {
        private readonly ITaskQueries _taskQueries;

        private DraggableElement _draggingElement;
        private Point _startPosition;

        private bool _isDragging;
        private object _draggingElementContent;
        private string _taskKey;

        public GameView()
        {
            this.InitializeComponent();

            _taskQueries = (ITaskQueries)SimpleIoc.Default.GetInstance(typeof(ITaskQueries));

            //this.AddHandler(UIElement.MouseEnterEvent, new MouseEventHandler(_DraggableElement_PointerPressed), true);
            //this.AddHandler(UIElement.MouseLeaveEvent, new MouseEventHandler(_DropPlaceholder_PointerReleased), true);

            SoundServices.Instance.Initialize(this.mediaElement);
            PopUpService.Instance.Initialize(((Storyboard)this.Resources["PopupStoryboard"]));
        }
    }
}
