using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LepardCab.Models.DTOs
{
    public class RentDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Duration is required is required")]
        [Display(Name ="Durraton")]
        public decimal RentTime { get; set; }
        [Required(ErrorMessage = "Contact is required")]
        public string Contact { get; set; }
      //  [Required(ErrorMessage = " is required")]
       // public decimal Fare { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Car { get; set; }

    }
}