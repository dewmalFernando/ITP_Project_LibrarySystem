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
using wpfThreeView.Classes;
using wpfThreeView.DBTables;

namespace wpfThreeView
{
    /// <summary>
    /// Interaction logic for UserDetailsPage.xaml
    /// </summary>
    public partial class UserDetailsPage : Page
    {

        DB_MemberTableDataContext dbMemberTableDataContext = new DB_MemberTableDataContext(Properties.Settings.Default.LibraryManagementSystemConnectionString);
        //List<Member> member = new List<Member>();

        public UserDetailsPage()
        {
            InitializeComponent();

           

            if (dbMemberTableDataContext.DatabaseExists())
                userDetailsDataGrid.ItemsSource = dbMemberTableDataContext.Table_Members;
        }

        private void SearchMemberButton_Click(object sender, RoutedEventArgs e)
        {
            //DataAccess dataAccess = new DataAccess();

            //member = dataAccess.GetMember(SerachMemberTextBox.Text);
            //userDetailsDataGrid.DisplayMemberPath = "FullInfo";
        }
    }
}
