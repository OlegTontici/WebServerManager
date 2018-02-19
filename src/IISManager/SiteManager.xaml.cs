using System.Diagnostics;
using System.Windows.Controls;

namespace IISManager
{
    /// <summary>
    /// Interaction logic for SiteManager.xaml
    /// </summary>
    public partial class SiteManager : UserControl
    {
        public SiteManager()
        {
            InitializeComponent();
        }

        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            Process.Start(e.Uri.AbsoluteUri);
            e.Handled = true;
        }
    }
}
