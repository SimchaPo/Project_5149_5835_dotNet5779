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
    /// Interaction logic for sign_in_tester.xaml
    /// </summary>
    public partial class sign_in_tester : Window
    {
        Tester tester;
        IBL bl;
        
        public sign_in_tester()
        {
            InitializeComponent();
            tester = new Tester();
            bl = FactoryBL.GetBL();
            DataContext = tester;
            carTypeTesterComboBox.ItemsSource = Enum.GetValues(typeof(CarType));
            genderTesterComboBox.ItemsSource = Enum.GetValues(typeof(Gender));
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void next_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                tester.mat = m2.mat1;
                bl.addTester(tester);
                Close();
                log_in_tester log_In = new log_in_tester(tester);
                log_In.ShowDialog();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
