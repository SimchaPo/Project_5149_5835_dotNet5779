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
    /// Interaction logic for check.xaml
    /// </summary>
    public partial class check : Window
    {
        Trainee trainee;
        IBL bl;

        public check()
        {
            InitializeComponent();
            trainee = new Trainee();
            bl = FactoryBL.GetBL();
            DataContext = trainee;
            carTypeTraineeComboBox.ItemsSource = Enum.GetValues(typeof(CarType));
            gearboxTraineeComboBox.ItemsSource = Enum.GetValues(typeof(Gearbox));
            genderTraineeComboBox.ItemsSource = Enum.GetValues(typeof(Gender));
            //birthDateTraineeDatePicker.DataContext = trainee.BirthDateTrainee;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.addTrainee(trainee);
            }
            catch(Exception e2)
            {
                MessageBox.Show(e2.Message);
            }
        }
    }
}
