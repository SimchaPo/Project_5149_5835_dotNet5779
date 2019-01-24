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
            List<IGrouping<int, Trainee>> trainees = bl.GetTraineesGroupedByNumOfTests(true);
            var v = (from t in trainees
                     where t.Key == 1
                     select t).ToList().First();
            foreach (Trainee trainee in v)
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
            try
            {
                if (tester.IsChecked == false && trainee.IsChecked == false ||
                    sorted.IsChecked == false && notSorted.IsChecked == false)
                    throw new Exception("יש לסמן בחירה בכל אחת מן האפשרויות");
                List<Tester> testersToShow = new List<Tester>();
                List<Trainee> traineesToShow = new List<Trainee>();
                if (tester.IsChecked == true)
                {
                    if (carTypesOfTester.SelectedIndex == 0)
                    {
                        if (sorted.IsChecked == true)
                        {
                            var v = from Tester t in bl.getTesters()
                                    orderby t.NameTester.LastName, t.NameTester.FirstName
                                    select t;
                            foreach (var item in v)
                            {
                                testersToShow.Add(item);
                            }
                        }
                        if (sorted.IsChecked == false)
                        {
                            testersToShow = bl.getTesters();
                        }
                    }
                    if (carTypesOfTester.SelectedIndex != 0)
                    {
                        testersToShow = getTestersBySelectedCarType(carTypesOfTester.SelectedValue.ToString(), (bool)sorted.IsChecked);
                    }
                    testers.Visibility = Visibility.Visible;
                    testers.ItemsSource = testersToShow;
                }
                if (trainee.IsChecked == true)
                {
                    if (groupTraineeBy.SelectedIndex == 0)
                    {
                        if (sorted.IsChecked == true)
                        {
                            var v = from Trainee t in bl.getTrainees()
                                    orderby t.NameTrainee.LastName, t.NameTrainee.FirstName
                                    select t;
                            foreach (var item in v)
                            {
                                traineesToShow.Add(item);
                            }
                        }
                        if (sorted.IsChecked == false)
                        {
                            traineesToShow = bl.getTrainees();
                        }
                    }
                    trainees.ItemsSource = traineesToShow;
                    if (groupTraineeBy.SelectedIndex > 0) 
                    {
                        if (traineeComboBox.SelectedValue == null)
                        {
                            throw new Exception("יש לבחור בסינון הרצוי");
                        }
                            switch (groupTraineeBy.SelectedIndex)
                        {
                            case 1:
                                trainees.ItemsSource = getTraineesBySelectedSchool(traineeComboBox.SelectedValue.ToString(), (bool)sorted.IsChecked);
                                break;
                            case 2:
                                trainees.ItemsSource = getTraineeBySelectedTeacher(traineeComboBox.SelectedValue.ToString(), (bool)sorted.IsChecked);
                                break;
                            case 3:
                                trainees.ItemsSource = getTraineeBySelectedNumOfTests(traineeComboBox.SelectedValue.ToString(), (bool)sorted.IsChecked);
                                break;
                        }
                    }
                    trainees.Visibility = Visibility.Visible;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "שגיאה", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void tester_Checked(object sender, RoutedEventArgs e)
        {
            if(tester.IsChecked != true)
            {
                carTypesOfTester.Visibility = Visibility.Collapsed;
                return;
            }
            List<string> types = new List<string>();
            types.Add("כולם");
            carTypesOfTester.Visibility = Visibility.Visible;
            var carTypesGroups = from t in bl.getTesters()
                                 group t by t.CarTypeTester into g
                                 select new { type = g.Key, testers = g };
            foreach (var item in carTypesGroups)
            {
                types.Add(item.type.ToString());
            }
            carTypesOfTester.ItemsSource = types;
        }

        private void trainee_Checked(object sender, RoutedEventArgs e)
        {
            if(trainee.IsChecked == false)
            {
                groupTraineeBy.Visibility = Visibility.Collapsed;
                traineeComboBox.Visibility = Visibility.Collapsed;
                return;
            }
            groupTraineeBy.Visibility = Visibility.Visible;
            List<string> traineesoption = new List<string>();
            traineesoption.Add("כולם");
            traineesoption.Add("בית ספר");
            traineesoption.Add("מורה");
            traineesoption.Add("מספר מבחנים");
            groupTraineeBy.ItemsSource = traineesoption;
        }

        private void test_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void sorted_Checked(object sender, RoutedEventArgs e)
        {

        }


        private void groupTraineeBy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<string> strs = new List<string>();
            switch (groupTraineeBy.SelectedIndex)
            {
                case 0:
                    traineeComboBox.Visibility = Visibility.Collapsed;
                    return;
                case 1:
                    strs = getListForComboBoxBySChool();
                    break;
                case 2:
                    strs = getListForComboBoxByTeacher();
                    break;
                case 3:
                    strs = getListForComboBoxByNumOfTests();
                    break;
            }
            traineeComboBox.Visibility = Visibility.Visible;
            traineeComboBox.ItemsSource = strs;
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
