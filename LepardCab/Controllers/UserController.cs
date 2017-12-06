using LepardCab.Models;
using LepardCab.Models.DTOs;
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
                            Session["UserLogin"] = user;
                            return RedirectToAction("index", "home");

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
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult SignupOptions()
        {
            return View();
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
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
