using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Diet.Models;
using Microsoft.AspNet.Identity;

namespace Diet.Controllers
{
    public class DietersController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        // GET: Users
        public ActionResult Index()
        {
            // return View(db.User.ToList());
            var user = db.Users.ToList();
            return View(user);
        }

        // GET: Users/Details/5
        public ActionResult Details()
        {
            var currentUser = User.Identity.GetUserId();
            var user = db.Dieters.Where(u => u.ApplicationUserId == currentUser).SingleOrDefault();
            return View(user);

        }

        // GET: Users/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "ID,Name,Weight,Height")] Dieter dieter)
        {          
            string currentUserId = User.Identity.GetUserId();
            dieter.ApplicationUserId = currentUserId;
            db.Dieters.Add(dieter);
            db.SaveChanges();
            return RedirectToAction("Details");
        }

        [HttpGet]
        public ActionResult Edit(int id = 0)
        {
            Dieter user = db.Dieters.Find(id);
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Name,Weight,Height")] Dieter dieter)
        {
            dieter.ApplicationUserId = User.Identity.GetUserId();
            var editUser = db.Dieters.Where(d => d.ApplicationUserId == dieter.ApplicationUserId).SingleOrDefault();
            editUser.Height = dieter.Height;
            editUser.Weight = dieter.Weight;
            editUser.Name = dieter.Name;
            db.SaveChanges();
            return RedirectToAction("Details");
            
        }

        // GET: Users/Delete/5
        public ActionResult Delete(string id)
        {
            Dieter user = db.Dieters.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);                
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Dieter user = db.Dieters.Find(id);
            db.Dieters.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
