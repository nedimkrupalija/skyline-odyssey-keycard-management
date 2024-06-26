﻿using skyline_odyssey_keycard_management.Components;
using skyline_odyssey_keycard_management.Store;
using skyline_odyssey_keycard_management.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
        private Window employeeDetailsFormWindow = new EmployeeDetailsForm();
		private readonly SelectedEmployeeStore selectedEmployeeStore = new SelectedEmployeeStore();
        public EmployeeListingViewModel EmployeeListingViewModel { get; set; }
        public EmployeeDetailsViewModel EmployeeDetailsViewModel { get; set; }



        public static AdminPanelView Instance { get; set;}
       


        public AdminPanelView()
        {
            InitializeComponent();

            EmployeeListingViewModel = new EmployeeListingViewModel(selectedEmployeeStore);
            EmployeeDetailsViewModel = new EmployeeDetailsViewModel(selectedEmployeeStore);
            DataContext = this;
            Instance = this;
            

           // employeeDetailsForm.CancelClicked += EmployeeDetailsForm_CancelClicked;
           // employeeDetailsForm.SubmitClicked += EmployeeDetailsForm_SubmitClicked;
        }


        private void EmployeeDetailsForm_CancelClicked(object sender, EventArgs e)
        {
           if(this.IsVisible)
            employeeDetailsFormWindow.Hide();
        }

        private void EmployeeDetailsForm_SubmitClicked(object sender, EventArgs e)
        {
            // Close the Popup
          //  employeeDetailsPopup.IsOpen = false;
        }

        private void Add_Clicked(object sender, RoutedEventArgs e)
        {
            try
            {
                employeeDetailsFormWindow.Show();
            }
            catch (Exception ex)
            {
                new EmployeeDetailsForm().Show();
			}   
            //employeeDetailsPopup.IsOpen = !employeeDetailsPopup.IsOpen;
        }

        private void BackButton_Clicked(object sender, RoutedEventArgs e) { 
     
            this.Content = new MainAdminView();
        }

        private void Edit_Clicked(object sender, RoutedEventArgs e)
        {

            //employeeDetailsFormWindow.ShowDialog();
            //employeeDetailsPopup.IsOpen = !employeeDetailsPopup.IsOpen;
        }



    }
}
