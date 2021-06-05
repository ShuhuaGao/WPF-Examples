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
    public class LoginViewModel : PropertyChangedBase
    {
        public LoginModel LoginModel { get; set; }

        private string errorMessage = string.Empty;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetAndNotify(ref errorMessage, value); }
        }


        public LoginViewModel()
        {
            LoginModel = new LoginModel();
            LoginModel.VerificationCode = "12345";
        }

        public void DoLogin(Window o)
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
                o.DialogResult = true;
            }
        }
    }
}
