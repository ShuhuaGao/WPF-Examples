using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Stylet;

namespace Zhaoxi.CourseManagement.Models
{
    public class LoginModel : PropertyChangedBase
    {
        private string userName = "admin";

        public string UserName
        {
            get { return userName; }
            set { SetAndNotify(ref userName, value); }
        }

        private String password = "123456";

        public String Password
        {
            get => password;
            set => SetAndNotify(ref password, value);
        }

        private string verificationCode;

        public string VerificationCode
        {
            get { return verificationCode; }
            set { SetAndNotify(ref verificationCode, value); }
        }

    }
}
