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
            //SecurityService securityService = new SecurityService();
            //ViewBag.CompanySelection = securityService.ReturnAllCompanies();
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
                    ViewBag.Username = user.Username;
                    ViewBag.CompanySelection = securityService.ReturnAllCompanies();
                    return View("ChooseCompany");
                }
                else
                {
                    ViewData["Error"] = "Username already exists!";
                    return View("Register");
                }
            }
            return View("Register",user);
        }
        public ViewResult CompanyChosen(string CompanySelection, string Username)
        {
            string username = Username;
            string companySelection = CompanySelection;
            //go to member space
            ViewData["Error"] = "Erfolg!!";
            return View("Register");

        }

    }



}