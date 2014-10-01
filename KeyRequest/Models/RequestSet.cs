using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KeyRequest.Models
{
    public class RequestSet
    {
        [Key, Column(Order=0), ForeignKey("Request")]
        public int RequestID { get; set; }
        [Key, Column(Order = 1), ForeignKey("Room")]
        public int RoomID { get; set; }
        public int Sets { get; set; }

        // Navigation Properties
        public virtual Request Request { get; set; }
        public virtual Room Room { get; set; }
    }
}