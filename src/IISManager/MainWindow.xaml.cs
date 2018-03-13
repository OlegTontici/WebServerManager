using System;
using System.Windows;
using System.Windows.Controls;
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
            Notification notification = new Notification();
            Grid.SetColumn(notification, 1);
            this.RootContainer.Children.Add(notification);
            DataContext = new MainWindowViewModel(notification);
        }
    }
}
