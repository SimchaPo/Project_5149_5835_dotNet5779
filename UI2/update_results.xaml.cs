using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for update_results.xaml
    /// </summary>
    public partial class update_results : Window
    {
        IBL bl;
        Trainee trainee;
        Test test_to_update;
        TestDetailes test;
        ObservableCollection<TestDetailes> testDetailes = new ObservableCollection<TestDetailes>();
        public update_results(List<Test> tests1)
        {
            InitializeComponent();
            bl = FactoryBL.GetBL();
            trainee = new Trainee();
            test_to_update = new Test();
            listBox.DataContext = testDetailes;
            foreach (Test t in tests1)
            {
                if (t.TestDate < DateTime.Now && t.Results == null)
                {
                    testDetailes.Add(new TestDetailes
                    {
                        examId = t.TestNum,
                        dateTime = t.TestDate,
                        address = t.AddressTest,
                        TraineeName = bl.GetTrainee(t.TraineeId).NameTrainee,
                        type = t.carType.ToString() + " " + t.gearbox,
                    });
                }
            }
        }
        internal class TestDetailes
        {
            public Address address { set; get; }
            public string examId { get; set; }
            public DateTime dateTime { set; get; }
            public FullName TraineeName { set; get; }
            public string type { set; get; }
        }

        private void finish_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                test_to_update.Results = new examResults();
                if (mirrors.SelectedIndex == 0 || blinkers.SelectedIndex == 0 || distance.SelectedIndex == 0 || passTest.SelectedIndex == 0)
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
                if (blinkers.SelectedIndex == 1)
                {
                    test_to_update.Results.blinker = true;
                }
                else
                {
                    test_to_update.Results.blinker = false;
                }
                if (distance.SelectedIndex == 1)
                {
                    test_to_update.Results.distance = true;
                }
                else
                {
                    test_to_update.Results.distance = false;
                }
                if (passTest.SelectedIndex == 1)
                {
                    test_to_update.Results.passTest = true;
                }
                else
                {
                    test_to_update.Results.passTest = false;
                }
                bl.updateTest(test_to_update);
                testDetailes.Remove(test);
                updateTest.Visibility = Visibility.Hidden;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "שגיאה", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void cancle_Click(object sender, RoutedEventArgs e)
        {
            updateTest.Visibility = Visibility.Hidden;
        }

        private void update_this_test_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            int index = listBox.Items.IndexOf(button.DataContext);
            test = listBox.Items[index] as TestDetailes;
            test_to_update = bl.GetTest(test.examId);
            updateTest.DataContext = test;
            mirrors.SelectedIndex = 0;
            blinkers.SelectedIndex = 0;
            distance.SelectedIndex = 0;
            passTest.SelectedIndex = 0;
            updateTest.Visibility = Visibility.Visible;
        }
    }
}
