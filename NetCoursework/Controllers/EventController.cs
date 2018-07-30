using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NetCoursework.Models;
using System.Data.Entity;

namespace NetCoursework.Controllers
{
    public class EventController : Controller
    {
        //Database Object.
        private ApplicationDbContext _context;

        //Initialises the Database Object on Startup.
        public EventController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Event
        public ActionResult Index()
        {
            var events = _context.Events.ToList();

            if (User.IsInRole("Administrator"))
                return View(events);

            return View("ReadOnlyIndex", events);
        }

        // GET: Event/Details/{id}
        public ActionResult Details(int id)
        {
            var myEvent = _context.Events.SingleOrDefault(e => e.Id == id);

            if (myEvent == null)
                return HttpNotFound();

            return View(myEvent);
        }

        public ActionResult New()
        {
            var myEvent = new Event();
            return View("EventForm", myEvent);
        }

        [HttpPost]
        public ActionResult Save(Event myEvent)
        {
            if (!ModelState.IsValid)
            {
                var newEvent = myEvent;
                return View("EventForm", newEvent);
            }

            if (myEvent.Id == 0)
                _context.Events.Add(myEvent);
            else
            {
                var myEventInDb = _context.Events.Single(e => e.Id == myEvent.Id);

                myEventInDb.Name = myEvent.Name;
                myEventInDb.Eventdate = myEvent.Eventdate;
                myEventInDb.EventSubject = myEvent.EventSubject;
                myEventInDb.Location = myEvent.Location;
                myEventInDb.ContactNumber = myEvent.ContactNumber;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Event");
        }

        public ActionResult Edit(int id)
        {
            var myEvent = _context.Events.SingleOrDefault(e => e.Id == id);
            if (myEvent == null)
                return HttpNotFound();

            return View("EventForm", myEvent);
        }
    }
}