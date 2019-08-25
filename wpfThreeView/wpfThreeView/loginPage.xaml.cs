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
        
        public loginPage()
        {
            InitializeComponent();
            
        }

        

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {

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
