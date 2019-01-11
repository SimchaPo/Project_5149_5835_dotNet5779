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
        public bool?[,] mat1 { set; get; }
        public matrix()
        {
            InitializeComponent();
            mat1 = new bool?[5, 7] { {null , null, null, null, null, null, null },
                {null , null, null, null, null, null, null },
                {null , null, null, null, null, null, null },
                {null , null, null, null, null, null, null },
               {null , null, null, null, null, null, null } };
        }

        public matrix(Tester tester)
        {
            InitializeComponent();
            mat1 = tester.mat;
            for(int x = 0; x < 5; ++x)
            {
                for(int y = 0; y < 7; ++y)
                {
                    Button button = getName(x, y);
                    button.Background = Brushes.Black;
                }
            }
        }
            /* private static SolidColorBrush brushes(object sender)
             {

                     Button button = new Button();
                     button = sender as Button;
                     int x = button.Name[1] - 48;
                     int y = button.Name[3] - 48;
                     if (mat1[x, y] == true)
                     {
                         return Brushes.Green;
                     }
                     return Brushes.Red;
                 }
             }*/
            private void Button_Click(object sender, RoutedEventArgs e)
        {

            Button button = new Button();
            button = sender as Button;
            int x = button.Name[1] - 48;
            int y = button.Name[3] - 48;
            if (mat1[x, y] != true)
            {
                mat1[x, y] = true;
                button.Background = Brushes.Green;
                return;
            }
            if (mat1[x, y] == true)
            {
                mat1[x, y] = false;
                button.Background = Brushes.Red;
            }
        }
        private Button getName(int x, int y)
        {
            Button button = new Button();
            button.Name = 'b' + x.ToString() + '_' + y.ToString();
            return button;
        }
    }
}
