using skyline_odyssey_keycard_management.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
    public partial class EmployeeDetailsForm : UserControl
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
            CancelClicked?.Invoke(this, EventArgs.Empty);
        }
		    
        private void Submit_Clicked(object sender, RoutedEventArgs e)
        {
            try
            { 
            var roles = _databaseContext.Roles.ToList();
            var users = _databaseContext.Users.ToList();
                Trace.WriteLine(users[0].Role.Name);
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


            
                _databaseContext.Users.Add(new User(FirstName.Text, LastName.Text, FirstName.Text+"1"+LastName.Text+"1", FirstName.Text + "1" + LastName.Text + "1",userRole.Id, userRole,userKeycard.Id, userKeycard));
				_databaseContext.SaveChanges();
				MessageBoxResult result = MessageBox.Show("User succesfully added");
                SubmitClicked?.Invoke(this, EventArgs.Empty);
                
               
                  
			}
			catch(Exception ex)
            {
				MessageBoxResult result = MessageBox.Show("Please input valid credentials");
			}
			
			

		}



    }
}
