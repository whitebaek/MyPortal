using MyPortal.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace MyPortal.Controllers.Api
{
    public class EventsController : ApiController
    {
        private MyPortalContext db = new MyPortalContext();

        // GET: api/Events
        public IQueryable<EventModel> GetEventModels()
        {
            return db.EventModels;
        }

        // GET: api/Events/GetFullCalendarEvents
        [Route("~/api/Events/GetFullCalendarEvents")]
        public IQueryable<FullCalendarViewModel> GetFullCalendarEvents()
        {
            var events = new List<FullCalendarViewModel>();
            foreach (EventModel e in db.EventModels)
            {
                events.Add(new FullCalendarViewModel() { id = e.Id, title = e.Title, start = e.StartDate, end = e.EndDate });

            }
            return events.AsQueryable<FullCalendarViewModel>();
        }

        // GET: api/Events/5
        [ResponseType(typeof(EventModel))]
        public IHttpActionResult GetEventModel(int id)
        {
            EventModel eventModel = db.EventModels.Find(id);
            if (eventModel == null)
            {
                return NotFound();
            }

            return Ok(eventModel);
        }

        // PUT: api/Events/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEventModel(int id, EventModel eventModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != eventModel.Id)
            {
                return BadRequest();
            }

            db.Entry(eventModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Events
        [ResponseType(typeof(EventModel))]
        public IHttpActionResult PostEventModel(EventModel eventModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EventModels.Add(eventModel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = eventModel.Id }, eventModel);
        }

        // DELETE: api/Events/5
        [ResponseType(typeof(EventModel))]
        public IHttpActionResult DeleteEventModel(int id)
        {
            EventModel eventModel = db.EventModels.Find(id);
            if (eventModel == null)
            {
                return NotFound();
            }

            db.EventModels.Remove(eventModel);
            db.SaveChanges();

            return Ok(eventModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EventModelExists(int id)
        {
            return db.EventModels.Count(e => e.Id == id) > 0;
        }
    }
}
