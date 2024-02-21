using Microsoft.EntityFrameworkCore;
using skyline_odyssey_keycard_management.Models;
using skyline_odyssey_keycard_management.Store;
using skyline_odyssey_keycard_management.ViewModels;
using skyline_odyssey_keycard_management.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Interaction logic for EmployeeDetailsForm.xaml
    /// </summary>
    public partial class EmployeeDetailsForm : Window
    {
        public static User AddedUser = new User();
       private DatabaseContext _databaseContext = new DatabaseContext();
        public event EventHandler CancelClicked;
        public event EventHandler SubmitClicked;    
        public EmployeeDetailsForm()
        {
            
            InitializeComponent();
			AssignRoles();
            AssignKeycards();

		}

        private void AssignRoles()
        {
            var roleNames = new List<string>();
          foreach (var role in _databaseContext.Roles)
           {
               if(LoginView.LoggedInUser.Role.Id>role.Id)
                ComboBoxRole.Items.Add(role.Name);
            }
           
		}

        private void AssignKeycards()
        {
           var keycards = _databaseContext.Keycards.ToList();  
            foreach (var keycard in keycards)
            {
                if(keycard.IsAssigned == false)
				ComboBoxKeycard.Items.Add(keycard.Id);
			}
        }

        private void Close_Clicked(object sender, RoutedEventArgs e)
        {
            // Raise the CancelClicked event
            FirstName.Text = "";
            LastName.Text = "";
            ComboBoxKeycard.Text = "";

            this.Hide();   
        }
		
		private void Submit_Clicked(object sender, RoutedEventArgs e)
        {
            
            try
            { 
            var roles = _databaseContext.Roles.ToList();
            var users = _databaseContext.Users.ToList();
				if (!Regex.IsMatch(FirstName.Text, @"^[a-zA-Z]+$") || !Regex.IsMatch(LastName.Text, @"^[a-zA-Z]+$"))
					throw new Exception();

			string userCount = Convert.ToString(users.FindAll(u => u.FirstName == FirstName.Text && u.LastName == LastName.Text).Count+1);
            var userRole = new Role();
            foreach(var role in roles)
            {
                if(role.Name == ComboBoxRole.Text)
                {
                    userRole = role;
				}
            }

            var userKeycard = new Keycard();    
            var keycards = _databaseContext.Keycards.ToList();
            foreach(var keycard in keycards)
            {
				if(keycard.Id == int.Parse(ComboBoxKeycard.Text))
                {
					userKeycard = keycard;
                }
            }
                userKeycard.IsAssigned = true;
                _databaseContext.Update(userKeycard);
                var addedUser = new User(FirstName.Text, LastName.Text, FirstName.Text + LastName.Text + userCount, FirstName.Text + LastName.Text + userCount, userRole.Id, userRole, userKeycard.Id, userKeycard);
				_databaseContext.Users.Add(addedUser);
				_databaseContext.SaveChanges();
				//MessageBoxResult result = MessageBox.Show( "User succesfully added");
                string messageBoxText = "User succesfully added.";
                string caption = "Success";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Information;
                MessageBoxResult result;

                result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.OK);
                FirstName.Text = "";
                LastName.Text = "";
                ComboBoxKeycard.Text = "";


				var updatedUsers = _databaseContext.Users.Include(u => u.Keycard).Include(u => u.Role).ToList();
				
				

				this.Hide();   
                




			}
			catch(Exception ex)
            {
                //MessageBoxResult result = MessageBox.Show( "Please input valid credentials");
                string messageBoxText = "Please input valid credentials.";
                string caption = "Warning";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBoxResult result;

                result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.OK);
            }
			
			

		}



    }
}
