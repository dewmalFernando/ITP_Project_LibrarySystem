using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using wpfThreeView.Classes;
using wpfThreeView.DBTables;

namespace wpfThreeView
{
    /// <summary>
    /// Interaction logic for UserDetailsPage.xaml
    /// </summary>
    public partial class UserDetailsPage : Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-JJMIDS9\MSSQL;Initial Catalog=LibraryManagementSystem;Integrated Security=True");

        DB_MemberTableDataContext dbMemberTableDataContext = new DB_MemberTableDataContext(Properties.Settings.Default.LibraryManagementSystemConnectionString);
        List<Member> member = new List<Member>();

        public UserDetailsPage()
        {
            InitializeComponent();
            
            if (dbMemberTableDataContext.DatabaseExists())
                userDetailsDataGrid.ItemsSource = dbMemberTableDataContext.Table_Members;
        }

        private void SearchMemberButton_Click(object sender, RoutedEventArgs e)
        {
            //DataAccess dataAccess = new DataAccess();

            //member = dataAccess.GetMember(int.Parse(SerachMemberTextBox.Text));
            //userDetailsDataGrid = "FullInfo";

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT * FROM Member WHERE Member_ID LIKE('" + SerachMemberTextBox.Text+ "%')";
            cmd.ExecuteNonQuery();
            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            sqlDataAdapter.Fill(dataTable);
            userDetailsDataGrid.ItemsSource = dataTable.DefaultView;

            con.Close();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            AdminPage adminPage = new AdminPage();
            NavigationService.Navigate(adminPage);
        }
    }
}
