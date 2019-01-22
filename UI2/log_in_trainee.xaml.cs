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
    /// Interaction logic for log_in_trainee.xaml
    /// </summary>
    public partial class log_in_trainee : Window
    {
        Trainee trainee1;
        IBL bl;
        public log_in_trainee(Trainee trainee)
        {
            InitializeComponent();
            trainee1 = trainee;
            DataContext = trainee;
            bl = FactoryBL.GetBL();
        }
        private void updateTrainee_Click(object sender, RoutedEventArgs e)
        {
            update_trainee update_Trainee = new update_trainee(trainee1.Clone(), this);
            update_Trainee.ShowDialog();
        }

        private void order_test_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.checkTraineeDoTest(trainee1);
                create_a_test create = new create_a_test(trainee1);
                create.ShowDialog();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "שגיאה", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void get_score_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<Test> traineeTests = new List<Test>(bl.getTestsOfTrainee(trainee1));
                if (traineeTests.Count == 0)
                {
                    throw new Exception("אין מבחנים להצגה");
                }
                show_trainees_tests trainees_Tests = new show_trainees_tests(traineeTests);
                trainees_Tests.ShowDialog();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "שגיאה", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void delete_trainee_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result;
            result = MessageBox.Show("האם אתה רוצה למחוק את עצמך מהמערכת", "מחיקת תלמיד", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.None, MessageBoxOptions.RtlReading);
            if (result == MessageBoxResult.Yes)
            {
                bl.removeTrainee(trainee1.IdTrainee);
                Close();
            }
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
