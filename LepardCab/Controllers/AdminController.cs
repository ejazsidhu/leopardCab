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
        public ActionResult CreateUser()
        {
            return View();
        }

       
        public ActionResult EditUser(int id)
        {
            var user = db.Users.SingleOrDefault(u => u.Id == id);
            
            return View(user);
        }
        public ActionResult DeleteUser(int id)
        {
            var user = db.Users.SingleOrDefault(u => u.Id == id);
            if (user != null)
            {
                db.Users.Remove(user);
                db.SaveChanges();
            }
            return RedirectToAction("AllUser","Admin");
        }
        #endregion

        #region Driver CRUD

        public ActionResult AddDriver()
        {
            return View();
        }

        public ActionResult AllDrivers()
        {
            var drivers = db.Drivers.ToList();
            return View(drivers);
        }

        public ActionResult SaveDriver(UserDTO userDto)
        {
            var user = new User();
            user.Name = userDto.Name;
            user.Contact = userDto.Contact;
            user.CNIC = userDto.CNIC;
            user.Email = userDto.Email;
            user.Password = userDto.Password;
            
            db.Users.Add(user);
            db.SaveChanges();

            

            return RedirectToAction("Index", "Home");
           
            
        }

        public ActionResult EditDriver(int id)
        {
            var driver = db.Drivers.SingleOrDefault(d=>d.Id==id);

            return View(driver);
        }
        public ActionResult UpdateDriver(User user)
        {
            var userInDb = db.Users.SingleOrDefault(u => u.Id == user.Id);
            userInDb.Name = user.Name;
            userInDb.CNIC = user.CNIC;
            userInDb.Contact = user.Contact;
            userInDb.Email = user.Email;
            userInDb.Password = user.Password;
                    
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult DeleteDriver(int id)
        {
            var driver = db.Drivers.SingleOrDefault(d => d.Id == id);
            if (driver != null)
            {
                db.Drivers.Remove(driver);
                db.SaveChanges();
            }

            return View();
        }

        #endregion

        #region Ride CRUD 
        public ActionResult AllRides()
        {
            var rides = db.Rides.ToList();
            return View(rides);
        }  
        #endregion
    }
}