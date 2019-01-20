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
    /// Interaction logic for log_in_trainee.xaml
    /// </summary>
    public partial class log_in_trainee : Window
    {
        Trainee trainee1;
        IBL bl;
        public log_in_trainee(Trainee trainee)
        {
            InitializeComponent();
            trainee1 = trainee;
            DataContext = trainee;
            bl = FactoryBL.GetBL();
        }
        private void updateTrainee_Click(object sender, RoutedEventArgs e)
        {
            update_trainee update_Trainee = new update_trainee(trainee1.Clone(), this);
            update_Trainee.ShowDialog();
        }

        private void order_test_Click(object sender, RoutedEventArgs e)
        {
            create_a_test create = new create_a_test(trainee1);
            create.ShowDialog();
        }

        private void get_score_Click(object sender, RoutedEventArgs e)
        {

        }

        private void delete_trainee_Click(object sender, RoutedEventArgs e)
        {
            bl.removeTrainee(trainee1.IdTrainee);
            Close();
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
