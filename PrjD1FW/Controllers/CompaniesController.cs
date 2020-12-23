using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PrjD1FW.Models;
using PrjD1FW.Services;

namespace PrjD1FW.Controllers
{
    public class CompaniesController : Controller
    {
        // GET: Login
        public ActionResult Index(string id)
        {
            company company = new company();
            if (id == "2")
            {
                company.Name = "RRSAAAaasada";
            }
            else
            {
                company.Name = "nope";
            }

            return View("RegisterCompany", company);
        }

        public ActionResult Register(string id)
        {
            company company = new company();
            if (id == "2")
            {
                company.Name = "RRSAAAaasada";
            }
            else
            {
                company.Name = "nope";
            }

            return View("RegisterCompany", company);
        }



        //public ActionResult Login(user user)
        //{

        //    SecurityService securityService = new SecurityService();
        //    Boolean authState = securityService.Auth(user);
        //    if (authState)
        //    {
        //        ViewData["Success"] = "Login Success";
        //        return View("userPannel", user);
        //    }

        //    ViewData["Error"] = "Username / Password combination not found!";

        //    return View("login", user);
        //}
    }
}
