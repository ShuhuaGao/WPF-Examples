using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zhaoxi.CourseManagement.Models;

namespace Zhaoxi.CourseManagement.ViewModels
{
    // prepare the data for consumption by the view
    public class CourseItemViewModel
    {
        private readonly CourseInfo course;

        public CourseItemViewModel(CourseInfo course)
        {
            this.course = course;
        }

        public string Name { get => course.Name; }


    }
}
