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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Tester tester;
        Trainee trainee;
        Test test;
        IBL bl;
        public MainWindow()
        {
            InitializeComponent();
            tester = new Tester();
            trainee = new Trainee();
            test = new Test();
            bl = FactoryBL.GetBL();
        }
        private void userName_MouseEnter(object sender, MouseEventArgs e)
        {
            if (userName.Text == "שם")
                userName.ClearValue(TextBox.TextProperty);
            else if (userName.Text == "")
                userName.Text = "שם";

        }

        private void userID_MouseEnter(object sender, MouseEventArgs e)
        {
            if (userID.Text == "מספר זהות")
                userID.ClearValue(TextBox.TextProperty);
            else if (userID.Text == "")
                userID.Text = "מספר זהות";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)old_user.IsChecked)
            {
                if (userID.Text == "מספר זהות" || userName.Text == "שם")
                {
                    MessageBox.Show("אנא מלא את כל הפרטים", "שגיאה", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (combo.SelectedIndex == 0)
                {
                    MessageBox.Show("אנא סמן את בחירתך", "שגיאה", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (combo.SelectedIndex == 1)
                {
                    Conect_old_tester conect_old_tester = new Conect_old_tester();
                    conect_old_tester.ShowDialog();
                }
                if (combo.SelectedIndex == 2)
                {
                    Conect_old_trainee conect_old_trainee = new Conect_old_trainee();
                    conect_old_trainee.ShowDialog();
                }
            }
            if ((bool)new_user.IsChecked)
            {
                if (combo.SelectedIndex == 0)
                {
                    MessageBox.Show("אנא סמן את בחירתך", "שגיאה", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (combo.SelectedIndex == 1)
                {
                    New_tester new_tester = new New_tester();
                    new_tester.ShowDialog();
                }
                if (combo.SelectedIndex == 2)
                {
                    New_trainee new_trainee = new New_trainee();
                    new_trainee.ShowDialog();
                }
            }
        }

        private void old_user_Unchecked(object sender, RoutedEventArgs e)
        {
            userName.Text = "שם";
            userID.Text = "מספר זהות";
        }

        private void new_user_Unchecked(object sender, RoutedEventArgs e)
        {
            combo.SelectedIndex = 0;
        }
    }
    
}
