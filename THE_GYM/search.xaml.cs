using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Collections;

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
    /// Interaction logic for search.xaml
    /// </summary>
    public partial class search : Window
    {
    
        public  string U_FName;
        public string U_LName;
        public string U_mobile;
        public string U_gender;
        public string U_dateOfBirth;
        public string U_joinDate;
        public string U_duration;
        public string U_adress;
        public string U_email;

     

        public search()
        {
           
            InitializeComponent();
        }


         DataRow[] currenRows;
       
        private void updateMember(object sender, RoutedEventArgs e)
        {

            sender = grdSearchMembers.SelectedItem;
            if (sender != null)
            {
                DataRowView selectedRow = (DataRowView)grdSearchMembers.SelectedItem;

                int index_Fname = selectedRow.Row.Table.Columns.IndexOf("First Name");
                int index_Lname = selectedRow.Row.Table.Columns.IndexOf("Last Name");
                int index_gender = selectedRow.Row.Table.Columns.IndexOf("Gender");
                int index_mobile = selectedRow.Row.Table.Columns.IndexOf("Mobile NO");
                int index_joinDate = selectedRow.Row.Table.Columns.IndexOf("Join Date");
                int index_adress = selectedRow.Row.Table.Columns.IndexOf("adress");
                int index_Duration = selectedRow.Row.Table.Columns.IndexOf("Duration");
                int index_email = selectedRow.Row.Table.Columns.IndexOf("email");
                int index_dataOfBirth = selectedRow.Row.Table.Columns.IndexOf("Date of Birth");

                Object[] row = selectedRow.Row.ItemArray;
                //update
                UpdateMember up = new UpdateMember();
                up.utx_firstname.Text = (string)row[index_Fname];
                up.utx_secname.Text = (string)row[index_Lname];
                if ((string)row[index_gender] == "male")
                {
                    up.ucheckmale.IsChecked = true;
                }
                else if ((string)row[index_gender] == "female")
                {
                    up.ucheckfemale.IsChecked = true;
                }
                up.utx_mobile.Text = (string)row[index_mobile];
                up.utx_adress.Text = (string)row[index_adress];
                up.utx_mail.Text = (string)row[index_email];
                try
                {
                    up.ujoindate.SelectedDate = Convert.ToDateTime(row[index_joinDate]);
                }
                catch (Exception)
                {
                }
                try
                {
                    up.udataofbirth.SelectedDate = Convert.ToDateTime(row[index_dataOfBirth]);
                }
                catch (Exception)
                {
                }
                if (row[index_Duration] != null) up.umembership.Text = (string)row[index_Duration];
                up.Show();
                this.Close();
            }
        }


        private void removeMember(object sender, RoutedEventArgs e)
        {


            if (MessageBox.Show("Are you sure you want to delete this member", "DELETE", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                sender = grdSearchMembers.SelectedItem;
                if (sender != null)
                {
                    DataRowView selectedRow = (DataRowView)grdSearchMembers.SelectedItem;
                    int index_mobile = selectedRow.Row.Table.Columns.IndexOf("Mobile NO");
                    Object[] row = selectedRow.Row.ItemArray;
                    string mobileNummbere = (string)row[index_mobile];
                    SqlConnection con = new SqlConnection("data source =.; database = the_gymD; integrated security = true");
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "delete from NEW_CUSTMER where mobile ='" + mobileNummbere + "'";
                    try
                    {
                        SqlDataAdapter DA = new SqlDataAdapter(cmd);
                        DataTable DS = new DataTable();
                        DA.Fill(DS);

                        cmd.CommandText = "select * from MembersDetails ";

                        SqlDataAdapter DA2 = new SqlDataAdapter(cmd);
                        DataTable DS2 = new DataTable();
                        DA2.Fill(DS2);
                        grdSearchMembers.ItemsSource = DS2.DefaultView;




                    }
                    catch (Exception)
                    {

                        MessageBox.Show("invalid selection");

                    }
                }

            }
           
                

            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string Fname = tx_firstname.Text;
            string Sname = tx_secname.Text;
            string mobile = tx_mobile.Text;


            SqlConnection con = new SqlConnection("data source =.; database = the_gymD; integrated security = true");
           
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            #region search conditions
            if (tx_firstname.Text != "" && tx_secname.Text == "" && tx_mobile.Text == "")
            {
                cmd.CommandText = "select * from MembersDetails where [First Name] ='" + tx_firstname.Text + "'";
            }
            else if (tx_firstname.Text == "" && tx_secname.Text != "" && tx_mobile.Text == "")
            {
                cmd.CommandText = "select * from MembersDetails where [Last Name] ='" + tx_secname.Text + "'";
            }
            else if (tx_firstname.Text == "" && tx_secname.Text == "" && tx_mobile.Text != "")
            {
                cmd.CommandText = "select * from MembersDetails where [Mobile N.O] ='" + tx_mobile.Text + "'";
            }
            else if (tx_firstname.Text != "" && tx_secname.Text != "" && tx_mobile.Text == "")
            {
                cmd.CommandText = "select * from MembersDetails where [First Name] ='" + tx_firstname.Text + "' and [Last Name] = '" + tx_secname.Text + "'"; 
            }
            else if (tx_firstname.Text != "" && tx_secname.Text == "" && tx_mobile.Text != "")
            {
                cmd.CommandText = "select * from MembersDetails where [First Name] ='" + tx_firstname.Text + "' and [Mobile N.O] = '" + tx_mobile.Text + "'";
            }
            else if (tx_firstname.Text == "" && tx_secname.Text != "" && tx_mobile.Text != "")
            {
                cmd.CommandText = "select * from MembersDetails where [Last Name] ='" + tx_secname.Text + "' and [Mobile N.O] = '" + tx_mobile.Text + "'";
            }
            else if (tx_firstname.Text != "" && tx_secname.Text != "" && tx_mobile.Text != "")
            {
                cmd.CommandText = "select * from MembersDetails where [Last Name] ='" + tx_secname.Text + "' and [Mobile N.O] = '" + tx_mobile.Text + "' and [First Name] ='" + tx_firstname.Text +"'" ;
            }
            #endregion

            // firstName,[Last Name],genger,dateOfBirth,mobile,email,joinDate,adress,membershipDuration
            try
            {
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataTable DS = new DataTable();
                DA.Fill(DS);
                grdSearchMembers.ItemsSource = DS.DefaultView;
                DataRow[] dt = DS.Select();
               
            currenRows = dt;
           
            }
            catch (Exception)
            {

                MessageBox.Show("Please inter a valid name or mobile number");

            }

        }









        private void showAll_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection("data source =.; database = the_gymD; integrated security = true");

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            #region search conditions
           
            
                cmd.CommandText = "select * from MembersDetails ";
            
            
            #endregion

            // firstName,[Last Name],genger,dateOfBirth,mobile,email,joinDate,adress,membershipDuration
            try
            {
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataTable DS = new DataTable();
                DA.Fill(DS);
                grdSearchMembers.ItemsSource = DS.DefaultView;
                DataRow[] dt = DS.Select();
                currenRows = dt;

            }
            catch (Exception)
            {

                MessageBox.Show("no data fouded");

            }
        }
    }
}
