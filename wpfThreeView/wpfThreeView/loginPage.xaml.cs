using System;
using System.Collections.Generic;
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


namespace wpfThreeView
{
    /// <summary>
    /// Interaction logic for loginPage.xaml
    /// </summary>
    public partial class loginPage : Page
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-JJMIDS9\MSSQL;Initial Catalog=LibraryManagementSystem;Integrated Security=True");

        public loginPage()
        {
            InitializeComponent();
            
        }

        

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sqlConnection.State == System.Data.ConnectionState.Closed) sqlConnection.Open();
                String query = "SELECT COUNT(1) FROM AdminLogin WHERE UserName = @UserName AND Password = @Password";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@UserName", userNameTextBox.Text);
                sqlCommand.Parameters.AddWithValue("@Password", passwordTextBox.Password);

                int count = Convert.ToInt32(sqlCommand.ExecuteScalar());

                if(count == 1)
                {
                    AdminPage adminPage = new AdminPage();
                    NavigationService.Navigate(adminPage);
                }
                else
                {
                    MessageBox.Show("Username or password is incorrect");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

      
        private void CreateAccountLink_Click(object sender, RoutedEventArgs e)
        {

            UserRegistrationPage userRegistrationPage = new UserRegistrationPage();
            this.NavigationService.Navigate(userRegistrationPage);
        }

       
    }
}
