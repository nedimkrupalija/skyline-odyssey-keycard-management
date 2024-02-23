using skyline_odyssey_keycard_management.Models;
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
    /// Interaction logic for EmployeePanelView.xaml
    /// </summary>
    public partial class EmployeePanelView : UserControl
    {
        public EmployeePanelView()
        {
            InitializeComponent();
        }



        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            DatabaseContext _databaseContext = new DatabaseContext();
            LoginView loginView = new LoginView();
            LoginView.LoggedInUser.IsOnline = false;
            LoginView.LoggedInUser.UsageHistories.Add(new UsageHistory(LoginView.LoggedInUser.Keycard.Id, DateTime.Now, 5, "Out"));
            _databaseContext.Update(LoginView.LoggedInUser);
            _databaseContext.SaveChanges();
            this.Content = loginView;
        }
    }
}
