using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PrjD1FW.Controllers
{
    public class errorController : Controller
    {
        // GET: error

        public string Index()
        {
            return "1337";
        }

        public string notAuthenticated()
        {
            return "notAuthenticated";
        }


    }
}