using Microsoft.EntityFrameworkCore;
using skyline_odyssey_keycard_management.Models;
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
            var clearanceLevels = _databaseContext.AccessPoints.ToList();
            foreach (var level in clearanceLevels)
            {
                if (!ComboBoxAccessPoints.Items.Contains(level.AccessLevel))
                {
                    ComboBoxAccessPoints.Items.Add(level.AccessLevel);
                }

            }

        }

        private void ChangeClearance_Clicked(object sender, RoutedEventArgs e)
        {
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
                        Trace.WriteLine("current " + currentAccessPoint.Name);
                        
                    }
                }
  
            }

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
