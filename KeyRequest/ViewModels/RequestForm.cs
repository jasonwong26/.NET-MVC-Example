using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using KeyRequest.DAL;
using KeyRequest.Mapping;
using KeyRequest.Models;

namespace KeyRequest.ViewModels
{
    public class RequestForm
    {
        public int RequestFormID { get; set; }
        
        [Display(Name="Employee Number")]
        [StringLength(20, ErrorMessage = "Employee Number cannot be more than 20 characters.")]
        [Required]
        [RegularExpression(@"^\w+$")]
        public string EmployeeNo { get; set; }

        [Display(Name="Last Name")]
        [StringLength(50, ErrorMessage = "Name cannot be more than 50 characters.")]
        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        public string LastName { get; set; }

        [Display(Name = "First Name")]
        [StringLength(50, ErrorMessage = "Name cannot be more than 50 characters.")]
        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        public string FirstName { get; set; }

        [Display(Name = "Request Date")]
        [DataType(DataType.Date)]
        [Required]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime RequestDate { get; set; }

        public List<RequestSetForm> Sets{ get; set; }
    }
}