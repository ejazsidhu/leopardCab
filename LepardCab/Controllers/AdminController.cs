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

        public ActionResult SaveUser(User user)
        {
            if (user.Id == 0)
            {
                db.Users.Add(user);

            }
            else
            {
                var userInDb = db.Users.SingleOrDefault(u => u.Id == user.Id);
                userInDb.Name = user.Name;
                userInDb.CNIC = user.CNIC;
                userInDb.Contact = user.Contact;
                userInDb.Email = user.Email;               
                userInDb.Password = user.Password;


            }
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
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
            }
            return RedirectToAction("AllUser","Admin");
        }
        #endregion
    }
}