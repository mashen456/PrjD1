﻿using PrjD1FW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrjD1FW.Services
{
    public class SecurityService
    {
        DatabaseAccessObject dbObject = new DatabaseAccessObject();

        public bool Auth(user user)
        {
            return dbObject.authUser(user);
        }
    }
}