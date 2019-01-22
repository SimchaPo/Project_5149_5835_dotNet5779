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
        ObservableCollection<TestDetailes> testDetailes = new ObservableCollection<TestDetailes>();
        public update_results(List<Test> tests1)
        {
            InitializeComponent();
            bl = FactoryBL.GetBL();
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
                        TraineeName = bl.GetTrainee(t.TraineeId).NameTrainee.FirstName + " " + bl.GetTrainee(t.TraineeId).NameTrainee.LastName,
                        type = t.carType.ToString() + " " + t.gearbox,
                    });
                }
            }
        }
        internal class TestDetailes
        {
            public Address address { set; get; }
            public string getAddress
            {
                get
                {
                    return "רחוב " + address.Street + " " + address.HouseNum + ", " + address.City;
                }
            }
            public string examId { get; set; }
            public DateTime dateTime { set; get; }
            public string TraineeName { set; get; }
            public string type { set; get; }
            public examResults results { get; set; }
            public string passTest
            {
                get
                {
                    if (results != null)
                    {
                        if (results.passTest == true)
                            return "תלמיד עבר בהצלחה את מבחן הנהיגה";
                        else
                            return "תלמיד נכשל במבחן הנהיגה";
                    }
                    return null;
                }
            }
        }

        private void update_Click(object sender, RoutedEventArgs e)
        {
            foreach(var v in listBox.Items)
            {

            }
        }

        private void cancle_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void update_result_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            int index = listBox.Items.IndexOf(button.DataContext);
            TestDetailes test = listBox.Items[index] as TestDetailes;
            update_test update = new update_test(bl.GetTest(test.examId));
            update.ShowDialog();
        }
    }
}
