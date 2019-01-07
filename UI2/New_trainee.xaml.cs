﻿using System;
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
    /// Interaction logic for window4.xaml
    /// </summary>
    public partial class New_trainee : Window
    {
        Tester tester;
        Trainee trainee;
        Test test;
        IBL bl;
        public New_trainee()
        {
            InitializeComponent();
            tester = new Tester();
            trainee = new Trainee();
            test = new Test();
            bl = FactoryBL.GetBL();
            //newTrainee.DataContext = trainee;
            traineeName.DataContext = trainee;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(trainee.NameTrainee + "\n" + trainee.IdTrainee + "\n" + trainee.PhoneNumberTrainee);
        }
    }
}
