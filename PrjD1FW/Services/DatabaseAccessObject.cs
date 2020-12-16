using PrjD1FW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\hp - laptop\source\repos\Prj_D1\PrjD1\PrjD1FW\App_Data\DatenbankUser.mdf; Integrated Security = True

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