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
using wpfThreeView.Classes;

namespace wpfThreeView
{
    /// <summary>
    /// Interaction logic for UserRegistrationPage.xaml
    /// </summary>
    public partial class UserRegistrationPage : Page
    {
        public UserRegistrationPage()
        {
            InitializeComponent();

        }

        private void RegistrationCancelButton_Click(object sender, RoutedEventArgs e)
        {
           // this.NavigationService.Refresh();
        }

        private void RegistrationConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            DataAccess dataAccess = new DataAccess();

            dataAccess.InsertMember(FirstNameTextBox.Text, LastNameTextBox.Text, int.Parse(AgeTextBox.Text), char.Parse(GenderComboBox.Text),
                UserTypeComboBox.Text, MailTextBox.Text);
        }
    }
}
