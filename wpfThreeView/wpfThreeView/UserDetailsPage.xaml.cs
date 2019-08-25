namespace wpfThreeView
{
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Navigation;
    using wpfThreeView.Classes;
    using wpfThreeView.DBTables;

    /// <summary>
    /// Interaction logic for UserDetailsPage.xaml
    /// </summary>
    public partial class UserDetailsPage : Page
    {
        /// <summary>
        /// Defines the con
        /// </summary>
        internal SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-JJMIDS9\MSSQL;Initial Catalog=LibraryManagementSystem;Integrated Security=True");

        /// <summary>
        /// Defines the dbMemberTableDataContext
        /// </summary>
        internal DB_MemberTableDataContext dbMemberTableDataContext = new DB_MemberTableDataContext(Properties.Settings.Default.LibraryManagementSystemConnectionString);

        /// <summary>
        /// Defines the member
        /// </summary>
        internal List<Member> member = new List<Member>();

        /// <summary>
        /// Initializes a new instance of the <see cref="UserDetailsPage"/> class.
        /// </summary>
        public UserDetailsPage()
        {
            InitializeComponent();

            if (dbMemberTableDataContext.DatabaseExists())
                userDetailsDataGrid.ItemsSource = dbMemberTableDataContext.Table_Members;
        }

        /// <summary>
        /// The SearchMemberButton_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="RoutedEventArgs"/></param>
        private void SearchMemberButton_Click(object sender, RoutedEventArgs e)
        {
            //DataAccess dataAccess = new DataAccess();

            //member = dataAccess.GetMember(int.Parse(SerachMemberTextBox.Text));
            //userDetailsDataGrid = "FullInfo";

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT * FROM Member WHERE Member_ID LIKE('" + SerachMemberTextBox.Text + "%')";
            cmd.ExecuteNonQuery();
            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            sqlDataAdapter.Fill(dataTable);
            userDetailsDataGrid.ItemsSource = dataTable.DefaultView;

            con.Close();
        }

        /// <summary>
        /// The BackButton_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="RoutedEventArgs"/></param>
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            AdminPage adminPage = new AdminPage();
            NavigationService.Navigate(adminPage);
        }
    }
}
