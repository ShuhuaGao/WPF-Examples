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
        protected override void OnClose()
        {
            Debug.WriteLine(nameof(OnClose));
            base.OnClose();
        }

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

        public override Task<bool> CanCloseAsync()
        {
            Debug.WriteLine(nameof(CanCloseAsync));
            if (CanLogin())
            {
                // show the main window
                var mainVM = new MainViewModel();
                windowManager.ShowWindow(mainVM);
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }
    }
}
