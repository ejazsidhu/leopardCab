using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LepardCab.Models
{
    public class DriverDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Contact is Required")]
        public string Contact { get; set; }
        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress(ErrorMessage ="Enter Valid Email Address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Address is Required")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Cab Number is Required")]
        public string CabNumber { get; set; }
        [Required(ErrorMessage = "CNIC is Required")]
        public string CNIC { get; set; }
        [Required(ErrorMessage = "License Number is Required")]
        public string LicenseNumber { get; set; }
    }
}