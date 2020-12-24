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
                company.FK_creator = authedUser.id;
                return View("RegisterCompany", company);
            }
            else
            {
                return RedirectToAction("Index", "error");
            }
        }

        public ActionResult Register(company company)
        {
            if (ModelState.IsValid)
            {
                SecurityService securityService = new SecurityService();
                ReturnInfo registerCompany = securityService.RegisterCompany(company);

                if (registerCompany.success)
                {
                    ViewData["Message"] = "success";
                    return View("DetailsCompany", company);
                }
                else
                {
                    ViewData["Message"] = registerCompany.errorMessage;
                }
                return View("RegisterCompany", company);
            }
            else
            {
                ViewData["Message"] = "Registration Failed!";
                return View("Register", company);
            }
        }

    }
}
