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
using System.Windows.Shapes;
using BE;
using BL;

namespace UI2
{
    /// <summary>
    /// Interaction logic for log_in_tester.xaml
    /// </summary>
    public partial class log_in_tester : Window
    {
        public string buttonName { get; set; }
        public log_in_tester(Tester tester)
        {
            InitializeComponent();
            DataContext = tester;
            foreach (Button item in buttons.Children)
            {
                int x = item.Name[1] - 48;
                int y = item.Name[3] - 48;
                if (tester.mat[x, y] == true)
                {
                    item.Background = Brushes.Green;
                }
                if (tester.mat[x, y] == false)
                {
                    item.Background = Brushes.Red;
                }
            }
        }
    }
}
