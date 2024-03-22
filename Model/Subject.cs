using System;
using System.Collections.Generic;

namespace Project_PRN221.Model
{
    public partial class Subject
    {
        public Subject()
        {
            Classes = new HashSet<Class>();
        }

        public int SubjectId { get; set; }
        public string? SubjectName { get; set; }

        public virtual ICollection<Class> Classes { get; set; }
    }
}
