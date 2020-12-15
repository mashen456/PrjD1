using PrjD1FW.Models;
using PrjD1FW.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PrjD1FW.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult login()
        {
            return View("Login");
        }



        public string s(user user)
        {
            SecurityService securityService = new SecurityService();
            Boolean authState = securityService.Auth(user);
            if (authState)
            {
                return "success";
            }
            return "nope";
        }
    }
}