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
    /// Interaction logic for Conect_old_trainee.xaml
    /// </summary>
    public partial class Conect_old_trainee : Window
    {
        Trainee trainee;

        public Conect_old_trainee()
        {
            InitializeComponent();
            trainee = new Trainee();
            DataContext = trainee;
            carTypeTraineeComboBox.ItemsSource = Enum.GetValues(typeof(CarType));
            gearboxTraineeComboBox.ItemsSource = Enum.GetValues(typeof(Gearbox));
            genderTraineeComboBox.ItemsSource = Enum.GetValues(typeof(Gender));
        }
    }
}
