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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BE;
using BL;

namespace UI2
{
    /// <summary>
    /// Interaction logic for mat.xaml
    /// </summary>
    public partial class matrix : UserControl
    {
        public bool[,] mat1 { set; get; }
        ImageBrush notWorking = new ImageBrush();
        Image imageNotWorking = new Image();
        ImageBrush working = new ImageBrush();
        Image imageWorking = new Image();
        public matrix()
        {
            InitializeComponent();
            mat1 = new bool[5, 7] {
                { false, false, false, false, false, false, false },
                { false, false, false, false, false, false, false },
                { false, false, false, false, false, false, false },
                { false, false, false, false, false, false, false },
                { false, false, false, false, false, false, false } };

            imageNotWorking.Source = new BitmapImage(new Uri("C:/Users/OWNER/source/repos/SimchaPo/Project_5149_5835_dotNet5779/UI2/images/עובד לא.jpg"));
            notWorking.ImageSource = imageNotWorking.Source;
            imageWorking.Source = new BitmapImage(new Uri("C:/Users/OWNER/source/repos/SimchaPo/Project_5149_5835_dotNet5779/UI2/images/עובד.jpg"));
            working.ImageSource = imageWorking.Source;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Button button = new Button();
            button = sender as Button;
            int x = int.Parse(button.Name[1].ToString());
            int y = int.Parse(button.Name[3].ToString());
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
