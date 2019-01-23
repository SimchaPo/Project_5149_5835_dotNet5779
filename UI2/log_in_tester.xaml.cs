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
        ImageBrush notWorking = new ImageBrush();
        Image imageNotWorking = new Image();
        ImageBrush working = new ImageBrush();
        Image imageWorking = new Image();
        public log_in_tester(Tester tester)
        {
            InitializeComponent();
            tester1 = tester;
            DataContext = tester;
            bl = FactoryBL.GetBL();
            imageNotWorking.Source = new BitmapImage(new Uri("C:/Users/OWNER/source/repos/SimchaPo/Project_5149_5835_dotNet5779/UI2/images/עובד לא.jpg"));
            notWorking.ImageSource = imageNotWorking.Source;
            imageWorking.Source = new BitmapImage(new Uri("C:/Users/OWNER/source/repos/SimchaPo/Project_5149_5835_dotNet5779/UI2/images/עובד.jpg"));
            working.ImageSource = imageWorking.Source;
            foreach (Button item in buttons.Children)
            {
                int x = int.Parse(item.Name[1].ToString());
                int y = int.Parse(item.Name[3].ToString());
                if (tester.mat[x, y] == true)
                {
                    item.Background = working;
                }
                if (tester.mat[x, y] == false)
                {
                    item.Background = notWorking;
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
        }

        private void delete_tester_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result;
            result = MessageBox.Show("האם אתה רוצה למחוק את עצמך מהמערכת", "מחיקת בוחן", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.None, MessageBoxOptions.RtlReading);
            if (result == MessageBoxResult.Yes)
            {
                bl.removeTester(tester1.IdTester);
                Close();
            }
        }

        private void update_test_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<Test> testerTests = new List<Test>(bl.getTestsOfTester(tester1));
                if (testerTests.Count == 0)
                {
                    throw new Exception("אין מבחנים לעדכן");
                }
                update_results update = new update_results(testerTests);
                update.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "שגיאה", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void get_tests_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<Test> testerTests = new List<Test>(bl.getTestsOfTester(tester1));
                if (testerTests.Count == 0)
                {
                    throw new Exception("אין מבחנים להצגה");
                }
                show_testers_tests testers_Tests = new show_testers_tests(testerTests);
                testers_Tests.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "שגיאה", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}