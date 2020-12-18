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
        public ActionResult Index(user user)
        {
            return View("Register", user);
        }



        public ActionResult Register(user user)
        {
            SecurityService securityService = new SecurityService();
            Boolean authState = securityService.RegisterUser(user);
            if (authState)
            {
                return View("Register", user);
            }
            return View("Register", user);
        }
    }
}