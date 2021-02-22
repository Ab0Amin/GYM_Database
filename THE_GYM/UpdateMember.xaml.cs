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
using System.Data;
using System.Data.SqlClient;


namespace THE_GYM
{
    /// <summary>
    /// Interaction logic for UpdateMember.xaml
    /// </summary>
    public partial class UpdateMember : Window
    {
       
        
        public UpdateMember()
        {

            InitializeComponent();
        }


        string mobile_key;
       

        private void bt_update_Click(object sender, RoutedEventArgs e)
        {
            string gender;
            if (ucheckmale.IsChecked==true)
            {
                gender = "male";
            }
            else
            {
                gender = "female";
            }
            SqlConnection con = new SqlConnection();
            // con.ConnectionString = "data source =LAPTOP-GQQANM6K; database = the_gymD; integrated security = true";
            con.ConnectionString = "data source =.; database = the_gymD; integrated security = true";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "update  NEW_CUSTMER set firstName = '" + utx_firstname.Text + "',lastName = '"+ utx_secname.Text + "',genger='"+ gender + "',dateOfBirth='"+ udataofbirth.Text + "',mobile='"+ utx_mobile.Text + "',email ='" + utx_mail.Text + "',joinDate='" + ujoindate.Text + "',adress='" + utx_adress.Text + "',membershipDuration='" + umembership.Text + "'  where mobile = '"+ mobile_key + "' ";
            // firstName,lastName,genger,dateOfBirth,mobile,email,joinDate,adress,membershipDuration
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            DA.Fill(DS);
            MessageBox.Show("DONE");
        }

        private void UpdateMemberwindow_Initialized(object sender, EventArgs e)
        {
         //   mobile_key = utx_mobile.Text;
        }

        private void UpdateMemberwindow_Loaded(object sender, RoutedEventArgs e)
        {
            mobile_key = utx_mobile.Text;
        }
    }
}
