using skyline_odyssey_keycard_management.ViewModels;
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
    /// Interaction logic for AccessPointsView.xaml
    /// </summary>
    public partial class AccessPointsView : UserControl
    {
        public AccessPointListingViewModel AccessPointListingViewModel { get; set; }
        public AccessPointDetailsViewModel AccessPointDetailsViewModel { get; set; }

        public AccessPointsView()
        {
            InitializeComponent();
            AccessPointListingViewModel = new AccessPointListingViewModel();
            AccessPointDetailsViewModel = new AccessPointDetailsViewModel();
            DataContext = this;
        }


        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new MainAdminView();

        }
    }
}
