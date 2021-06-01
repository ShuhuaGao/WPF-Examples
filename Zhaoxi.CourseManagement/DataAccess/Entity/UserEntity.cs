using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhaoxi.CourseManagement.DataAccess.Entity
{
    public class UserEntity
    {
        public string UserName { get; set; }
        public string RealName { get; set; }
        public string Password { get; set; }
        public string Avatar { get; set; }
        public int Gender { get; set; }
    }
}
