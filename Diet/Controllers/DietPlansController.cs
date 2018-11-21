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
    public class DietPlansController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DietPlans
        public ActionResult Index()
        {
            //return View(db.DietPlan.ToList());
            var dietPlan = db.DietPlan.ToList();
            return View(dietPlan);
        }

        // GET: DietPlans/Details/5
        //public ActionResult Details()
        //{
        //    //if (id == null)
        //    //{
        //    //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    //}
        //    //DietPlan dietPlan = db.DietPlan.Find(id);
        //    //if (dietPlan == null)
        //    //{
        //    //    return HttpNotFound();
        //    //}
        //    //return View(dietPlan);
        //    var currentPlan = User.Identity.GetUserId();
        //    var dietP = db.DietPlan.Where(d => d.)

        //}

        // GET: DietPlans/Create
        public ActionResult Create()
        {
            ViewBag.nutrionalKey = ApiKeys.nutritionKey;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CalorieLimit,PotentialFood,Food,Calories,MaxCal,MinCal")] DietPlan dietPlan)
        {
            if (ModelState.IsValid)
            {
                string currentUserId = User.Identity.GetUserId();
                dietPlan.ApplicationUserId = currentUserId;
                db.DietPlan.Add(dietPlan);
                db.SaveChanges();
                return RedirectToAction("Details");
            }
            ViewBag.nutrionalKey = ApiKeys.nutritionKey;
            return View(dietPlan);
        }

        // GET: DietPlans/Edit/5
        public ActionResult Edit(int id)
        {
            DietPlan plan = db.DietPlan.Find(id);
            return View(plan);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CalorieLimit,PotentialFood,Food,Calories,MaxCal,MinCal")] DietPlan dietPlan)
        {
            dietPlan.ApplicationUserId = User.Identity.GetUserId();
            var editPlan = db.DietPlan.Where(p => p.ApplicationUserId == dietPlan.ApplicationUserId).SingleOrDefault();
            editPlan.CalorieLimit = dietPlan.CalorieLimit;
            editPlan.Calories = dietPlan.Calories;
            editPlan.PotentialFood = dietPlan.PotentialFood;
            editPlan.Food = dietPlan.Food;
            editPlan.MaxCal = dietPlan.MaxCal;
            editPlan.MinCal = dietPlan.MinCal;
            db.SaveChanges();
            return RedirectToAction("Details");
        }

        // GET: DietPlans/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DietPlan dietPlan = db.DietPlan.Find(id);
            if (dietPlan == null)
            {
                return HttpNotFound();
            }
            return View(dietPlan);
        }

        // POST: DietPlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DietPlan dietPlan = db.DietPlan.Find(id);
            db.DietPlan.Remove(dietPlan);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Make the counter
        //public int? CalorieCount(string Calories)
        //{
        //    var calorieCounter = db.DietPlan.Where(c => c.Calories == Calories).Select()

        //}
    }
}
