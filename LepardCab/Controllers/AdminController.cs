using LepardCab.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LepardCab.Controllers
{
    public class AdminController : Controller
    {
        private LaperdCabDbContaxt db;
        public AdminController()
        {
            db = new LaperdCabDbContaxt();
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }


        #region UserCrud
        public ActionResult AllUser()
        {
            var user = db.Users.ToList();
            return View(user);
        }

        #endregion

        #region Driver
        public ActionResult AllDrivers()
        {
            var drivers = db.Drivers.ToList();
            return View(drivers);
        }
        #endregion

        #region Rides
        public ActionResult AllRides()
        {
            var ride = db.Rides.ToList();
            return View(ride);
        }
        #endregion


    }
}