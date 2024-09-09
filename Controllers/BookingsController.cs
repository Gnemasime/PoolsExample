using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PoolsExample.Models;

namespace PoolsExample.Controllers
{
    public class BookingsController : Controller
    {
        private PoolsDbContext db = new PoolsDbContext();

        // GET: Bookings
        public ActionResult Index()
        {
            var bookings = db.bookings.Include(b => b.Pools).Include(b => b.Timeclass);
            return View(bookings.ToList());
        }

        // GET: Bookings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bookings bookings = db.bookings.Find(id);
            if (bookings == null)
            {
                return HttpNotFound();
            }
            return View(bookings);
        }

        // GET: Bookings/Create
        public ActionResult Create()
        {
            ViewBag.Pool_Id = new SelectList(db.pool, "Pool_Id", "Pool_Name");
            ViewBag.Time_id = new SelectList(db.time, "Time_id", "DayTime");
            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Book_Id,Cust_Name,No_Visitors,Pool_Id,Time_id,Costs")] Bookings bookings)
        {
            if (ModelState.IsValid)
            {
                bookings.Costs = bookings.CalcTotal();
                db.bookings.Add(bookings);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Pool_Id = new SelectList(db.pool, "Pool_Id", "Pool_Name", bookings.Pool_Id);
            ViewBag.Time_id = new SelectList(db.time, "Time_id", "DayTime", bookings.Time_id);
            return View(bookings);
        }

        // GET: Bookings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bookings bookings = db.bookings.Find(id);
            if (bookings == null)
            {
                return HttpNotFound();
            }
            ViewBag.Pool_Id = new SelectList(db.pool, "Pool_Id", "Pool_Name", bookings.Pool_Id);
            ViewBag.Time_id = new SelectList(db.time, "Time_id", "DayTime", bookings.Time_id);
            return View(bookings);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Book_Id,Cust_Name,No_Visitors,Pool_Id,Time_id,Costs")] Bookings bookings)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookings).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Pool_Id = new SelectList(db.pool, "Pool_Id", "Pool_Name", bookings.Pool_Id);
            ViewBag.Time_id = new SelectList(db.time, "Time_id", "DayTime", bookings.Time_id);
            return View(bookings);
        }

        // GET: Bookings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bookings bookings = db.bookings.Find(id);
            if (bookings == null)
            {
                return HttpNotFound();
            }
            return View(bookings);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bookings bookings = db.bookings.Find(id);
            db.bookings.Remove(bookings);
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
    }
}
