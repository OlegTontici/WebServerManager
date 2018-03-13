using IISManager.Commands;
using Microsoft.Web.Administration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace IISManager.ViewModels
{
    public class SiteManagerViewModel : INotifyPropertyChanged
    {
        private ICommand onFullRecycleButtonClickedEventHandler;
        private ICommand onSiteStartButtonClickedEventHandler;
        private ICommand onSiteStopButtonClickedEventHandler;
        private ICommand onSiteRestartButtonClickedEventHandler;

        private string status;
        private ServerManager _serverManager;
        private Site _site;
        private Notification _notification;

        public IEnumerable<string> Bindings { get; set; }
        public IEnumerable<ApplicationManagerViewModel> SiteApplications { get; set; }
        public int SelectedApplicationIndex { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public string Status
        {
            get
            {
                return _site.State.ToString(); 
            }
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
        public ICommand OnFullRecycleButtonClickedEventHandler
        {
            get
            {
                return onFullRecycleButtonClickedEventHandler ?? (onFullRecycleButtonClickedEventHandler = new CommandExecutor(() =>
                {

                    ExecuteWithNotification(() =>
                    {
                        _site.Stop();

                        foreach (var a in _site.Applications)
                        {
                            _serverManager.ApplicationPools.Single(appPool => appPool.Name == a.ApplicationPoolName).Recycle();
                        }

                        _site.Start();

                        Status = string.Empty;
                    });
                    
                }));
            }
        }
        public ICommand OnSiteStartButtonClickedEventHandler
        {
            get
            {
                return onSiteStartButtonClickedEventHandler ?? (onSiteStartButtonClickedEventHandler = new CommandExecutor(() =>
                {
                    ExecuteWithNotification(() =>
                    {
                        _site.Start();

                        Status = string.Empty;
                    });
                }));
            }
        }
        public ICommand OnSiteStopButtonClickedEventHandler
        {
            get
            {
                return onSiteStopButtonClickedEventHandler ?? (onSiteStopButtonClickedEventHandler = new CommandExecutor(() =>
                {
                    ExecuteWithNotification(() =>
                    {
                        _site.Stop();

                        Status = string.Empty;
                    });
                }));
            }
        }
        public ICommand OnSiteRestartButtonClickedEventHandler
        {
            get
            {
                return onSiteRestartButtonClickedEventHandler ?? (onSiteRestartButtonClickedEventHandler = new CommandExecutor(() =>
                {
                    ExecuteWithNotification(() =>
                    {
                        _site.Stop();
                        _site.Start();
                    });
                }));
            }
        }

        public SiteManagerViewModel(ServerManager serverManager, Site site, Notification notification)
        {
            _serverManager = serverManager;
            _site = site;
            SiteApplications = _site.Applications.Select(app => new ApplicationManagerViewModel(_serverManager, app, notification));
            SelectedApplicationIndex = 0;
            Bindings = _site.Bindings.Select(b => $@"{b.Protocol}://{b.Host}");
            _notification = notification;
        }        

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void ExecuteWithNotification(Action action)
        {
            try
            {
                action();
                _notification.ShowSuccess();
            }
            catch (Exception ex)
            {
                _notification.ShowError(ex.Message);
            }
        }
    }
}
