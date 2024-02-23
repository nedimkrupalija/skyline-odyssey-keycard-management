using Microsoft.VisualBasic.ApplicationServices;
using skyline_odyssey_keycard_management.Models;
using skyline_odyssey_keycard_management.ViewModels;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace skyline_odyssey_keycard_management.Views
{
    
    public partial class RequestKeycard : Window
    {
        private DatabaseContext _databaseContext;
        public RequestKeycard()
        {
            InitializeComponent();
            this.DataContext = new RequestKeycardViewModel();
            _databaseContext = new DatabaseContext();

			if(LoginView.LoggedInUser.Keycard.IsActive)	
				submitButton.IsEnabled = false;

        }

		private void ShowMessageBox(string text, string caption)
		{
			string messageBoxText = text;
			string _caption = caption;
			MessageBoxButton button = MessageBoxButton.OK;
			MessageBoxImage icon = MessageBoxImage.Information;
			MessageBoxResult result;
			MessageBox.Show(messageBoxText, _caption, button, icon, MessageBoxResult.OK);
		}

		private void Submit_Click(object sender, RoutedEventArgs e)
		{
			var user = LoginView.LoggedInUser;
            if(firstButton.IsChecked == true)
            {
                _databaseContext.KeycardRequests.Add(new KeycardRequests(user.UserId, "I'm a new employee and I don't have a keycard", "Pending"));
				foreach (var manager in MainWindow.Managers)
				{
					MainWindow.Send_Email(manager.Email, "New keycard request", user.Role.Name + " " + user.FirstName + " " + user.LastName + " requested new keycard. Check your admin panel to view this request. Reason for request: \"I'm a new employee and I don't have a keycard.\"");
				}
				MainWindow.Send_Email(user.Email, "New keycard request", "Your keycard request was sent, and it is waiting for approval.");

				ShowMessageBox("You have successfully requested new keycard", "Information");

				

				this.Hide();
			}
			else if(secondButton.IsChecked == true)
			{
				_databaseContext.KeycardRequests.Add(new KeycardRequests(LoginView.LoggedInUser.UserId, "I lost my keycard", "Pending"));
				foreach (var manager in MainWindow.Managers)
				{
					MainWindow.Send_Email(manager.Email, "New keycard request", user.Role.Name + " " + user.FirstName + " " + user.LastName + " requested new keycard. Check your admin panel to view this request. Reason for request: \"I lost my keycard.\"");
				}
				MainWindow.Send_Email(user.Email, "New keycard request", "Your keycard request was sent, and it is waiting for approval.");
				ShowMessageBox("You have successfully requested new keycard", "Information");

				this.Hide();
			}
            
            else if(thirdButton.IsChecked == true)
            {
				_databaseContext.KeycardRequests.Add(new KeycardRequests(LoginView.LoggedInUser.UserId, reasonBox.Text, "Pending"));
				foreach (var manager in MainWindow.Managers)
				{
					MainWindow.Send_Email(manager.Email, "New keycard request", user.Role.Name + " " + user.FirstName + " " + user.LastName + " requested new keycard. Check your admin panel to view this request. Reason for request: " + "\"" +  reasonBox.Text + "\".");
				}
				MainWindow.Send_Email(user.Email, "New keycard request", "Your keycard request was sent, and it is waiting for approval.");

				ShowMessageBox("You have successfully requested new keycard", "Information");

				this.Hide();
			}
            else
            {



				string messageBoxText = "You must select an option to continue";
				string caption = "Warning";
				MessageBoxButton button = MessageBoxButton.OK;
				MessageBoxImage icon = MessageBoxImage.Warning;
				MessageBoxResult result;

				result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.OK);
			}
		}
	}
}
