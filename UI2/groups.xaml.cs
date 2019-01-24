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
    /// Interaction logic for groups.xaml
    /// </summary>
    public partial class groups : Window
    {
        IBL bl;
        public groups()
        {
            InitializeComponent();
            bl = FactoryBL.GetBL();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
