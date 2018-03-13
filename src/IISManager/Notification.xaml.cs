using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace IISManager
{
    /// <summary>
    /// Interaction logic for Notification.xaml
    /// </summary>
    public partial class Notification : UserControl
    {
        private const string _successBackgroundColor = "#00C853";
        private const string _errorBackgroundColor = "#FF6E40";

        public Notification()
        {
            InitializeComponent();
        }

        public void ShowError(string message)
        {
            StatusBlock.Text = message;
            StatusContainer.Background = (SolidColorBrush)new BrushConverter().ConvertFrom(_errorBackgroundColor);
            ShowNotification();
        }
        public void ShowSuccess()
        {
            StatusBlock.Text = "Success";
            StatusContainer.Background = (SolidColorBrush)new BrushConverter().ConvertFrom(_successBackgroundColor);
            ShowNotification();
        }

        public void StatusMessageCloseButtonClickEventhandler(object sender, RoutedEventArgs args)
        {
            HideNotification(0);
        }

        private void ShowNotification()
        {
            DoubleAnimation da = new DoubleAnimation
            {
                From = 0,
                To = 0.9,
                Duration = TimeSpan.FromMilliseconds(500)
            };
            da.Completed += (s, a) => HideNotification(4000);
            StatusContainer.Visibility = Visibility.Visible;
            StatusContainer.BeginAnimation(OpacityProperty, da,HandoffBehavior.SnapshotAndReplace);
        }

        private void HideNotification(int delay)
        {
            DoubleAnimation da = new DoubleAnimation
            {
                From = 0.9,
                To = 0,
                BeginTime = TimeSpan.FromMilliseconds(delay),
                Duration = TimeSpan.FromMilliseconds(500)
            };
            da.Completed += (s, a) => StatusContainer.Visibility = Visibility.Hidden;
            StatusContainer.BeginAnimation(OpacityProperty, da,HandoffBehavior.SnapshotAndReplace);
        }
    }
}
