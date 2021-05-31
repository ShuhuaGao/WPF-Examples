using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zhaoxi.CourseManagement.Models;

namespace Zhaoxi.CourseManagement.ViewModels
{
    public class LoginViewModel
    {
        public LoginModel LoginModel { get; set; }


        public LoginViewModel()
        {
            LoginModel = new LoginModel();
            LoginModel.UserName = "Gao Shuhua";
            LoginModel.VerificationCode = "12345";
        }
    }
}
