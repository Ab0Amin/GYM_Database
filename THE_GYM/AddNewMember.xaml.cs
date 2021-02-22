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
using System.Data.SqlClient;
using System.Data;

namespace THE_GYM
{
    /// <summary>
    /// Interaction logic for AddNewMember.xaml
    /// </summary>
    public partial class AddNewMember : Window
    {
        public AddNewMember()
        {
            InitializeComponent();
            string[] name = { "1 month", "3 months", "6 monthes", "1 year" };
            DataContext = this;
        }

private void Button_Click(object sender, RoutedEventArgs e)
        {
            string Fname = tx_firstname.Text;
            string Sname = tx_secname.Text;
            string gender;
            if (checkmale.IsChecked==true)
            {
                gender = "male";
            }
            else
            {
                gender = "female";

            }
            string birth = dataofbirth.Text;
            string join = joindate.Text;
            string mobile = tx_mobile.Text;
            string email = tx_mail.Text;
            string adress = tx_adress.Text;
            string membershipDuration = membership.Text;
            try
            {
                if (mobile != "")
                {
                    SqlConnection con = new SqlConnection();
                    // con.ConnectionString = "data source =LAPTOP-GQQANM6K; database = the_gymD; integrated security = true";
                    con.ConnectionString = "data source =.; database = the_gymD; integrated security = true";

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "insert into NEW_CUSTMER (firstName,lastName,genger,dateOfBirth,mobile,email,joinDate,adress,membershipDuration) values " +
                        "('" + Fname + "','" + Sname + "','" + gender + "','" + birth + "','" + mobile + "','" + email + "','" + join + "','" + adress + "','" + membershipDuration + "')";
                    // firstName,lastName,genger,dateOfBirth,mobile,email,joinDate,adress,membershipDuration
                    SqlDataAdapter DA = new SqlDataAdapter(cmd);
                    DataSet DS = new DataSet();
                    DA.Fill(DS);
                    MessageBox.Show("DONE");
                }
                else
                {
                    MessageBox.Show("Please inter a valid mobile number","ERROR",MessageBoxButton.OK,MessageBoxImage.Error);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("this mobile number is aready exist","ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void bt_reset_Click(object sender, RoutedEventArgs e)
        {
             tx_firstname.Text="";
             tx_secname.Text = "";
            checkfemale.IsChecked = false;
            checkmale.IsChecked = false;
           dataofbirth.Text = "";
         joindate.Text = "";
            tx_mobile.Text = "";
            tx_mail.Text = "";
           tx_adress.Text = "";
         membership.Text = "";
        }
    }
}
