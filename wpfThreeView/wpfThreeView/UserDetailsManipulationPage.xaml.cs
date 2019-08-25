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
using wpfThreeView.DBTables;

namespace wpfThreeView
{
    /// <summary>
    /// Interaction logic for UserDetailsManipulationPage.xaml
    /// </summary>
    public partial class UserDetailsManipulationPage : Page
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-JJMIDS9\MSSQL;Initial Catalog=LibraryManagementSystem;Integrated Security=True");

        DB_MemberTableDataContext dB_MemberTable = new DB_MemberTableDataContext(Properties.Settings.Default.LibraryManagementSystemConnectionString);

        public UserDetailsManipulationPage()
        {
            InitializeComponent();

            if (dB_MemberTable.DatabaseExists())
                userDetailsManipulationDataGrid.ItemsSource = dB_MemberTable.Table_Members;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            AdminPage adminPage = new AdminPage();
            NavigationService.Navigate(adminPage);
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            dB_MemberTable.SubmitChanges();
        }

        private void SerachTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            //Open sql connection
            sqlConnection.Open();
            //Create a new sql command
            SqlCommand cmd = sqlConnection.CreateCommand();
            //Define command type
            cmd.CommandType = System.Data.CommandType.Text;
            //Sql query for select enterd data from database
            cmd.CommandText = "SELECT * FROM Book WHERE Title LIKE('" + SerachTextBox.Text + "%')";
            //cmd.CommandText = "SELECT * FROM Book WHERE Author LIKE('" + SerachTextBox.Text + "')";
            //Execute sql command
            cmd.ExecuteNonQuery();
            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            sqlDataAdapter.Fill(dataTable);
            userDetailsManipulationDataGrid.ItemsSource = dataTable.DefaultView;
            //close sql connection
            sqlConnection.Close();
        }

        private void DeleteBookButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
