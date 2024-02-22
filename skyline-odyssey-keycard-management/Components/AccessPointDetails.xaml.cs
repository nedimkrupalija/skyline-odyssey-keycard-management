using Microsoft.EntityFrameworkCore;
using skyline_odyssey_keycard_management.Models;
using skyline_odyssey_keycard_management.Store;
using skyline_odyssey_keycard_management.ViewModels;
using skyline_odyssey_keycard_management.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
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


namespace skyline_odyssey_keycard_management.Components


{
 
    public partial class AccessPointDetails : UserControl
    {

        private DatabaseContext _databaseContext = new DatabaseContext();

        public AccessPointDetails()
        {
            InitializeComponent();
            AssignClearanceLevel();
        }

        private void AssignClearanceLevel()
        {
                    ComboBoxAccessPoints.Items.Add(3);
                    ComboBoxAccessPoints.Items.Add(4);
                    ComboBoxAccessPoints.Items.Add(5);
        }

        private void ChangeClearance_Clicked(object sender, RoutedEventArgs e)
        {


            try { 
            var accessPoints = _databaseContext.AccessPoints.ToList();

            var currentAccessPoint = new AccessPoint();
            
            

            foreach (var point in accessPoints)
            {
                if (point.Name == AccessPointName.Text)
                {
                    if (point.AccessLevel != int.Parse(ComboBoxAccessPoints.Text))
                    {
                        currentAccessPoint = point;
                        currentAccessPoint.AccessLevel = int.Parse(ComboBoxAccessPoints.Text);
                       _databaseContext.AccessPoints.Update(currentAccessPoint);
						_databaseContext.SaveChanges();
						string messageBoxText = "Clearance changed successfully.";
							string caption = "Success";
							MessageBoxButton button = MessageBoxButton.OK;
							MessageBoxImage icon = MessageBoxImage.Information;
							MessageBoxResult result;
							result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.OK);
						}
                }
  
            }

			

            }
            catch (Exception ex) { }



		}


    }
}
