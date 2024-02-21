using System;
using System.Collections.Generic;
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
    /// <summary>
    /// Interaction logic for TimePickerControl.xaml
    /// </summary>
    public partial class TimePickerControl : UserControl
    {
        public List<int> Hours { get; } = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 00 };
        public List<int> Minutes { get; } = new List<int> { 0, 15, 30, 45 };
        public TimePickerControl()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
}
