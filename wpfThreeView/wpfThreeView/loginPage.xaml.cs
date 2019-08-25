namespace wpfThreeView
{
    using System;
    using System.Data.SqlClient;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Navigation;

    /// <summary>
    /// Interaction logic for loginPage.xaml
    /// </summary>
    public partial class loginPage : Page
    {
        /// <summary>
        /// SQL Connection String
        /// </summary>
        internal SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-JJMIDS9\MSSQL;Initial Catalog=LibraryManagementSystem;Integrated Security=True");

        /// <summary>
        /// Initializes a new instance of the <see cref="loginPage"/> class.
        /// </summary>
        public loginPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Admin login
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Findout wheather the sql connection is open or close
                if (sqlConnection.State == System.Data.ConnectionState.Closed) sqlConnection.Open();

                //Query for select Username and Password from database
                String query = "SELECT COUNT(1) FROM AdminLogin WHERE UserName = @UserName AND Password = @Password";

                //Create a new sql command
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                //Define the type of sql command
                sqlCommand.CommandType = System.Data.CommandType.Text;

                //Parse the value from the userName text box to database and Retreve the specific value for Username
                sqlCommand.Parameters.AddWithValue("@UserName", userNameTextBox.Text);

                //Parse the value from the password text box to database and Retreve the specific value for Password
                sqlCommand.Parameters.AddWithValue("@Password", passwordTextBox.Password);

                int count = Convert.ToInt32(sqlCommand.ExecuteScalar());

                //Check wheather the enterd values and stored values are same
                if (count == 1)
                {
                    AdminPage adminPage = new AdminPage();
                    NavigationService.Navigate(adminPage);
                }
                else
                {
                    //If the values are not the same, Display a message
                    MessageBox.Show("Username or password is incorrect");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// The BackButton_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="RoutedEventArgs"/></param>
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
        }

        /// <summary>
        /// Navigate to admin register page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateAccountLink_Click(object sender, RoutedEventArgs e)
        {

            UserRegistrationPage userRegistrationPage = new UserRegistrationPage();
            this.NavigationService.Navigate(userRegistrationPage);
        }
    }
}
