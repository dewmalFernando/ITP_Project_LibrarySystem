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

namespace wpfThreeView
{
    /// <summary>
    /// Interaction logic for AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        public AdminPage()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// Navigate to where overdue books listed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OverdueBooksButton_Click(object sender, RoutedEventArgs e)
        {
            CheckOverdueBooksPage checkOverdueBooksPage = new CheckOverdueBooksPage();
            this.NavigationService.Navigate(checkOverdueBooksPage);
        }

        /// <summary>
        /// Navigate to catalogue page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CatalogueButton_Click(object sender, RoutedEventArgs e)
        {
            Catalogue catalogue = new Catalogue();
            this.NavigationService.Navigate(catalogue);
        }

        /// <summary>
        /// Navigate to User details page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UsersButton_Click(object sender, RoutedEventArgs e)
        {
            UserDetailsPage userDetailsPage = new UserDetailsPage();
            this.NavigationService.Navigate(userDetailsPage);
        }

        /// <summary>
        /// Navigate to user details manipulatoin page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserDetailsManipulationButton_Click(object sender, RoutedEventArgs e)
        {
            UserDetailsManipulationPage userDetailsManipulationPage = new UserDetailsManipulationPage();
            this.NavigationService.Navigate(userDetailsManipulationPage);
        }

        /// <summary>
        /// Navigate to book details manipulation page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BookDetailsManipulationButton_Click(object sender, RoutedEventArgs e)
        {
            BookDetailsManipulationPage bookDetailsManipulationPage = new BookDetailsManipulationPage();
            this.NavigationService.Navigate(bookDetailsManipulationPage);
        }

        /// <summary>
        /// Navigate to where borrowed books listed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBorrowedBookButton_Click(object sender, RoutedEventArgs e)
        {
            CheckBorrowedBookDetailsPage checkBorrowedBookDetailsPage = new CheckBorrowedBookDetailsPage();
            this.NavigationService.Navigate(checkBorrowedBookDetailsPage);
        }


        /// <summary>
        /// Navigate to where fines are listed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckFinesButton_Click(object sender, RoutedEventArgs e)
        {
            CheckFinesPage checkFinesPage = new CheckFinesPage();
            this.NavigationService.Navigate(checkFinesPage);
        }

        /// <summary>
        /// Navigate to previous page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        /// <summary>
        /// logout
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
