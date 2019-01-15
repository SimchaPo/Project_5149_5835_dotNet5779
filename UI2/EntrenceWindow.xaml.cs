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

        private void userID_MouseEnter(object sender, MouseEventArgs e)
        {
            if (userID.Text == "מספר זהות")
                userID.ClearValue(TextBox.TextProperty);
            else if (userID.Text == "")
                userID.Text = "מספר זהות";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((bool)old_user.IsChecked)
                {
                    if (userID.Text == "מספר זהות" || userFirstName.Text == "שם פרטי" || userLastName.Text == "שם משפחה") //missing detailes
                    {
                        throw new Exception("אנא מלא את כל הפרטים");
                    }
                    if (!Checks.checkID(userID.Text))
                    {
                        throw new Exception("מספר זהות לא חוקי");
                    }
                    if (combo.SelectedIndex == 0)
                    {
                        throw new Exception("אנא סמן את בחירתך");
                    }
                    if (combo.SelectedIndex == 1)
                    {
                        tester = bl.GetTester(userID.Text);
                        log_in_tester log_in_tester = new log_in_tester(tester);
                        Close();
                        log_in_tester.Show();
                    }
                    if (combo.SelectedIndex == 2)
                    {
                        trainee = bl.GetTrainee(userID.Text);
                        log_in_trainee log_in_trainee = new log_in_trainee(trainee);
                        Close();
                        log_in_trainee.Show();
                    }
                }
                if ((bool)new_user.IsChecked)
                {
                    if (combo.SelectedIndex == 0)
                    {
                        throw new Exception("אנא סמן את בחירתך");
                    }
                    if (combo.SelectedIndex == 1)
                    {
                        Close();
                        sign_in_tester sign_in_tester = new sign_in_tester();
                        sign_in_tester.Show();
                    }
                    if (combo.SelectedIndex == 2)
                    {
                        Close();
                        sign_in_trainee sign_in_trainee = new sign_in_trainee();
                        sign_in_trainee.Show();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "שגיאה", MessageBoxButton.OK, MessageBoxImage.Error);

            }
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

        private void old_user_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton button = sender as RadioButton;
            if ((bool)button.IsChecked)
            {
                old_user_detailes.Visibility = Visibility.Visible;
            }
            else
            {
                userFirstName.Text = "שם פרטי";
                userLastName.Text = userLastName.Text = "שם משפחה";
                userID.Text = "מספר זהות";
                old_user_detailes.Visibility = Visibility.Collapsed;
            }
        }
    }
    
}
