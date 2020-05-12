using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Show()
        {
            var entities = new bookEntities();
            return View(entities.books.ToList());
        }

        [HttpGet]

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(book model)
        {
            if (ModelState.IsValid)
            {
                var db = new bookEntities();
                db.books.Add(new book
                {
                    Firstname = model.Firstname,
                    Secondname = model.Secondname,
                    Bookname = model.Bookname,
                    Author = model.Author,
                    Datetaken = model.Datetaken
                });db.SaveChanges();

            } return RedirectToAction("Show", "book");
        }

        [HttpGet]

        public ActionResult Update(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var db = new bookEntities();
            var toUpdate = db.books.Find(id);

            return View(toUpdate);
        }

        [HttpPost]
        public ActionResult Update(int? id, book model)
        {
            var db = new bookEntities();
            var toUpdate = db.books.Find(id);
            if (ModelState.IsValid)
            {
                if (toUpdate != null)
                {
                    toUpdate.Id = id ?? default(int);
                    toUpdate.Firstname = model.Firstname;
                    toUpdate.Secondname = model.Secondname;
                    toUpdate.Bookname = model.Bookname;
                    toUpdate.Author = model.Author;
                    toUpdate.Datetaken = model.Datetaken;
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Show", "book");
        }



         

    }
}