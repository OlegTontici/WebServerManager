using Microsoft.Web.Administration;
using System.Windows;
using System.Linq;
using System.Collections.Generic;
using IISManager.Models;
using System.Diagnostics;
using IISManager.ViewModels;

namespace IISManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();            
            DataContext = new MainWindowViewModel();
        }
    }
}
