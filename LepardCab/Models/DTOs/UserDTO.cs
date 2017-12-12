using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LepardCab.Models.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [RegularExpression("(^[a-zA-Z]*$)", ErrorMessage = "Only Alphabets  here ")]
        public string Name { get; set; }
        [RegularExpression("(^[0-9]*$)", ErrorMessage ="Only numbers here Spaces are not allowed ")]
        [Required(ErrorMessage = "CNIC is required")]
        public string CNIC { get; set; }
        [Remote("IsAlreadySigned", "User", HttpMethod = "POST", ErrorMessage = "Contact already exists in database.")]

        [Required(ErrorMessage = "Contact is required")]
        [RegularExpression("(^[0-9]*$)", ErrorMessage = "Only numbers here ")]

        public string Contact { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [EmailAddress(ErrorMessage ="Enter a valid Email Address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirmation Password is required.")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Password and Confirmation Password must match.")]
        public string ConfirmPassword { get; set; }
    }
}