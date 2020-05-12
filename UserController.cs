using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Authorise(User user)
        {
            using (Login db = new Login())
            {
                var userDetials = db.Members.Where(u => u.Username.Equals(user.Username) && u.Password.Equals(user.Password)).FirstOrDefault();
                if(userDetials == null)
                {
                    user.LogError = "wrong detials";
                    return View("Index", user);
                }
                else
                {
                    Session["Username"] = user.Username;
                   
                    return RedirectToAction("Index","Home");
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