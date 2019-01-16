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
    /// Interaction logic for create_a_test.xaml
    /// </summary>
    public partial class create_a_test : Window
    {
        Tester tester;
        Trainee trainee;
        IBL bl;
       // DateTime date = new DateTime();
        List<Tester> testers = new List<Tester>();
        public create_a_test(Trainee trainee6)
        {
            InitializeComponent();
            tester = new Tester();
            bl = FactoryBL.GetBL();
            trainee = trainee6;
            DataContext = trainee;
            testers.AddRange(bl.getTesters());
        }
    }
}
