using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace THE_GYM
{
    /// <summary>
    /// Interaction logic for loginWindow.xaml
    /// </summary>
    public partial class loginWindow : Window
    {
        public loginWindow()
        {
            InitializeComponent();
        }

      

        private void bt_login_Click(object sender, RoutedEventArgs e)
        {
            if (tx_username.Text=="amin" && tx_pass.Password=="amin")
            {
                MainWindow main = new MainWindow();
                main.Show();
                this.Close();

            }
            else
            {
                MessageBox.Show("Please inter a valid username or password");
            }
        }
    }
}
