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
        Checks checks;
        public MainWindow()
        {
            InitializeComponent();
            tester = new Tester();
            trainee = new Trainee();
            test = new Test();
            checks = new Checks();
            bl = FactoryBL.GetBL();
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
                if (userID.Text == "מספר זהות" || userFirstName.Text == "שם פרטי" || userLastName.Text == "שם משפחה") //missing detailes
                {
                    MessageBox.Show("אנא מלא את כל הפרטים", "שגיאה", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if(!Checks.checkID(userID.Text))
                {
                    MessageBox.Show("מספר זהות לא חוקי", "שגיאה", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (combo.SelectedIndex == 0)
                {
                    MessageBox.Show("אנא סמן את בחירתך", "שגיאה", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (combo.SelectedIndex == 1)
                {
                    log_in_tester log_in_tester = new log_in_tester(tester);
                    log_in_tester.ShowDialog();
                }
                if (combo.SelectedIndex == 2)
                {
                    log_in_trainee log_in_trainee = new log_in_trainee();
                    log_in_trainee.ShowDialog();
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
                    sign_in_tester sign_in_tester = new sign_in_tester();
                    sign_in_tester.ShowDialog();
                }
                if (combo.SelectedIndex == 2)
                {
                    sign_in_trainee sign_in_trainee = new sign_in_trainee();
                    sign_in_trainee.ShowDialog();
                }
            }
        }

        private void old_user_Unchecked(object sender, RoutedEventArgs e)
        {
            userFirstName.Text = "שם פרטי";
            userLastName.Text = userLastName.Text = "שם משפחה";
            userID.Text = "מספר זהות";
        }

        private void new_user_Unchecked(object sender, RoutedEventArgs e)
        {
            combo.SelectedIndex = 0;
        }

        private void userFirstName_MouseEnter(object sender, MouseEventArgs e)
        {
            if (userFirstName.Text == "שם פרטי")
                userFirstName.ClearValue(TextBox.TextProperty);
            else if (userFirstName.Text == "")
                userFirstName.Text = "שם פרטי";
        }

        private void userLastName_MouseEnter(object sender, MouseEventArgs e)
        {
            if (userLastName.Text == "שם משפחה")
                userLastName.ClearValue(TextBox.TextProperty);
            else if (userLastName.Text == "")
                userLastName.Text = "שם משפחה";
        }
    }
    
}
