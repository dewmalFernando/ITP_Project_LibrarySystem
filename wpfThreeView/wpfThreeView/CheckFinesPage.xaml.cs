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
    /// Interaction logic for CheckFinesPage.xaml
    /// </summary>
    public partial class CheckFinesPage : Page
    {

        DB_FinesTableDataContext dbFinesTableDataContext = new DB_FinesTableDataContext(Properties.Settings.Default.LibraryManagementSystemConnectionString);

        public CheckFinesPage()
        {
            InitializeComponent();

            if (dbFinesTableDataContext.DatabaseExists())
                checkFinesDataGrid.ItemsSource = dbFinesTableDataContext.Table_Fines;
        }
    }
}
