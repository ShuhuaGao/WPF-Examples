using System;
using System.Collections.Generic;
using System.Text;

namespace CustomTabUI.Models
{
    public enum Sex
    {
        Male,
        Female
    }

    public class Student
    {
        public int Age { get; set; } = 0;
        public string Name { get; set; } = "Anonymous";
        public Sex Sex { get; set; } = Sex.Male;
    }
}
