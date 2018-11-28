using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Diet.Models;

namespace Diet.Controllers
{
    public class CreateDietsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CreateDiets
        public ActionResult Index()
        {
            return View(db.CreateDiet.ToList());
        }

        // GET: CreateDiets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CreateDiet createDiet = db.CreateDiet.Find(id);
            if (createDiet == null)
            {
                return HttpNotFound();
            }
            return View(createDiet);
        }

        // GET: CreateDiets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CreateDiets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,DietPlanName,Monday,Tuesday,Wednesday,Thursday,Friday,Saturday,Sunday,Goal")] CreateDiet createDiet)
        {
            if (ModelState.IsValid)
            {
                db.CreateDiet.Add(createDiet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(createDiet);
        }

        // GET: CreateDiets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CreateDiet createDiet = db.CreateDiet.Find(id);
            if (createDiet == null)
            {
                return HttpNotFound();
            }
            return View(createDiet);
        }

        // POST: CreateDiets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,DietPlanName,Monday,Tuesday,Wednesday,Thursday,Friday,Saturday,Sunday,Goal")] CreateDiet createDiet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(createDiet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(createDiet);
        }

        // GET: CreateDiets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CreateDiet createDiet = db.CreateDiet.Find(id);
            if (createDiet == null)
            {
                return HttpNotFound();
            }
            return View(createDiet);
        }

        // POST: CreateDiets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CreateDiet createDiet = db.CreateDiet.Find(id);
            db.CreateDiet.Remove(createDiet);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Test()
        {
            return View();
        }
    }
}
