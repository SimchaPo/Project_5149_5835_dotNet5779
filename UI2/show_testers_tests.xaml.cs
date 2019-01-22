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
    /// Interaction logic for show_testers_tests.xaml
    /// </summary>
    public partial class show_testers_tests : Window
    {
        IBL bl;
        ObservableCollection<TestDetailes> testDetailes = new ObservableCollection<TestDetailes>();
        public show_testers_tests(List<Test> tests1)
        {
            InitializeComponent();
            bl = FactoryBL.GetBL();
            listBox.DataContext = testDetailes;
            foreach (Test t in tests1)
            {
                testDetailes.Add(new TestDetailes
                {
                    dateTime = t.TestDate, address = t.AddressTest,
                    TraineeName = bl.GetTrainee(t.TraineeId).NameTrainee.FirstName + " " + bl.GetTrainee(t.TraineeId).NameTrainee.LastName,
                    type = t.carType.ToString() + " " + t.gearbox,
                    results = t.Results
                });
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}