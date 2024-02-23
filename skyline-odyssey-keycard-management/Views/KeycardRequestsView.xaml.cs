using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
using skyline_odyssey_keycard_management.Models;
using skyline_odyssey_keycard_management.ViewModels;
using System;
using System.Collections.Generic;
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
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace skyline_odyssey_keycard_management.Views
{
    /// <summary>
    /// Interaction logic for KeycardRequestsView.xaml
    /// </summary>
    public partial class KeycardRequestsView : UserControl
    {
        public KeycardRequestsView()
        {
            InitializeComponent();
            this.DataContext = new KeycardRequestsViewModel();
        }

        private void BackButton_Clicked(object sender, RoutedEventArgs e)
        {
            MainAdminView mainAdminView = new MainAdminView();
            mainAdminView.Width = this.Width;
            mainAdminView.Height = this.Height;

            this.Content = mainAdminView;
        }

        private void Approve_Clicked(object sender, RoutedEventArgs e)
        {
            if(roomListView.SelectedItem != null)
            {
                var selectedKeycardRequest = (KeycardRequests)roomListView.SelectedItem;
                selectedKeycardRequest.Status = "Approved";
                var selectedUser = selectedKeycardRequest.User;
              

                DatabaseContext databaseContext = new DatabaseContext();
                var unassignedKeycards = databaseContext.Keycards.Where(u=>u.IsAssigned == false).ToList();
                var selectedUserKeycard = databaseContext.Keycards.First(u => u.Id == selectedUser.KeycardId);

                selectedUserKeycard.IsAssigned = false;
                selectedUserKeycard.IsActive = true;
                
                selectedUser.Keycard = unassignedKeycards[0];
                unassignedKeycards[0].IsAssigned = true;
                unassignedKeycards[0].IsActive = true;

                databaseContext.Update(selectedUserKeycard);
                databaseContext.Update(selectedKeycardRequest);
                databaseContext.Update(selectedUser);
                databaseContext.Update(unassignedKeycards[0]);

                databaseContext.SaveChanges();
                roomListView.ItemsSource = databaseContext.KeycardRequests.Include(u => u.User).ToList();

                string messageBoxText = "Keycard request successfully approved";
                string _caption = "Keycard appproval";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Information;

                MainWindow.Send_Email(selectedUser.Email, "Request approval", "Your keycard request was approved.");
                MessageBox.Show(messageBoxText, _caption, button, icon, MessageBoxResult.OK);

            }
        }

        private void Deny_Clicked(object sender, RoutedEventArgs e)
        {
            var selectedKeycardRequest = (KeycardRequests)roomListView.SelectedItem;
            selectedKeycardRequest.Status = "Unapproved";
            var selectedUser = selectedKeycardRequest.User;

            DatabaseContext databaseContext = new DatabaseContext();

            databaseContext.Update(selectedKeycardRequest);

            databaseContext.SaveChanges();
            roomListView.ItemsSource = databaseContext.KeycardRequests.Include(u => u.User).ToList();

            string messageBoxText = "Keycard request successfully denied";
            string _caption = "Keycard denied";
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.Information;
            MainWindow.Send_Email(selectedUser.Email, "Request denied", "Your keycard request was denied.");
            MessageBox.Show(messageBoxText, _caption, button, icon, MessageBoxResult.OK);
        }
    }
}
