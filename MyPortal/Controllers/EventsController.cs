using MyPortal.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MyPortal.Controllers
{
    public class EventsController : Controller
    {
        private MyPortalContext db = new MyPortalContext();

        // GET: Events
        public ActionResult Index()
        {
            return View(db.EventModels.ToList());
        }

        // GET: Events/Board/
        public ActionResult Board()
        {
            return View();
        }

        // GET: Events/Browser/
        public ActionResult Browser()
        {
            //var eventModels = this.service.GetEventss();
            //return this.View(eventModels);
            return View();
        }

        // GET: Events/Calendar/
        public ActionResult Calendar()
        {
            return View();
        }

        // GET: Events/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventModel eventModel = db.EventModels.Find(id);
            if (eventModel == null)
            {
                return HttpNotFound();
            }
            return View(eventModel);

            //var eventModel = this.service.GetEvent(id);
            //if (eventModel == null)
            //{
            //    return HttpNotFound();
            //}
            //return this.View(eventModel);
        }

        // GET: Events/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Detail,url,Address,startDate,endDate")] EventModel eventModel)
        {
            if (ModelState.IsValid)
            {
                db.EventModels.Add(eventModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eventModel);
        }

        // GET: Events/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventModel eventModel = db.EventModels.Find(id);
            if (eventModel == null)
            {
                return HttpNotFound();
            }
            return View(eventModel);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Detail,url,Address,startDate,endDate")] EventModel eventModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eventModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eventModel);
        }

        // GET: Events/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventModel eventModel = db.EventModels.Find(id);
            if (eventModel == null)
            {
                return HttpNotFound();
            }
            return View(eventModel);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EventModel eventModel = db.EventModels.Find(id);
            db.EventModels.Remove(eventModel);
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