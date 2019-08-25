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
    /// Interaction logic for BookDetailsManipulationPage.xaml
    /// </summary>
    public partial class BookDetailsManipulationPage : Page
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-JJMIDS9\MSSQL;Initial Catalog=LibraryManagementSystem;Integrated Security=True");
        DBBookTableDataContext dbBookTableData = new DBBookTableDataContext(Properties.Settings.Default.LibraryManagementSystemConnectionString);

        public BookDetailsManipulationPage()
        {
            InitializeComponent();

            if (dbBookTableData.DatabaseExists())
                bookDetailsManipulationDataGrid.ItemsSource = dbBookTableData.Table_Books;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            dbBookTableData.SubmitChanges();
        }

        private void UpdateBookButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteBookButton_Click(object sender, RoutedEventArgs e)
        {
            //DataAccess dataAccess = new DataAccess();
            //dataAccess.DeleteBook(int.Parse(DeteleBookTextBox.Text));

            //string connectionString = @"server=localhost;userid=user1;password=12345;database=mydb";
            
                /*string connectionString = @" Data Source = DESKTOP - JJMIDS9\MSSQL; Initial Catalog = LibraryManagementSystem; Integrated Security = True";
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "delete from Customers where ID='" + "1" + "';";
                cmd.ExecuteNonQuery();
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }*/


        }

        private void InsetBookButton_Click(object sender, RoutedEventArgs e)
        {
            BookDetailsEnteringPage bookDetailsEnteringPage = new BookDetailsEnteringPage();
            this.NavigationService.Navigate(bookDetailsEnteringPage);
        }
        

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            AdminPage adminPage = new AdminPage();
            NavigationService.Navigate(adminPage);
        }

        // Use this code when you implement a SAVE button 
        //-->      <DB_object_Name>.SubmitChanges();   <--

       

        private void SerachTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            sqlConnection.Open();
            SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT * FROM Book WHERE Title LIKE('" + SerachTextBox.Text + "%')";
            //cmd.CommandText = "SELECT * FROM Book WHERE Author LIKE('" + SerachTextBox.Text + "')";
            cmd.ExecuteNonQuery();
            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            sqlDataAdapter.Fill(dataTable);
            bookDetailsManipulationDataGrid.ItemsSource = dataTable.DefaultView;

            sqlConnection.Close();
        }
    }
}
