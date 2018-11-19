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
    public class MessageBoardsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MessageBoards
        public ActionResult Index()
        {
            return View(db.MessageBoards.ToList());
        }

        // GET: MessageBoards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MessageBoard messageBoard = db.MessageBoards.Find(id);
            if (messageBoard == null)
            {
                return HttpNotFound();
            }
            return View(messageBoard);
        }

        // GET: MessageBoards/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MessageBoards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MessageBoardID,Date,Topic,Message,Name")] MessageBoard messageBoard)
        {
            if (ModelState.IsValid)
            {
                db.MessageBoards.Add(messageBoard);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(messageBoard);
        }

        // GET: MessageBoards/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MessageBoard messageBoard = db.MessageBoards.Find(id);
            if (messageBoard == null)
            {
                return HttpNotFound();
            }
            return View(messageBoard);
        }

        // POST: MessageBoards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MessageBoardID,Date,Topic,Message,Name")] MessageBoard messageBoard)
        {
            if (ModelState.IsValid)
            {
                db.Entry(messageBoard).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(messageBoard);
        }

        // GET: MessageBoards/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MessageBoard messageBoard = db.MessageBoards.Find(id);
            if (messageBoard == null)
            {
                return HttpNotFound();
            }
            return View(messageBoard);
        }

        // POST: MessageBoards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MessageBoard messageBoard = db.MessageBoards.Find(id);
            db.MessageBoards.Remove(messageBoard);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // FIRST CATEGORY

        public ActionResult Index2()
        {
            return View(db.MessageBoards.ToList());
        }

        // GET: MessageBoards/Details/5
        public ActionResult Details2(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MessageBoard messageBoard = db.MessageBoards.Find(id);
            if (messageBoard == null)
            {
                return HttpNotFound();
            }
            return View(messageBoard);
        }

        // GET: MessageBoards/Create
        public ActionResult Create2()
        {
            return View();
        }

        // POST: MessageBoards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create2([Bind(Include = "MessageBoardID,Date,Topic,Message,Name")] MessageBoard messageBoard)
        {
            if (ModelState.IsValid)
            {
                db.MessageBoards.Add(messageBoard);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(messageBoard);
        }

        // GET: MessageBoards/Edit/5
        public ActionResult Edit2(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MessageBoard messageBoard = db.MessageBoards.Find(id);
            if (messageBoard == null)
            {
                return HttpNotFound();
            }
            return View(messageBoard);
        }

        // POST: MessageBoards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit2([Bind(Include = "MessageBoardID,Date,Topic,Message,Name")] MessageBoard messageBoard)
        {
            if (ModelState.IsValid)
            {
                db.Entry(messageBoard).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(messageBoard);
        }

        // GET: MessageBoards/Delete/5
        public ActionResult Delete2(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MessageBoard messageBoard = db.MessageBoards.Find(id);
            if (messageBoard == null)
            {
                return HttpNotFound();
            }
            return View(messageBoard);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed2(int id)
        {
            MessageBoard messageBoard = db.MessageBoards.Find(id);
            db.MessageBoards.Remove(messageBoard);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Categories()
        {
            return View();
        }

    }
}
