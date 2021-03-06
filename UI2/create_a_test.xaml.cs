﻿using System;
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
    /// Interaction logic for create_a_test.xaml
    /// </summary>
    public partial class create_a_test : Window
    {
        Tester tester;
        Trainee trainee;
        Test testToCreate;
        DateTime dateTime;
        IBL bl;
        ObservableCollection<Tester> testers = new ObservableCollection<Tester>();
        public create_a_test(Trainee trainee6)
        {
            InitializeComponent();
            tester = new Tester();
            testToCreate = new Test();
            bl = FactoryBL.GetBL();
            trainee = trainee6;
            DataContext = trainee;
            listBox.ItemsSource = testers;
        }

        private void test_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                tester = listBox.SelectedValue as Tester;
                testToCreate.TesterId = tester.IdTester;
                testToCreate.TraineeId = trainee.IdTrainee;
                testToCreate.TestDate = dateTime;
                testToCreate.AddressTest = trainee.AddressTrainee;
                bl.AddTest(testToCreate);
                MessageBox.Show("נקבע עבורך מבחן בתאריך " + testToCreate.TestDate + "\nבוחן: " +
                    bl.GetTester(testToCreate.TesterId).NameTester.FirstName + " " + bl.GetTester(testToCreate.TesterId).NameTester.LastName,
                    "מבחן", MessageBoxButton.OK, MessageBoxImage.Question, MessageBoxResult.None, MessageBoxOptions.RtlReading);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "שגיאה", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listBox.SelectedValue != null)
            {
                buttonTest.IsEnabled = true;
            }
        }

        private void getAvailableTesters_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                testers.Clear();
                if (testDate.SelectedDate == null)
                    throw new Exception("אנא בחר תאריך");
                if (hour.SelectedIndex == 0)
                    throw new Exception("אנא בחר שעה");
                int Year, Month, Day, Hour;
                Year = testDate.SelectedDate.Value.Year;
                Month = testDate.SelectedDate.Value.Month;
                Day = testDate.SelectedDate.Value.Day;
                Hour = hour.SelectedIndex + 8;
                dateTime = new DateTime(Year, Month, Day, Hour, 00, 00);
                if (dateTime < DateTime.Now)
                {
                    throw new Exception("התאריך עבר..");
                }
                foreach (Tester t in bl.getTestersAvailable(dateTime))
                {
                    testers.Add(t);
                }

                if (testers.Count == 0)
                {
                    List<DateTime> availableDatesToShow = new List<DateTime>();
                    MessageBox.Show("לא נמצאו מבחנים בתאריך המבוקש," + "\n" + "המערכת מחפשת אחר מבחנים נוספים בשבוע זה", "שים לב",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    foreach (DateTime t in bl.getMoreDatesAvailable(dateTime))
                    {
                        availableDatesToShow.Add(t);
                    }
                    listBoxDates.ItemsSource = availableDatesToShow;
                    availableDates.Visibility = Visibility.Visible;
                    return;
                } 
                availableTesters.Visibility = Visibility.Visible;
                search.Visibility = Visibility.Visible;
                myProgressBar.Visibility = Visibility.Visible;
                checkTestersInRange();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "שגיאה", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void buttonDate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(listBoxDates.SelectedValue == null)
                {
                    throw new Exception("יש לבחור תאריך מהרשימה");
                }
                dateTime = (DateTime)listBoxDates.SelectedValue;
                availableDates.Visibility = Visibility.Collapsed;
                testers.Clear();
                foreach (Tester t in bl.getTestersAvailable(dateTime))
                {
                    testers.Add(t);
                }
                availableTesters.Visibility = Visibility.Visible;
                search.Visibility = Visibility.Visible;
                myProgressBar.Visibility = Visibility.Visible;
                checkTestersInRange();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "שגיאה", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}