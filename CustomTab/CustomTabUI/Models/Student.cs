using System;
using System.Collections.Generic;
using System.Text;

namespace CustomTabUI.Models
{
    enum Sex
    {
        Male,
        Female
    }

    class Student
    {
        public int Age { get; set; } = 0;
        public string Name { get; set; } = "Anonymous";
        public Sex Sex { get; set; } = Sex.Male;
    }
}
