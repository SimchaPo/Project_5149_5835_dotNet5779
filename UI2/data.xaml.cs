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
    /// Interaction logic for data.xaml
    /// </summary>
    public partial class data : Window
    {
        IBL bl;

        ObservableCollection<Tester> testers1 = new ObservableCollection<Tester>();
        ObservableCollection<Trainee> trainees1 = new ObservableCollection<Trainee>();
        ObservableCollection<TestDetailes> tests1 = new ObservableCollection<TestDetailes>();

        public data()
        {
            InitializeComponent();
            bl = FactoryBL.GetBL();
            testers.DataContext = testers1;
            trainees.DataContext = trainees1;
            tests.DataContext = tests1;
            foreach (Test t in bl.getTests())
            {
                tests1.Add(new TestDetailes
                {
                    examId = t.TestNum,
                    dateTime = t.TestDate,
                    address = t.AddressTest,
                    TraineeName = bl.GetTrainee(t.TraineeId).NameTrainee,
                    TesterName = bl.GetTester(t.TesterId).NameTester,
                    type = t.carType.ToString() + " " + t.gearbox,
                });
            }
            foreach (Tester t in bl.getTesters())
            {
                testers1.Add(t);
            }
            foreach (Trainee t in bl.getTrainees())
            {
                trainees1.Add(t);
            }
        }
        internal class TestDetailes
        {
            public string examId { get; set; }
            public DateTime dateTime { set; get; }
            public Address address { set; get; }
            public FullName TraineeName { set; get; }
            public FullName TesterName { set; get; }
            public string type { set; get; }
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private List<IGrouping<CarType, Tester>> GroupTestersByCarType()
        {
            List<Tester> testers = bl.getTesters();
            var v = from tester in testers
                    group tester by tester.CarTypeTester;
            return v.ToList();
        }
    }
}
