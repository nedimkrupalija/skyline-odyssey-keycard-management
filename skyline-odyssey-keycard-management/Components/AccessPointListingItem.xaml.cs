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

namespace skyline_odyssey_keycard_management.Components
{
    /// <summary>
    /// Interaction logic for AccessPointListingItem.xaml
    /// </summary>
    public partial class AccessPointListingItem : UserControl
    {
        public AccessPointListingItem()
        {
            InitializeComponent();
            DataContext = new AccessPointListingItem();
        }
    }
}