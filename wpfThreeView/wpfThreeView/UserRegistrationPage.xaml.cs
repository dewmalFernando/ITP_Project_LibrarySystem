namespace wpfThreeView
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Navigation;
    using wpfThreeView.Classes;

    /// <summary>
    /// Interaction logic for UserRegistrationPage.xaml
    /// </summary>
    public partial class UserRegistrationPage : Page
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserRegistrationPage"/> class.
        /// </summary>
        public UserRegistrationPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The RegistrationCancelButton_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="RoutedEventArgs"/></param>
        private void RegistrationCancelButton_Click(object sender, RoutedEventArgs e)
        {
            AdminPage adminPage = new AdminPage();
            NavigationService.Navigate(adminPage);
        }

        /// <summary>
        /// The RegistrationConfirmButton_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="RoutedEventArgs"/></param>
        private void RegistrationConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            DataAccess dataAccess = new DataAccess();

            dataAccess.InsertMember(FirstNameTextBox.Text, LastNameTextBox.Text, int.Parse(AgeTextBox.Text), char.Parse(GenderComboBox.Text),
                UserTypeComboBox.Text, MailTextBox.Text);
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

        /// <summary>
        /// The AdminRegisterButton_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="RoutedEventArgs"/></param>
        private void AdminRegisterButton_Click(object sender, RoutedEventArgs e)
        {
            AdminRegisterPage adminRegisterPage = new AdminRegisterPage();
            NavigationService.Navigate(adminRegisterPage);
        }
    }
}
