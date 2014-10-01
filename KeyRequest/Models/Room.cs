using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KeyRequest.Models
{
    public class Room
    {
        public int RoomID { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public bool Available { get; set; }

        // Navigation Properties
        public virtual ICollection<Key> Keys { get; set; }
        public virtual ICollection<RequestSet> RequestSets { get; set; }
    }
}