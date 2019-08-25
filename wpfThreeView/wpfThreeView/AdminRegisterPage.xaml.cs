﻿using System;
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
    /// Interaction logic for AdminRegisterPage.xaml
    /// </summary>
    public partial class AdminRegisterPage : Page
    {
        public AdminRegisterPage()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            DataAccess dataAccess = new DataAccess();
            dataAccess.InsertAdminLogin(userNameTextBox.Text, passwordTextBox.Password);
        }
    }
}
