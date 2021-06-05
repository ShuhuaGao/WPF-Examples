using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Zhaoxi.CourseManagement.Views;

namespace Zhaoxi.CourseManagement
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var lv = new LoginView();
            if (lv.ShowDialog() == true)  // login successfully
            {
                Debug.WriteLine($"Login successfully. ");
                new MainView().ShowDialog();
            }
            // after the main window finishes
            Shutdown();
        }
    }
}
