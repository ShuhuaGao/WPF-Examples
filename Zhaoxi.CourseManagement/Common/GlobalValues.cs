using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zhaoxi.CourseManagement.DataAccess.Entity;

namespace Zhaoxi.CourseManagement.Common
{
    public static class GlobalValues
    {
        /// <summary>
        /// TODO: should use Thread.CurrentPrincipal
        /// TODO: or a IoC container
        /// </summary>
        public static UserEntity UserInfo { get; set; }
    }
}
