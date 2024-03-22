using System;
using System.Collections.Generic;

namespace Project_PRN221.Model
{
    public partial class Teacher
    {
        public Teacher()
        {
            Classes = new HashSet<Class>();
        }

        public int TeacherId { get; set; }
        public string? TeacherName { get; set; }

        public virtual ICollection<Class> Classes { get; set; }
    }
}
