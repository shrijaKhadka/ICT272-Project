﻿using ICT272.DAL;
using ICT272.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ICT272.Controllers
{
    public class HomeController : Controller
    {
        private readonly HotelContext _dbContext = new HotelContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Gallery()
        {
            ViewBag.Message = "Your gallery page.";

            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {
                //get hash to check
                var source = user.Password;
                using (var md5Hash = MD5.Create())
                {
                    var sourceBytes = Encoding.UTF8.GetBytes(source);
                    var hashBytes = md5Hash.ComputeHash(sourceBytes);
                    var hash = BitConverter.ToString(hashBytes).Replace("-", string.Empty);
                    user.Password = hash;
                }

                bool IsValidUser = _dbContext.Users
               .Any(u => u.UserName.ToLower() == user
               .UserName.ToLower() && u
               .Password == user.Password);

                if (IsValidUser)
                {
                    FormsAuthentication.SetAuthCookie(user.UserName, false);
                    return RedirectToAction("Index", "Events");
                }

            }
            ModelState.AddModelError("", "invalid Username or Password");
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User registerUser)
        {
            if (ModelState.IsValid)
            {
                //hash the passord before add to DB
                var source = registerUser.Password;

                // Creates an instance of the default implementation of the MD5 hash algorithm.
                using (var md5Hash = MD5.Create())
                {
                    // Byte array representation of source string
                    var sourceBytes = Encoding.UTF8.GetBytes(source);

                    // Generate hash value(Byte Array) for input data
                    var hashBytes = md5Hash.ComputeHash(sourceBytes);

                    // Convert hash byte array to string
                    var hash = BitConverter.ToString(hashBytes).Replace("-", string.Empty);

                    // Output the MD5 hash
                    registerUser.Password = hash;
                }

                _dbContext.Users.Add(registerUser);
                _dbContext.SaveChanges();
                return RedirectToAction("Login");

            }
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }


        [Authorize(Roles = "Admin")]
            public ActionResult AdminMethod()
            {
                return View();
            }

            public ActionResult SecureMethod()
            {
                return View();
            }

            private bool ValidateUser(string username, string password)
            {
            if (username == "admin" && password == "admin")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool CheckIfUserIsAdmin(string UserName)
            {
            if (UserName == "admin")
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        }

    }
