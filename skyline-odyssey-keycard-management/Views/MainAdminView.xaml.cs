﻿using skyline_odyssey_keycard_management.ViewModels;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for MainAdminView.xaml
    /// </summary>
    public partial class MainAdminView : UserControl
    {
        public MainAdminView()
        {
            InitializeComponent();
        }

        private void Emloyees_CLicked(object sender, RoutedEventArgs e)
        {
            AdminPanelView adminPanel = new AdminPanelView();
            adminPanel.Width = this.Width;
            adminPanel.Height = this.Height;

            this.Content = adminPanel;
        }
    }
}
