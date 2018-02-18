using IISManager.Commands;
using Microsoft.Web.Administration;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace IISManager.ViewModels
{
    public class MainWindowViewModel
    {
        private ICommand onResetIISButtonClickEventHandler;
        private ServerManager _serverManager { get; set; }

        public IEnumerable<SiteManagerViewModel> SiteManagerViewModels { get; set; }
        public ICommand OnResetIISButtonClickEventHandler
        {
            get
            {
                return onResetIISButtonClickEventHandler ?? (onResetIISButtonClickEventHandler = new CommandExecutor(() =>
                {
                    Process.Start("iisreset.exe");
                }));
            }
        }

        public MainWindowViewModel()
        {
            _serverManager = new ServerManager();
            SiteManagerViewModels = _serverManager.Sites.Select(s => new SiteManagerViewModel(_serverManager, s));
        } 
    }
}
