using System;
using System.Collections.Generic;
using System.Linq;
using Stylet;
using System.Threading.Tasks;

namespace Zhaoxi.CourseManagement.Models
{
    public class UserModel : PropertyChangedBase
    {
        private string avatar;

        public string Avatar
        {
            get => avatar;
            set => SetAndNotify(ref avatar, value);
        }

        private string userName;

        public string UserName
        {
            get => userName;
            set => SetAndNotify(ref userName, value);
        }

        private int gender;

        public int Gender
        {
            get => gender;
            set => SetAndNotify(ref gender, value);
        }


    }
}
