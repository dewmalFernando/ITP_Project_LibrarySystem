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
    /// Interaction logic for CatalogueForUsers.xaml
    /// </summary>
    public partial class CatalogueForUsers : Page
    {
        //DBCatalogueTableDataContext dbCatalogueTableData = new DBCatalogueTableDataContext(Properties.Settings.Default.LibraryManagementSystemConnectionString);
        DBBookTableDataContext dbBookTableData = new DBBookTableDataContext(Properties.Settings.Default.LibraryManagementSystemConnectionString);
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-JJMIDS9\MSSQL;Initial Catalog=LibraryManagementSystem;Integrated Security=True");


        public CatalogueForUsers()
        {
            InitializeComponent();

            if (dbBookTableData.DatabaseExists())
                catalogueDataGrid.ItemsSource = dbBookTableData.Table_Books;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            NavigationService.Navigate(mainWindow);
        }

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
            catalogueDataGrid.ItemsSource = dataTable.DefaultView;

            sqlConnection.Close();
        }
    }
}
