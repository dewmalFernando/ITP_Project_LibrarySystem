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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            /* loginPage loginPage = new loginPage();
             this.Content = loginPage;*/

            mainFrame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
        }

        private void GoToLoginButton_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Content = new loginPage();
        }

       
        private void GoToCatalogue_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Content = new CatalogueForUsers();
        }

       
    }
}
