using System.Collections.Generic;
using System.Web.Mvc;

namespace KeyRequest.ViewModels
{
    public class KeyForm
    {
        public int KeyFormID { get; set; }
        public int? RoomFormID { get; set; }
        public string Tag { get; set; }
    }
}