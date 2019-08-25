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

namespace wpfThreeView
{
    /// <summary>
    /// Interaction logic for BookDetailsEnteringPage.xaml
    /// </summary>
    public partial class BookDetailsEnteringPage : Page
    {
        public BookDetailsEnteringPage()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            DataAccess dataAccess = new DataAccess();

            dataAccess.InsertBook(BookTitleTextBox.Text, AuthorNameTextBox.Text, int.Parse(NoOfCoppiesTextBox.Text), int.Parse(AvilabilityTextBox.Text),
               int.Parse(RackNoTextBox.Text), IsbnTextBox.Text, PublisherTextBox.Text);
            MessageBox.Show("Record insert successful");
        }

        private void CancelTextBox_Click(object sender, RoutedEventArgs e)
        {
            BookDetailsManipulationPage bookDetailsManipulationPage = new BookDetailsManipulationPage();
            NavigationService.Navigate(bookDetailsManipulationPage);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            BookDetailsManipulationPage bookDetailsManipulationPage = new BookDetailsManipulationPage();
            NavigationService.Navigate(bookDetailsManipulationPage);
        }
    }
}
