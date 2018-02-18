using IISManager.Commands;
using Microsoft.Web.Administration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace IISManager.ViewModels
{
    public class SiteManagerViewModel : INotifyPropertyChanged
    {
        private ICommand onSiteStartButtonClickedEventHandler;
        private ICommand onSiteStopButtonClickedEventHandler;
        private ICommand onSiteRestartButtonClickedEventHandler;

        private string status;
        private ServerManager _serverManager;
        private Site _site;

        public IEnumerable<ApplicationManagerViewModel> SiteApplications { get; set; }
        public int SelectedApplicationIndex { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public string Status
        {
            get { return status; }
            set
            {
                status = value;
                NotifyPropertyChanged(nameof(Status));
            }
        }        
        public string SiteName
        {
            get { return _site.Name; }
        }
        public ICommand OnSiteStartButtonClickedEventHandler
        {
            get
            {
                return onSiteStartButtonClickedEventHandler ?? (onSiteStartButtonClickedEventHandler = new CommandExecutor(() =>
                {
                    _site.Start();
                }));
            }
        }
        public ICommand OnSiteStopButtonClickedEventHandler
        {
            get
            {
                return onSiteStopButtonClickedEventHandler ?? (onSiteStopButtonClickedEventHandler = new CommandExecutor(() =>
                {
                    _site.Stop();
                }));
            }
        }
        public ICommand OnSiteRestartButtonClickedEventHandler
        {
            get
            {
                return onSiteRestartButtonClickedEventHandler ?? (onSiteRestartButtonClickedEventHandler = new CommandExecutor(() =>
                {
                    _site.Stop();
                    _site.Start();
                }));
            }
        }

        public SiteManagerViewModel(ServerManager serverManager, Site site)
        {
            _serverManager = serverManager;
            _site = site;
            SiteApplications = _site.Applications.Select(app => new ApplicationManagerViewModel(_serverManager, app));
            Status = _site.State.ToString();
            SelectedApplicationIndex = 0;
        }        

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
