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
    /// Interaction logic for show_trainees_tests.xaml
    /// </summary>
    public partial class show_trainees_tests : Window
    {
        IBL bl;
        ObservableCollection<TestDetailes> testDetailes = new ObservableCollection<TestDetailes>();
        public show_trainees_tests(List<Test> tests1)
        {
            InitializeComponent();
            bl = FactoryBL.GetBL();
            listBox.DataContext = testDetailes;
            foreach (Test t in tests1)
            {
                testDetailes.Add(new TestDetailes
                {
                    dateTime = t.TestDate,
                    TesterName = bl.GetTester(t.TesterId).NameTester.FirstName + " " + bl.GetTester(t.TesterId).NameTester.LastName
                    , type = t.carType.ToString() + " " + t.gearbox, results = t.Results
                });
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
    internal class TestDetailes
    {
        public DateTime dateTime { set; get; }
        public string TesterName { set; get; }
        public string type { set; get; }
        public examResults results { get; set; }
        public bool pass { set; get; }
        public string checks
        {
            get
            {
                if (results != null)
                {
                    string str = "מראות:";
                    if (results.mirrors == true)
                        str += " עבר בהצלחה";
                    else
                        str += " נכשל";
                    str += " איתותים: ";
                    if (results.blinker == true)
                        str += " עבר בהצלחה";
                    else
                        str += " נכשל";
                    str += " שמירת מרחק: ";
                    if (results.distance == true)
                        str += " עבר בהצלחה";
                    else
                        str += " נכשל";
                    return str;
                }
                if (dateTime > DateTime.Now)
                {
                    return "מבחן עוד לא התקיים";
                }
                return "טרם פורסמו תוצאות המבחן";
            }
        }
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
}
