using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using KeyRequest.DAL;
using KeyRequest.Mapping;
using KeyRequest.Models;

namespace KeyRequest.ViewModels
{
    public class RequestSetForm
    {
        public IEnumerable<SelectListItem> RoomList { get; set; }

        public int RequestFormID { get; set; }
        public int? RoomID { get; set; }
        public string RoomDescription { get; set; }

        [Range(0, 9)]
        public int Sets { get; set; }
    }
}