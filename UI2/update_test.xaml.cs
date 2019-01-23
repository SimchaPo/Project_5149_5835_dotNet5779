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
    /// Interaction logic for update_test.xaml
    /// </summary>
    public partial class update_test : Window
    {
        Trainee trainee;
        Test test_to_update;
        IBL bl;
        public update_test(Test test)
        {
            InitializeComponent();
            bl = FactoryBL.GetBL();
            test_to_update = test;
            test_to_update.Results = new examResults();
            trainee = bl.GetTrainee(test.TraineeId);
            DataContext = test;
            
        }

        private void update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(mirrors.SelectedIndex == 0 || blinkers.SelectedIndex == 0 || distance.SelectedIndex == 0 || passTest.SelectedIndex == 0)
                {
                    throw new Exception("יש לתת ציון לכל אחד מהפרמטרים");
                }
                if (mirrors.SelectedIndex == 1)
                {
                    test_to_update.Results.mirrors = true;
                }
                else
                {
                    test_to_update.Results.mirrors = false;
                }
                if(blinkers.SelectedIndex == 1)
                {
                    test_to_update.Results.blinker = true;
                }
                else
                {
                    test_to_update.Results.blinker = false;
                }
                if(distance.SelectedIndex == 1)
                {
                    test_to_update.Results.distance = true;
                }
                else
                {
                    test_to_update.Results.distance = false;
                }
                if(passTest.SelectedIndex == 1)
                {
                    test_to_update.Results.passTest = true;
                }
                else
                {
                    test_to_update.Results.passTest = false;
                }
                bl.updateTest(test_to_update);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "שגיאה", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void cancle_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
