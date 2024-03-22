using System;
using System.Collections.Generic;

namespace Project_PRN221.Model
{
    public partial class Room
    {
        public Room()
        {
            Classes = new HashSet<Class>();
        }

        public int RoomId { get; set; }
        public string? RoomName { get; set; }

        public virtual ICollection<Class> Classes { get; set; }
    }
}
