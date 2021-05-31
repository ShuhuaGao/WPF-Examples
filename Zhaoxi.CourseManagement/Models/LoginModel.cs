using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stylet;

namespace Zhaoxi.CourseManagement.Models
{
    public class LoginModel : PropertyChangedBase
    {
        private string userName;

        public string UserName
        {
            get { return userName; }
            set { SetAndNotify(ref userName, value); }
        }

        private string passWord;

        public string PassWord
        {
            get => passWord;
            set => SetAndNotify(ref passWord, value);
        }

        private string verificationCode;

        public string VerificationCode
        {
            get { return verificationCode; }
            set { SetAndNotify(ref verificationCode, value); }
        }

    }
}
