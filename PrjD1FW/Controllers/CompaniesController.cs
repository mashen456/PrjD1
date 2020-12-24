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
        public ActionResult Index()
        {

            company company = new company();

            if (TempData["session"] != null)
            {
                AuthedUser authedUser = new AuthedUser();
                authedUser = (AuthedUser)TempData["session"];

                if (authedUser.auth_success == false)
                {
                    return RedirectToAction("notAuthenticated", "error");
                }
                company.Name = authedUser.Username;
                ViewData["Username"] = authedUser.Username;
                return View("RegisterCompany", company);
            }
            else
            {
                return RedirectToAction("Index", "error");
            }
        }

        public ActionResult Register(company company)
        {
            ViewData["Message"] = "Registration Done!";
            return View("RegisterCompany", company);
        }

    }
}
