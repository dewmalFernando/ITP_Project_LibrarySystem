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
        
        private void OverdueBooksButton_Click(object sender, RoutedEventArgs e)
        {
            CheckOverdueBooksPage checkOverdueBooksPage = new CheckOverdueBooksPage();
            this.NavigationService.Navigate(checkOverdueBooksPage);
        }

        private void CatalogueButton_Click(object sender, RoutedEventArgs e)
        {
            Catalogue catalogue = new Catalogue();
            this.NavigationService.Navigate(catalogue);
        }

        private void UsersButton_Click(object sender, RoutedEventArgs e)
        {
            UserDetailsPage userDetailsPage = new UserDetailsPage();
            this.NavigationService.Navigate(userDetailsPage);
        }

        private void UserDetailsManipulationButton_Click(object sender, RoutedEventArgs e)
        {
            UserDetailsManipulationPage userDetailsManipulationPage = new UserDetailsManipulationPage();
            this.NavigationService.Navigate(userDetailsManipulationPage);
        }

        private void BookDetailsManipulationButton_Click(object sender, RoutedEventArgs e)
        {
            BookDetailsManipulationPage bookDetailsManipulationPage = new BookDetailsManipulationPage();
            this.NavigationService.Navigate(bookDetailsManipulationPage);
        }

        private void CheckBorrowedBookButton_Click(object sender, RoutedEventArgs e)
        {
            CheckBorrowedBookDetailsPage checkBorrowedBookDetailsPage = new CheckBorrowedBookDetailsPage();
            this.NavigationService.Navigate(checkBorrowedBookDetailsPage);
        }

        private void CheckFinesButton_Click(object sender, RoutedEventArgs e)
        {
            CheckFinesPage checkFinesPage = new CheckFinesPage();
            this.NavigationService.Navigate(checkFinesPage);
        }
    }
}
