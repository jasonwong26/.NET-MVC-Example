using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KeyRequest.Models;

namespace KeyRequest.ViewModels
{
    public class RequestReport
    {
        public string Description { get; set; }
        public string Location { get; set; }
        public string Tag { get; set; }
        public int Sets { get; set; }
    }
}