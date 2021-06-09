using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Stylet;

namespace HelloLogin.Pages
{
    public class LoginViewModel : Screen
    {
        private readonly IWindowManager windowManager;
        public LoginViewModel(IWindowManager windowManager)
        {
            this.windowManager = windowManager;
        }

        // check whether the user can login here
        public bool CanLogin()
        {
            return true;
        }

        // Action for the Login button
        public void Login()
        {
            if (CanLogin())
            {
                // show the main window
                var mainVM = new MainViewModel();
                windowManager.ShowWindow(mainVM);
                // close the current login window
                RequestClose();
            }
        }
    }
}
