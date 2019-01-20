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
    /// Interaction logic for show_trainees_tests.xaml
    /// </summary>
    public partial class show_trainees_tests : Window
    {
        Trainee trainee1;
        IBL bl;
        public show_trainees_tests(List<Test> tests)
        {
            InitializeComponent();
        }
    }
}
