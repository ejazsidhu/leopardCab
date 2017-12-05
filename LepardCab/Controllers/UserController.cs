using LepardCab.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LepardCab.Controllers
{
    public class UserController : Controller
    {

        private LaperdCabDbContaxt db;
        public UserController()
        {
            db = new LaperdCabDbContaxt();
        }
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SignUpOptions()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginDTO login)
        {
            return View();
        }

        public ActionResult DriverSignup()
        {
            return View();
        }

        public ActionResult SaveUser(User user)
        {
            
                db.Users.Add(user);
                db.SaveChanges();

            return RedirectToAction("Index", "Home");

        }

        public ActionResult UpdateUser(User user)
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
        public ActionResult EditUser(int id)
        {
            var user = db.Users.SingleOrDefault(u => u.Id == id);
            return View(user);
        }

    }
}