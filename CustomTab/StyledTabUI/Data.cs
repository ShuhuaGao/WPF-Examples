using System;
using System.Collections.Generic;
using System.Text;

namespace StyledTabUI
{
    enum Sex
    {
        Male,
        Female
    }

    class Teacher
    {
        public int Age { get; private set; } = 45;
        public string Name { get; private set; } = "Samuel Brown";
        public Sex Sex { get; set; } = Sex.Male;

    }

    class Student
    {
        public int Age { get; set; } = 0;
        public string Name { get; set; } = "Anonymous";
        public Sex Sex { get; set; } = Sex.Male;
    }
}
