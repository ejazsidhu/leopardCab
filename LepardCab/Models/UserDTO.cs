using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LepardCab.Models
{
    public class UserDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Provide Name", AllowEmptyStrings = false)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Provide CNIC", AllowEmptyStrings = false)]
        public string CNIC { get; set; }
        [Required(ErrorMessage = "Please Provide Contact", AllowEmptyStrings = false)]
        public string Contact { get; set; }
        [Required(ErrorMessage = "Please Provide Email", AllowEmptyStrings = false)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Provide Password", AllowEmptyStrings = false)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Password Must be 4 Charecter long.")]

        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Confirm Password Dose Not Match")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]

        public string ConfirmPassword { get; set; }
    }
}