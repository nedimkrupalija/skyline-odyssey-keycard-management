using Microsoft.VisualBasic.ApplicationServices;
using skyline_odyssey_keycard_management.Models;
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
using System.Windows.Shapes;

namespace skyline_odyssey_keycard_management.Views
{
    /// <summary>
    /// Interaction logic for RequestKeycard.xaml
    /// </summary>
    public partial class RequestKeycard : Window
    {
        private DatabaseContext _databaseContext;
        public RequestKeycard()
        {
            InitializeComponent();
            this.DataContext = new RequestKeycardViewModel();
            _databaseContext = new DatabaseContext();
        }

		private void Submit_Click(object sender, RoutedEventArgs e)
		{
			var user = LoginView.LoggedInUser;
            if(firstButton.IsChecked == true)
            {
                _databaseContext.KeycardRequests.Add(new KeycardRequests(user.UserId, "I'm a new employee and I don't have a keycard", "Unapproved"));
				foreach (var manager in MainWindow.Managers)
				{
					MainWindow.Send_Email(manager.Email, "New keycard request", user.Role.Name + " " + user.FirstName + " " + user.LastName + " requested new keycard. Check your admin panel to view this request. Reason for request: I'm a new employee and I don't have a keycard.");
				}
				MainWindow.Send_Email(user.Email, "New keycard request", "Your keycard request was sent, and it is waiting for approval.");
			}
			else if(secondButton.IsChecked == true)
			{
				_databaseContext.KeycardRequests.Add(new KeycardRequests(LoginView.LoggedInUser.UserId, "I lost my keycard", "Unapproved"));
				foreach (var manager in MainWindow.Managers)
				{
					MainWindow.Send_Email(manager.Email, "New keycard request", user.Role.Name + " " + user.FirstName + " " + user.LastName + " requested new keycard. Check your admin panel to view this request. Reason for request: I lost my keycard.");
				}
				MainWindow.Send_Email(user.Email, "New keycard request", "Your keycard request was sent, and it is waiting for approval.");
			}
            
            else if(thirdButton.IsChecked == true)
            {
				_databaseContext.KeycardRequests.Add(new KeycardRequests(LoginView.LoggedInUser.UserId, reasonBox.Text, "Unapproved"));
				foreach (var manager in MainWindow.Managers)
				{
					MainWindow.Send_Email(manager.Email, "New keycard request", user.Role.Name + " " + user.FirstName + " " + user.LastName + " requested new keycard. Check your admin panel to view this request. Reason for request: " + reasonBox.Text);
				}
				MainWindow.Send_Email(user.Email, "New keycard request", "Your keycard request was sent, and it is waiting for approval.");
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
