using AutoMapper;
using NetCoursework.Dtos;
using NetCoursework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NetCoursework.Controllers.Api
{
    public class EventsController : ApiController
    {
        private ApplicationDbContext _context;

        public EventsController()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<EventDto> GetEvents()
        {
            return _context.Events.ToList().Select(Mapper.Map<Event, EventDto>);
        }

        public IHttpActionResult GetEvent(int id)
        {
            var myEvent = _context.Events.SingleOrDefault(e => e.Id == id);

            if (myEvent == null)
                return NotFound();

            return Ok(Mapper.Map<Event, EventDto>(myEvent));
        }

        [HttpPost]
        public IHttpActionResult CreateEvent(EventDto myEventDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var myEvent = Mapper.Map<EventDto, Event>(myEventDto);
            _context.Events.Add(myEvent);
            _context.SaveChanges();

            myEventDto.Id = myEvent.Id;

            return Created(new Uri(Request.RequestUri + "/" + myEvent.Id), myEventDto);
        }

        [HttpPut]
        public void UpdateEvent(int id, EventDto myEventDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var eventInDb = _context.Events.SingleOrDefault(e => e.Id == id);

            if (eventInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(myEventDto, eventInDb);
            
            _context.SaveChanges();
        }

        // DELETE /api/events/{id}
        [HttpDelete]
        public void DeleteEvent(int id)
        {
            var eventInDb = _context.Events.SingleOrDefault(e => e.Id == id);

            if (eventInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Events.Remove(eventInDb);
            _context.SaveChanges();
        }
    }
}
