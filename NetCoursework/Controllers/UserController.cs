using NetCoursework.Models;
using NetCoursework.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace NetCoursework.Controllers
{
    
    public class UserController : Controller
    {
        //Database Object.
        private ApplicationDbContext _context;

        //Initialises the Database Object on Startup.
        public UserController()
        {
            _context = new ApplicationDbContext();
        }

        //Disposing the disposable object.
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: User
        public ActionResult Index()
        {
            var users = _context.RegisteredUsers.Include(c => c.Biography);

            if (User.IsInRole("Administrator"))
                return View(users);

            return View("ReadOnlyIndex", users);
        }

        // GET: User/Details/{id}
        public ActionResult Details(int id)
        {
            var user = _context.RegisteredUsers.Include(c => c.Biography).SingleOrDefault(c => c.Id == id);

            if (user == null)
                return HttpNotFound();

            return View(user);
        }

        // GET: User/New
        public ActionResult New()
        {

            var biographies = _context.Biographies.ToList();
            var viewModel = new NewUserViewModel
            {
                RegisteredUser = new RegisteredUsers(),
                Biographies = biographies
            };

            return View("UserForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(RegisteredUsers registeredUser)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new NewUserViewModel
                {
                    RegisteredUser = registeredUser,
                    Biographies = _context.Biographies.ToList()
                };

                return View("UserForm", viewModel);
            }

            if (registeredUser.Id == 0)
                _context.RegisteredUsers.Add(registeredUser);
            else
            {
                var registeredUserInDb = _context.RegisteredUsers.Single(c => c.Id == registeredUser.Id);

                registeredUserInDb.Name = registeredUser.Name;
                registeredUserInDb.Birthdate = registeredUser.Birthdate;
                registeredUserInDb.Gender = registeredUser.Gender;
                registeredUserInDb.Email = registeredUser.Email;
                registeredUserInDb.Address = registeredUser.Address;
                registeredUserInDb.Postcode = registeredUser.Postcode;
                registeredUserInDb.Phonenumber = registeredUser.Phonenumber;
                registeredUserInDb.BiographyId = registeredUser.BiographyId;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "User");
        }

        public ActionResult Edit(int id)
        {
            var registeredUser = _context.RegisteredUsers.SingleOrDefault(c => c.Id == id);
            if (registeredUser == null)
                return HttpNotFound();

            var viewModel = new NewUserViewModel
            {
                RegisteredUser = registeredUser,
                Biographies = _context.Biographies.ToList()
            };
            return View("UserForm", viewModel);
        }
    }
}