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
    /// Interaction logic for groups.xaml
    /// </summary>
    public partial class groups : Window
    {
        IBL bl;
        public groups()
        {
            InitializeComponent();
            bl = FactoryBL.GetBL();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<Trainee> trainees2 = new List<Trainee>();
            List<IGrouping<int, Trainee>> trainees = bl.GetTraineesGroupedByNumOfTests();
            var v = (from t in trainees
                    where t.Key == 1
                    select t).ToList().First();
            foreach(Trainee trainee in v)
            {
                trainees2.Add(trainee);
            }
            testers.ItemsSource = trainees2;
        }
        internal class TestDetailes
        {
            public Address Address { set; get; }
            public DateTime dateTime { set; get; }
            public FullName NameTrainee { set; get; }
            public FullName NameTester { set; get; }
            public string type { set; get; }
        }

        private void show_Click(object sender, RoutedEventArgs e)
        {
            if(tester.IsChecked == true )
            {
                if(sorted.IsChecked == true)
                {

                }

            }

        }

        private void tester_Checked(object sender, RoutedEventArgs e)
        {
            carTypeTester.Visibility = Visibility.Visible;
            //carTypeTester.ItemsSource = 
        }
    }
}
