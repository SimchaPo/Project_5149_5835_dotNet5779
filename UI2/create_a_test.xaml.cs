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
            list.DataContext = testers;
        }

        private void test_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(tester.IdTester + " " + tester.NameTester.FirstName);
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                tester = listBox.SelectedItem as Tester;
                testToCreate.TesterId = tester.IdTester;
                testToCreate.TraineeId = trainee.IdTrainee;
                testToCreate.TestDate = dateTime;
                bl.AddTest(testToCreate);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                foreach (Tester t in bl.getTestersAvailable(dateTime))
                {
                    testers.Add(t);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
