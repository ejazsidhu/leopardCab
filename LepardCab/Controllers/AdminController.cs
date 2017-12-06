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
            if (Session["login"]==null)
            {
                TempData["NoUser"] = "You are not authorised for this route";
                return RedirectToAction("index", "User");
            }
            else
            {
                return View();


            }
        }


        #region UserCrud
        public ActionResult AllUser()
        {

            if (Session["login"] == null)
            {
                TempData["NoUser"] = "You are not authorised for this route";
                return RedirectToAction("index", "User");
            }
            else
            {
                var user = db.Users.ToList();
                return View(user);


            }
            
        }

        #endregion

        #region Driver
        public ActionResult AllDrivers()
        {
            if (Session["login"] == null)
            {
                TempData["NoUser"] = "You are not authorised for this route";
                return RedirectToAction("index", "User");
            }
            else
            {
                var drivers = db.Drivers.ToList();
                return View(drivers);


            }
          
        }
        #endregion

        #region Rides
        public ActionResult AllRides()
        {
            if (Session["login"] == null)
            {
                TempData["NoUser"] = "You are not authorised for this route";
                return RedirectToAction("index", "User");
            }
            else
            {
                var ride = db.Rides.ToList();
                return View(ride);


            }
            
        }
        #endregion


    }
}