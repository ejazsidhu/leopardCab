using LepardCab.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LepardCab.ViewModels
{
    public class RideViewModel
    {
        public Ride Ride { get; set; }
        public IEnumerable<Driver> DriverList { get; set; }
    }
}