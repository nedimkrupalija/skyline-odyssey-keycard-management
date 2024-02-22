using skyline_odyssey_keycard_management.Views;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace skyline_odyssey_keycard_management
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Closing += MainWindow_Closing;

        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
                var user = LoginView.LoggedInUser;

                user.IsOnline = false;
                user.UsageHistories.Add(new Models.UsageHistory(user.KeycardId, DateTime.Now, 5, "Out"));


                DatabaseContext databaseContext = new DatabaseContext();
                databaseContext.Update(LoginView.LoggedInUser);
                databaseContext.SaveChanges();

           
        }
    }
}