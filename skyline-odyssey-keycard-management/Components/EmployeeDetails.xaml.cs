using skyline_odyssey_keycard_management.Models;
using skyline_odyssey_keycard_management.Store;
using skyline_odyssey_keycard_management.ViewModels;
using skyline_odyssey_keycard_management.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
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
    /// Interaction logic for EmployeeDetails.xaml
    /// </summary>
    public partial class EmployeeDetails : UserControl
    {

        private DatabaseContext _databaseContext;

        public EmployeeDetails()
        {
            InitializeComponent();
            _databaseContext = new DatabaseContext();

        }

		private void DeactivateKeycardButton_Click(object sender, RoutedEventArgs e)
		{
            
            try
            {

                var user = EmployeeDetailsViewModel.SelectedUser;

                
               
                {

                    user.Keycard.IsActive = false;


                    MainWindow.Send_Email(user.Email, "Keycard deactivation", "Your keycard has been deactivated, please request new one in your panel.");



                    _databaseContext.Update(user);

                    _databaseContext.SaveChanges();


                    string messageBoxText = "Keycard successfully deactivated.";
                    string caption = "Keycard deactivation";
                    MessageBoxButton button = MessageBoxButton.OK;
                    MessageBoxImage icon = MessageBoxImage.Information;
                    MessageBoxResult result;

                    result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.OK);
                }
            }
            catch(Exception ex)
            {
				string messageBoxText = "There seems to be an error while deactivating keycard.";
				string caption = "Error";
				MessageBoxButton button = MessageBoxButton.OK;
				MessageBoxImage icon = MessageBoxImage.Error;
				MessageBoxResult result;

				result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.OK);
			}   



		}
    }
}
