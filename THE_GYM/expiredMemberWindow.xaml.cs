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
    /// Interaction logic for expideredMemberWindow.xaml
    /// </summary>
    public partial class expideredMemberWindow : Window
    {

        private void updateMember(object sender, RoutedEventArgs e)
        {

            sender = ex_grdSearchMembers.SelectedItem;
            if (sender != null)
            {
                DataRowView selectedRow = (DataRowView)ex_grdSearchMembers.SelectedItem;

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
                sender = ex_grdSearchMembers.SelectedItem;
                if (sender != null)
                {
                    DataRowView selectedRow = (DataRowView)ex_grdSearchMembers.SelectedItem;
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
                        ex_grdSearchMembers.ItemsSource = DS2.DefaultView;




                    }
                    catch (Exception)
                    {

                        MessageBox.Show("invalid selection");

                    }
                }

            }


           

        }
        public expideredMemberWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
        
        }
        private void test(object sender, RoutedEventArgs e)
        {


            {
               {
                  //  DataRowView selectedRow = (DataRowView)ex_grdSearchMembers.SelectedItem;
                 //   int index_mobile = selectedRow.Row.Table.Columns.IndexOf("Mobile NO");
                  //  Object[] row = selectedRow.Row.ItemArray;
                  //  string mobileNummbere = (string)row[index_mobile];
                    SqlConnection con = new SqlConnection("data source =.; database = the_gymD; integrated security = true");
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                 //   cmd.CommandText = "delete from NEW_CUSTMER where mobile ='" + mobileNummbere + "'";
                    try
                    {
                      //  SqlDataAdapter DA = new SqlDataAdapter(cmd);
                       // DataTable DS = new DataTable();
                        //DA.Fill(DS);

                        cmd.CommandText = "select * from MembersDetails ";

                        SqlDataAdapter DA2 = new SqlDataAdapter(cmd);
                        DataTable DS2 = new DataTable();
                        DA2.Fill(DS2);
                        ex_grdSearchMembers.ItemsSource = DS2.DefaultView;




                    }
                    catch (Exception)
                    {

                        MessageBox.Show("invalid selection");

                    }
                }

            }




        }


    }
}
