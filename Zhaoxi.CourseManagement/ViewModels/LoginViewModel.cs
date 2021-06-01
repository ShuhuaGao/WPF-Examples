using Stylet;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zhaoxi.CourseManagement.Models;

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
            LoginModel.UserName = "Gao Shuhua";
            LoginModel.VerificationCode = "12345";
        }

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
        }
    }
}
