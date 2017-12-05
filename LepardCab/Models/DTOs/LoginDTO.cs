using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LepardCab.Models.DTOs
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Contact is required")]
        public string Contact { get; set; }
        [Required(ErrorMessage ="Password is required")]
        public string Password { get; set; }
    }
}