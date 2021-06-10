using Stylet;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zhaoxi.CourseManagement.Models;
using Zhaoxi.CourseManagement.DataAccess;
using Zhaoxi.CourseManagement.Common;
using System.Windows;

namespace Zhaoxi.CourseManagement.ViewModels
{
    public class LoginViewModel : Screen
    {
        public LoginModel LoginModel { get; set; }

        private string errorMessage = string.Empty;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetAndNotify(ref errorMessage, value); }
        }

        private readonly IWindowManager windowManager;

        public LoginViewModel(IWindowManager wm)
        {
            LoginModel = new LoginModel();
            LoginModel.VerificationCode = "12345";
            windowManager = wm;
        }

        /// <summary>
        /// Attempt login and, if successful, store the global user information.
        /// </summary>
        /// <seealso cref="GlobalValues.UserInfo"/>
        public void DoLogin()
        {
            ErrorMessage = string.Empty;
            if (string.IsNullOrEmpty(LoginModel.UserName))
            {
                ErrorMessage = "请输入用户名";
                return;
            }

            if (LoginModel.Password.Length == 0)
            {
                ErrorMessage = "请输入密码";
                return;
            }

            if (string.IsNullOrEmpty(LoginModel.VerificationCode))
            {
                ErrorMessage = "请输入验证码";
                return;
            }
            // check whether this account is valid
            var user = LocalDataAccess.Instance.CheckUserInfo(LoginModel.UserName, LoginModel.Password);
            if (user == null)
            {
                ErrorMessage = "登录失败！";
                return;
            }
            else
            {
                ErrorMessage = string.Empty;
                Debug.WriteLine("登录成功.");
                GlobalValues.UserInfo = user;  // STORE the user info for app-wide usage
                Debug.WriteLine($"The avatar of the user is {user.Avatar}");
                // close the login window and show the main window
                var mainWindow = new MainViewModel();
                windowManager.ShowWindow(mainWindow);
                // the order matters; otherwise, the app will stop immediately if the current window is first closed.
                // See Application.ShutdownMode 
                RequestClose();
            }
        }
    }
}
