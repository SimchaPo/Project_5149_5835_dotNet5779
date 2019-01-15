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
        Tester tester1;
        IBL bl;
        public log_in_tester(Tester tester)
        {
            InitializeComponent();
            tester1 = tester;
            DataContext = tester;
            bl = FactoryBL.GetBL();
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

        private void updateTester_Click(object sender, RoutedEventArgs e)
        {
            update_tester update_Tester = new update_tester(tester1.Clone(), this);
            update_Tester.ShowDialog();
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void delete_tester_Click(object sender, RoutedEventArgs e)
        {
            bl.removeTester(tester1.IdTester);
            Close();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void update_test_Click(object sender, RoutedEventArgs e)
        {
           // bl.updateTest();
        }

        private void get_tests_Click(object sender, RoutedEventArgs e)
        {
            bl.getTests();
        }
    }
}
