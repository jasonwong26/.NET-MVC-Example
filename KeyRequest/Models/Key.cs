using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KeyRequest.Models
{
    public class Key
    {
        public int KeyID { get; set; }
        public string Tag { get; set; }

        // Navigation Properties
        public int RoomID { get; set; }
        public virtual Room Room { get; set; }
    }
}