﻿using PrjD1FW.Models;
using PrjD1FW.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PrjD1FW.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View("Login");
        }



        public ActionResult Login(user user)
        {
            SecurityService securityService = new SecurityService();
            Boolean authState = securityService.Auth(user);
            if (authState)
            {
                return View("Login", user);
            }
            return View("Login", user);
        }
    }
}