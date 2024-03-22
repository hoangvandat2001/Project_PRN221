using System;
using System.Collections.Generic;

namespace Project_PRN221.Model
{
    public partial class Timeslot
    {
        public Timeslot()
        {
            Classes = new HashSet<Class>();
        }

        public int TimeslotId { get; set; }
        public string? DayOfWeek { get; set; }
        public int? SlotNumber { get; set; }
        public string? SlotType { get; set; }

        public virtual ICollection<Class> Classes { get; set; }
    }
}
