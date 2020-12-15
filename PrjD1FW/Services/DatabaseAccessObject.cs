using PrjD1FW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrjD1FW.Services
{
    public class DatabaseAccessObject
    {
        internal bool authUser(user user)
        {
            return (user.Username == "Admin" && user.Password == "123");
        }
    }
}