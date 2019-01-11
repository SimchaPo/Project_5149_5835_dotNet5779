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
    /// Interaction logic for sign_in_trainee.xaml
    /// </summary>
    public partial class sign_in_trainee : Window
    {
        Trainee trainee;
        IBL bl;
        Checks checks;
        public sign_in_trainee()
        {
            InitializeComponent();
            trainee = new Trainee();
            bl = FactoryBL.GetBL();
            DataContext = trainee;
            carTypeTraineeComboBox.ItemsSource = Enum.GetValues(typeof(CarType));
            gearboxTraineeComboBox.ItemsSource = Enum.GetValues(typeof(Gearbox));
            genderTraineeComboBox.ItemsSource = Enum.GetValues(typeof(Gender));
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void next_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.addTrainee(trainee);
                Close();
                log_in_trainee log_In = new log_in_trainee(trainee);
                log_In.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
