using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace KeyRequest.Models
{
    public class Request
    {
        [Key]
        public int RequestID { get; set; }
        public string EmployeeNo { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime RequestDate { get; set; }

        // Navigation Properties
        public virtual ICollection<RequestSet> KeySets { get; set; }
    }
}