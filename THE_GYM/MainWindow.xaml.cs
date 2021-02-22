using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Collections;
//using System.Windows.Forms;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;


namespace THE_GYM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            InitializeComponent();
            
        }
       
        private void bt_newMember_Click(object sender, RoutedEventArgs e)
        {
           
            AddNewMember newMember =new  AddNewMember();
            newMember.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new_stuff newMember = new new_stuff();
            newMember.Show();
        }

        private void bt_exit_click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to close the application","CLOSE",MessageBoxButton.YesNo,MessageBoxImage.Warning)== MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();

            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            search sc = new search();
            sc.Show();
        }

        
        private void expired_Click(object sender, RoutedEventArgs e)
        {
            ArrayList endedMembersRows = new ArrayList();
            DataTable finalTable = new DataTable();
            SqlConnection con = new SqlConnection("data source =.; database = the_gymD; integrated security = true");

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
           

            cmd.CommandText = "select * from MembersDetails ";

            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataTable DS = new DataTable();
            DA.Fill(DS);
            // grdSearchMembers.ItemsSource = DS.DefaultView;
            DataRow[] dt = DS.Select();
            foreach (DataRow row in dt)
            {
                int index_joinDate=    row.Table.Columns.IndexOf("Join Date");
                int index_Duration = row.Table.Columns.IndexOf("Duration");
                int duration=0;
                string durationString = (string)row[index_Duration];
                if (durationString== "1 month")
                {
                    duration = 1;
                }
                else if (durationString == "3 months")
                {
                    duration = 3;
                }
                else if (durationString == "6 months")
                {
                    duration = 6;
                }
                else if (durationString == "1 year")
                {
                    duration = 12;
                }
                DateTime joinDate = Convert.ToDateTime(row[index_joinDate]);
                DateTime EndDate = joinDate.AddMonths(duration);
                TimeSpan isEnd= EndDate.Subtract(DateTime.Now);
              //  RowDefinition rowDefinition = row;
                if (isEnd.Days<0)
                {
                    endedMembersRows.Add((string)row[4]);
                }
            }
            string SendNumbersSql = "select * from MembersDetails where [Mobile NO] in ()  ";
            foreach (string item in endedMembersRows)
            {
                int x = SendNumbersSql.IndexOf(')');
                SendNumbersSql= SendNumbersSql.Replace(')',' ');
                if (x==51)
                {
                    SendNumbersSql = SendNumbersSql.Insert(x, item + ")");
                }
                else
                {
                    SendNumbersSql = SendNumbersSql.Insert(x, "," + item + ")");
                }
              
                
            }
            cmd.CommandText = SendNumbersSql;
            SqlDataAdapter DAa = new SqlDataAdapter(cmd);
                DataTable DSs = new DataTable();
                DAa.Fill(DSs);
            expideredMemberWindow exp_w = new expideredMemberWindow();
            // DataTable table = finalTable;
             exp_w.ex_grdSearchMembers.ItemsSource= DSs.DefaultView;
          
           
            exp_w.Show();
           

            // firstName,[Last Name],genger,dateOfBirth,mobile,email,joinDate,adress,membershipDuration
            //try
            //{
            //    SqlDataAdapter DA = new SqlDataAdapter(cmd);
            //    DataTable DS = new DataTable();
            //    DA.Fill(DS);
            //   // grdSearchMembers.ItemsSource = DS.DefaultView;
            //    DataRow[] dt = DS.Select();


            //}
            //catch (Exception)
            //{

            //    MessageBox.Show("no data fouded");

            //}
        }

        private void bt_logout_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to logout", "Logout", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                loginWindow log = new loginWindow();
                log.Show();
                this.Close();
                

            }
        }

        
    }
}
