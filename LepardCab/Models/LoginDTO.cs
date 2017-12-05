using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LepardCab.Models
{
    public class LoginDTO
    {

        [Required(ErrorMessage = "Please Provide Name", AllowEmptyStrings = false)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Provide Password", AllowEmptyStrings = false)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]

        public string Password { get; set; }
    }
}