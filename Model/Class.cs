using System;
using System.Collections.Generic;

namespace Project_PRN221.Model
{
    public partial class Class
    {
        public int ClassId { get; set; }
        public string? ClassName { get; set; }
        public int? SubjectId { get; set; }
        public int? TeacherId { get; set; }
        public int? RoomId { get; set; }
        public int? TimeslotId { get; set; }

        public virtual Room? Room { get; set; }
        public virtual Subject? Subject { get; set; }
        public virtual Teacher? Teacher { get; set; }
        public virtual Timeslot? Timeslot { get; set; }
    }
}
