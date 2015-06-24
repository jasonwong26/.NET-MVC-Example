using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using KeyRequest.DAL;
using KeyRequest.Mapping;
using KeyRequest.Models;
using System.Data.Entity;
using System.Web.Mvc;

namespace KeyRequest.ViewModels
{
    public class RoomForm
    {
        public int RoomFormID { get; set; }

        [StringLength(50, ErrorMessage = "Description cannot be more than 50 characters.")]
        [RegularExpression(@"^[\w\s]+$")]
        public string Description { get; set; }

        [StringLength(50, ErrorMessage = "Location cannot be more than 50 characters.")]
        [RegularExpression(@"^[\w\s]+$")]
        public string Location { get; set; }

        public bool Available { get; set; }

        public List<KeyForm> Keys { get; set; }
    }
}