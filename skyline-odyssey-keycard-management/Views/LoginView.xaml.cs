using Microsoft.EntityFrameworkCore;
using skyline_odyssey_keycard_management.ViewModels;
using skyline_odyssey_keycard_management.Views;
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


namespace skyline_odyssey_keycard_management.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            DatabaseContext databaseContext = new DatabaseContext();
            var username = UsernameTextBox.Text;
            var password = PasswordTextBox.Password;
            var user = databaseContext.Users.Include(u => u.Role)
                .FirstOrDefault(u => u.Username == username && u.Password == password);
            if (user != null)
            {
                if (user.Role.Name.Equals("Manager"))
                {
                    AdminPanelView adminPanelView = new AdminPanelView();
                    this.Content = adminPanelView;
                }
                else if(user.Role.Name.Equals("Employee"))
                {
                    EmployeePanelView empPanelView = new EmployeePanelView();
                    this.Content = empPanelView;
                }
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Please input valid credentials");
            }
        }
    }
}
