﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Shapes;
using Zhaoxi.CourseManagement.ViewModels;

namespace Zhaoxi.CourseManagement.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
            DataContext = new LoginViewModel();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();  // move the window
            //Debug.WriteLine("Move");
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            // assign the password to the viewmodel if it exists
            if (DataContext != null)
            {
                dynamic vm = DataContext;  // use `dynamic` to pass static type check
                vm.LoginModel.Password = (sender as PasswordBox).SecurePassword;
                Debug.WriteLine("Password changed.");
            }
        }
    }
}