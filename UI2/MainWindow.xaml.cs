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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            bool data1 = (bool)old_user.IsChecked || (bool)new_user.IsChecked;
            stack.DataContext = data1;
        }
        private void userName_MouseEnter(object sender, MouseEventArgs e)
        {
            if (userName.Text == "שם")
                userName.Text = "";
            else if (userName.Text == "")
                userName.Text = "שם";

        }

        private void userID_MouseEnter(object sender, MouseEventArgs e)
        {
            if (userID.Text == "מספר זהות")
                userID.Text = "";
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
                window2 window2 = new window2();
                window2.ShowDialog();
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
                    window3 window3 = new window3();
                    window3.ShowDialog();
                }
                if (combo.SelectedIndex == 2)
                {
                    window4 window4 = new window4();
                    window4.ShowDialog();
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
