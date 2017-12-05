using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LepardCab.Models.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "CNIC is required")]
        public string CNIC { get; set; }
        [Required(ErrorMessage = "Contact is required")]
        public string Contact { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [EmailAddress(ErrorMessage ="Enter a valid Email Address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirmation Password is required.")]
        [Compare("Password", ErrorMessage = "Password and Confirmation Password must match.")]
        public string ConfirmPassword { get; set; }
    }
}