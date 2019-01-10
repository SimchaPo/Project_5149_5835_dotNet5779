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
    }
}
