
using skyline_odyssey_keycard_management.Views;
using System.Net.Mail;
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

using System.Net;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;


namespace skyline_odyssey_keycard_management
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DatabaseContext _databaseContext;
        public MainWindow()
        {
            InitializeComponent();
            this.Closing += MainWindow_Closing;

            _databaseContext = new DatabaseContext();
				
			
		}

        public static void Send_Email(string to, string subject, string body)
        {

			MailMessage message = new MailMessage();
			SmtpClient smtp = new SmtpClient();
			message.From = new MailAddress("skylinekeycardsystem@gmail.com");
			message.To.Add(new MailAddress(to));
			message.Subject = subject;
			message.IsBodyHtml = true;
			message.Body = body;
			smtp.Port = 587;
			smtp.Host = "smtp.gmail.com";
			smtp.EnableSsl = true;
			smtp.UseDefaultCredentials = false;
			smtp.Credentials = new NetworkCredential("skylinekeycardsystem@gmail.com", "jppj gwst dcbt agcm");
			smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
			smtp.Send(message);
		}

		private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			
				var user = LoginView.LoggedInUser;
				
				Trace.WriteLine(user.ToString());

				user.IsOnline = false;
				user.UsageHistories.Add(new Models.UsageHistory(user.KeycardId, DateTime.Now, 5, "Out"));

				var usageHistories = user.UsageHistories.ToList();

				if (user.Role.Name == "Employee")
				{
					usageHistories.RemoveAll(u => u.Timestamp.Date != DateTime.Now.Date);
					usageHistories.RemoveAll(u => u.InOut != "In" && u.AccessPointId != 5);
					var usageHistory = usageHistories.Min(u => u.Timestamp);

					Trace.WriteLine("Usage history: " + usageHistory);

					var managers = _databaseContext.Users.Where(u => u.Role.Name == "Manager" || u.Role.Name == "CEO").ToList();
					var timeDifference = DateTime.Now - usageHistory;

					
					if (DateTime.Now.Hour <6 && timeDifference.Hours < 8)
					{
						foreach(var manager in managers)
						{
								Send_Email(manager.Email, "Employee left", user.Role.Name + " " + user.FirstName + " " + user.LastName + " left the office. Worked today for " + timeDifference.Hours + " hour and " + timeDifference.Minutes + " minutes");
						}
						
						Send_Email(user.Email, "Employee left", "You left the office. Worked today for " + timeDifference.Hours + " hour and " + timeDifference.Minutes + " minutes");
					}
				}



				DatabaseContext databaseContext = new DatabaseContext();
				databaseContext.Update(LoginView.LoggedInUser);
				databaseContext.SaveChanges();


			
			

		}
    }
}