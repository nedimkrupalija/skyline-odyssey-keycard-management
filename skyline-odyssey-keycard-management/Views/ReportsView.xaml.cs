using Microsoft.EntityFrameworkCore;
using skyline_odyssey_keycard_management.Models;
using skyline_odyssey_keycard_management.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace skyline_odyssey_keycard_management.Views
{
    /// <summary>
    /// Interaction logic for ReportsView.xaml
    /// </summary>
    public partial class ReportsView : UserControl
    {

       

        public ReportsView()
        {
            InitializeComponent();
            this.DataContext = new ReportsViewModel();
        }

        private void BackButton_Clicked(object sender, RoutedEventArgs e)
        {
            MainAdminView mainAdminPanel = new MainAdminView();
            mainAdminPanel.Width = this.Width;
            mainAdminPanel.Height = this.Height;

            this.Content = mainAdminPanel;
        }
        
    }
}
