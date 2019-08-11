using System;
using System.Collections.Generic;
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
    /// Interaction logic for BookDetailsManipulationPage.xaml
    /// </summary>
    public partial class BookDetailsManipulationPage : Page
    {
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

        // Use this code when you implement a SAVE button 
        //-->      <DB_object_Name>.SubmitChanges();   <--
    }
}
