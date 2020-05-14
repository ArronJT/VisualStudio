using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Member model)
        {
            if (ModelState.IsValid)
            {
                var db = new Login();
                db.Members.Add(new Member
                {
                    Firstname = model.Firstname,
                    Secondname = model.Secondname,
                    Username = model.Username,
                    Email = model.Email,
                    Password = Crypto.HashPassword(model.Password)
                });
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Home");
        }
    }
}