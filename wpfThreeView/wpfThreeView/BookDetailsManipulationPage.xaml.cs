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
        /// <summary>
        /// SQL Connection String
        /// </summary>
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-JJMIDS9\MSSQL;Initial Catalog=LibraryManagementSystem;Integrated Security=True");

        /// <summary>
        /// SQL Connection String( another way of doing)
        /// </summary>
        DBBookTableDataContext dbBookTableData = new DBBookTableDataContext(Properties.Settings.Default.LibraryManagementSystemConnectionString);

        public BookDetailsManipulationPage()
        {
            InitializeComponent();

            //Data is showing because of this
            if (dbBookTableData.DatabaseExists())
                bookDetailsManipulationDataGrid.ItemsSource = dbBookTableData.Table_Books;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            //Save updated data
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

        /// <summary>
        /// Navigate where admin can enter a new book
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InsetBookButton_Click(object sender, RoutedEventArgs e)
        {
            BookDetailsEnteringPage bookDetailsEnteringPage = new BookDetailsEnteringPage();
            this.NavigationService.Navigate(bookDetailsEnteringPage);
        }
        
        /// <summary>
        /// Navigate to previous page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            AdminPage adminPage = new AdminPage();
            NavigationService.Navigate(adminPage);
        }

        // Use this code when you implement a SAVE button 
        //-->      <DB_object_Name>.SubmitChanges();   <--

       
        /// <summary>
        /// Preform search function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            bookDetailsManipulationDataGrid.ItemsSource = dataTable.DefaultView;
            //close sql connection
            sqlConnection.Close();
        }
    }
}
