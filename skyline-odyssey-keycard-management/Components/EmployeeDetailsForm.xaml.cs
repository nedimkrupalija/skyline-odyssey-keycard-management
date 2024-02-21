﻿using skyline_odyssey_keycard_management.Models;
using skyline_odyssey_keycard_management.Views;
using System;
using System.Collections.Generic;
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
            this.Close();   
        }
		
		private void Submit_Clicked(object sender, RoutedEventArgs e)
        {
            
            try
            { 
            var roles = _databaseContext.Roles.ToList();
            var users = _databaseContext.Users.ToList();
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
		    if(!Regex.IsMatch(FirstName.Text, @"^[a-zA-Z]+$")||!Regex.IsMatch(LastName.Text, @"^[a-zA-Z]+$"))
                    throw new Exception();


				_databaseContext.Users.Add(new User(FirstName.Text, LastName.Text, FirstName.Text+LastName.Text+userCount, FirstName.Text  + LastName.Text + userCount,userRole.Id, userRole,userKeycard.Id, userKeycard));
				_databaseContext.SaveChanges();
				MessageBoxResult result = MessageBox.Show( "User succesfully added");
				this.Close();   
                




			}
			catch(Exception ex)
            {
				MessageBoxResult result = MessageBox.Show( "Please input valid credentials");
			}
			
			

		}



    }
}
