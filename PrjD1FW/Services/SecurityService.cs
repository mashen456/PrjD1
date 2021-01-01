using PrjD1FW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PrjD1FW.Services
{
    public class SecurityService
    {
        DatabaseAccessObject dbObject = new DatabaseAccessObject();




        public AuthedUser Authenticate(user user)
        {
            return dbObject.AuthUser(user);

        }
        public bool RegisterUser(user user)
        {
            return dbObject.RegisterUser(user);
        }

        internal ReturnInfo RegisterCompany(company company)
        {

            return dbObject.RegisterCompany(company);
        }
        internal List<SelectListItem> ReturnAllCompanies()
        {
            return dbObject.ReturnAllCompanies();
        }

    }
}