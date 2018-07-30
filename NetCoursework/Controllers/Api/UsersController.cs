using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using NetCoursework.Dtos;
using NetCoursework.Models;

namespace NetCoursework.Controllers.Api
{
    public class UsersController : ApiController
    {
        private ApplicationDbContext _context;

        public UsersController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: /api/user
        public IEnumerable<RegisteredUsersDto> GetUsers()
        {
            return _context.RegisteredUsers.ToList().Select(Mapper.Map<RegisteredUsers, RegisteredUsersDto>);
        }

        // GET /api/user/1
        public IHttpActionResult GetUser(int id)
        {
            var registeredUser = _context.RegisteredUsers.SingleOrDefault(c => c.Id == id);

            if (registeredUser == null)
                return NotFound();

            return Ok(Mapper.Map<RegisteredUsers, RegisteredUsersDto>(registeredUser));
        }

        // POST /api/users
        [HttpPost]
        public IHttpActionResult CreateUser(RegisteredUsersDto registeredUserDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var registeredUser = Mapper.Map<RegisteredUsersDto, RegisteredUsers>(registeredUserDto);
            _context.RegisteredUsers.Add(registeredUser);
            _context.SaveChanges();

            registeredUserDto.Id = registeredUser.Id;

            return Created(new Uri(Request.RequestUri + "/" + registeredUser.Id), registeredUserDto);
        }

        // PUT /api/users/1
        [HttpPut]
        public void UpdateUser(int id, RegisteredUsersDto registeredUserDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var registeredUserInDb = _context.RegisteredUsers.SingleOrDefault(c => c.Id == id);

            if (registeredUserInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(registeredUserDto, registeredUserInDb);

            _context.SaveChanges();
        }

        // DELETE /api/users/1
        [HttpDelete]
        public void DeleteUser(int id)
        {
            var registeredUserInDb = _context.RegisteredUsers.SingleOrDefault(c => c.Id == id);

            if (registeredUserInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.RegisteredUsers.Remove(registeredUserInDb);
            _context.SaveChanges();

        }
    }
}