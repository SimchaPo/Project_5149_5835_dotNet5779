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
    /// Interaction logic for log_in_trainee.xaml
    /// </summary>
    public partial class log_in_trainee : Window
    {
        public log_in_trainee()
        {
            InitializeComponent();
        }
        public log_in_trainee(Trainee trainee)
        {
            InitializeComponent();
            DataContext = trainee;
        }
    }
}
