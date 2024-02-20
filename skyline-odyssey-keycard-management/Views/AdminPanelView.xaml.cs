using skyline_odyssey_keycard_management.Components;
using skyline_odyssey_keycard_management.Store;
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
    /// Interaction logic for AdminPanelView.xaml
    /// </summary>
    public partial class AdminPanelView : UserControl
    {
        private readonly SelectedEmployeeStore selectedEmployeeStore = new SelectedEmployeeStore();
        public EmployeeListingViewModel EmployeeListingViewModel { get; set; }
        public EmployeeDetailsViewModel EmployeeDetailsViewModel { get; set; }


        public AdminPanelView()
        {
            InitializeComponent();

            EmployeeListingViewModel = new EmployeeListingViewModel(selectedEmployeeStore);
            EmployeeDetailsViewModel = new EmployeeDetailsViewModel(selectedEmployeeStore);
            DataContext = this;


            employeeDetailsForm.CancelClicked += EmployeeDetailsForm_CancelClicked;
            employeeDetailsForm.SubmitClicked += EmployeeDetailsForm_SubmitClicked;
        }


        private void EmployeeDetailsForm_CancelClicked(object sender, EventArgs e)
        {
            // Close the Popup
            employeeDetailsPopup.IsOpen = false;
        }

        private void EmployeeDetailsForm_SubmitClicked(object sender, EventArgs e)
        {
            // Close the Popup
            employeeDetailsPopup.IsOpen = false;
        }

        private void Add_Clicked(object sender, RoutedEventArgs e)
        {
            employeeDetailsPopup.IsOpen = !employeeDetailsPopup.IsOpen;
        }

        private void BackButton_Clicked(object sender, RoutedEventArgs e) { 
     
            this.Content = new MainAdminView();
        }

    }
}
