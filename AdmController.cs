using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AdmController : Controller
    {
        // GET: Adm
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Authorise(User user)
        {
            using (AdminData db = new AdminData())
            {
                var userDetials = db.ADtable.Where(u => u.Username.Equals(user.Username) && u.Password.Equals(user.Password)).FirstOrDefault();
                if (userDetials == null)
                {
                    user.LogError = "wrong detials";
                    return View("Index", user);
                }
                else
                {
                    Session["Admin"] = user.Username;

                    return RedirectToAction("Index", "Home");
                }


            }

        }



        public ActionResult Logout()
        {

            Session.Abandon();
            return RedirectToAction("Index", "User");
        }

    }
}