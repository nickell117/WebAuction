using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectInitial.Models;

namespace ProjectInitial.Controllers
{
    public class UserController : Controller
    {  

        private IUserRepository repository;


        public UserController(IUserRepository repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public IActionResult Register()
        {
            User newUser = new User();
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            repository.AddUser(user);
            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            IQueryable<User> allUsers = repository.GetAllUsers();
            return View(allUsers);
        }

        //[HttpGet]
        //public IActionResult Login()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult Login(User user)
        //{
        //    bool success = repository.Login(user);
        //    return RedirectToAction("Index");
        //}
    }
}
