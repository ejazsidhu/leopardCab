using LepardCab.Models;
using LepardCab.Models.DTOs;
using LepardCab.ViewModels;
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
        [HttpPost]
        public ActionResult Login(LoginDTO login)
        {
            var login_details = db.Users.ToList();
            if (login_details != null)
            {
                foreach (var item in login_details)
                {
                    if (login.Contact.Equals("10000") && login.Password.Equals("admin"))
                    {

                        Session["login"] = "login";

                        return RedirectToAction("index", "admin");


                    }
                    else if (login.Contact.Equals(item.Contact) && login.Password.Equals(item.Password))
                    {
                        var user = db.Users.SingleOrDefault(u => u.Id == item.Id);
                        if (user != null)
                        {
                            Session["loginUser"] = user;
                            return RedirectToAction("FareCalculater", "home");

                        }

                    }
                    else
                    {
                        TempData["NoUser"] = "User Does not Exist";
                    }


                }

            }

            return RedirectToAction("index", "User");

        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(UserDTO dto)
        {
            var user = new User();
            user.Name = dto.Name;
            user.CNIC = dto.CNIC;
            user.Email = dto.Email;
            user.Password = dto.Password;
            user.Contact = dto.Contact;


            try
            {
                db.Users.Add(user);
                db.SaveChanges();
                if (user.Id != 0)
                {
                    TempData["UserMessages"] = "User  Succesfully Created.";
                    Session["loginUser"] = user;
                    return RedirectToAction("FareCalculater", "home");


                }
                else
                {
                    TempData["error"] = "User Succesfully  not created Created." + "Error Message";
                    return RedirectToAction("Create", "User");

                }
            }
            catch (Exception e)
            {
                TempData["error"] = "User Not Succesfully Created." + "Error Message" + e;

            }
            return RedirectToAction("Create", "User");
        }

        public ActionResult SignupOptions()
        {
            return View();
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            var user = db.Users.Find(id);
            return View(user);
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, User dto)
        {
            var user = db.Users.Find(id);

            try
            {
                user.Name = dto.Name;
                user.CNIC = dto.CNIC;
                user.Email = dto.Email;
                user.Password = dto.Password;
                user.Contact = dto.Contact;
                db.SaveChanges();


                TempData["UserMessages"] = "User is updated";

                return RedirectToAction("AllUser", "Admin");
            }
            catch (Exception e)
            {
                TempData["error"] = "User is not saved Error Message: " + e;

                return RedirectToAction("AllUser", "Admin");
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            var user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();


            TempData["UserMessages"] = "User is Deleted";

            return RedirectToAction("AllUser", "Admin");
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Logout()
        {
            Session["login"] = null;

            return RedirectToAction("Index","Home");
        }
    }
}
