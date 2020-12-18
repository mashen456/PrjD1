using PrjD1FW.Models;
using PrjD1FW.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PrjD1FW.Controllers
{

    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            return View("Register");
        }



        public ActionResult Register(user user)
        {
            if (ModelState.IsValid)
            {
                SecurityService securityService = new SecurityService();
                Boolean authState = securityService.RegisterUser(user);
                if (authState)
                {
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    ViewData["Error"] = "Username already exists!";
                    return View("Register");
                }
            }
            return View("Register",user);
        }
    }
}