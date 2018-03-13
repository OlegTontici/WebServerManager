using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace IISManager
{
    /// <summary>
    /// Interaction logic for ApplicationManager.xaml
    /// </summary>
    public partial class ApplicationManager : UserControl
    {
        public ApplicationManager()
        {
            InitializeComponent();
        }

        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            Process.Start(e.Uri.AbsoluteUri);
            e.Handled = true;
        }

        private void Hyperlink_MouseRightButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ProcessStartInfo psi = new ProcessStartInfo($"file:///{(e.Source as FrameworkElement).DataContext.ToString()}")
            {
                Verb = @"properties"
            };

            Process.Start(psi);
            e.Handled = true;
        }
    }
}
