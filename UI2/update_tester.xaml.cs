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
    /// Interaction logic for update_tester.xaml
    /// </summary>
    public partial class update_tester : Window
    {
        Tester tester;
        IBL bl;
        log_in_tester log;
        public bool[,] mat1 { set; get; }
        ImageBrush notWorking = new ImageBrush();
        Image imageNotWorking = new Image();
        ImageBrush working = new ImageBrush();
        Image imageWorking = new Image();
        public update_tester(Tester oldTester, log_in_tester log_In)
        {
            InitializeComponent();
            log = log_In;
            tester = oldTester;
            bl = FactoryBL.GetBL();
            DataContext = tester;
            mat1 = tester.mat;
            imageNotWorking.Source = new BitmapImage(new Uri("C:/Users/OWNER/source/repos/SimchaPo/Project_5149_5835_dotNet5779/UI2/images/עובד לא.jpg"));
            notWorking.ImageSource = imageNotWorking.Source;
            imageWorking.Source = new BitmapImage(new Uri("C:/Users/OWNER/source/repos/SimchaPo/Project_5149_5835_dotNet5779/UI2/images/עובד.jpg"));
            working.ImageSource = imageWorking.Source;
            foreach (Button item in buttons.Children)
            {
                int x = int.Parse(item.Name[1].ToString());
                int y = int.Parse(item.Name[3].ToString());
                if (mat1[x, y] == true)
                {
                    item.Background = working;
                }
                if (mat1[x, y] == false)
                {
                    item.Background = notWorking;
                }
            }
            carTypeTesterComboBox.ItemsSource = Enum.GetValues(typeof(CarType));
            genderTesterComboBox.ItemsSource = Enum.GetValues(typeof(Gender));
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void next_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                tester.mat = mat1;
                bl.changeTester(tester);
                log.Close();
                Close();
                log_in_tester _log = new log_in_tester(tester);
                _log.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = new Button();
            button = sender as Button;
            int x = button.Name[1] - 48;
            int y = button.Name[3] - 48;
            if (mat1[x, y] == false)
            {
                mat1[x, y] = true;
                button.Background = working;
                return;
            }
            if (mat1[x, y] == true)
            {
                mat1[x, y] = false;
                button.Background = notWorking;
            }
        }
    }
}