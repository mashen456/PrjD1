using PrjD1FW.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

//Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\hp - laptop\source\repos\Prj_D1\PrjD1\PrjD1FW\App_Data\DatenbankUser.mdf; Integrated Security = True

namespace PrjD1FW.Services
{
    public class DatabaseAccessObject
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hp-laptop\source\repos\Prj_D1\PrjD1\PrjD1FW\App_Data\DatenbankUser.mdf;Integrated Security=True";




        internal bool authUser(user user)
        {
            bool success = false;

            string queryString = "SELECT * FROM dbo.Users WHERE username = @Username AND password = @Password";



            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                command.Parameters.Add("@Username", System.Data.SqlDbType.VarChar, 50).Value = user.Username;
                command.Parameters.Add("@Password", System.Data.SqlDbType.VarChar, 50).Value = user.Password;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    

                    if (reader.HasRows)
                    {
                        reader.Close();
                        //command.Dispose();
                        queryString = "UPDATE dbo.Users SET lastLogin = GETDATE() where username = @Username";
                        command = new SqlCommand(queryString, connection);
                        command.Parameters.Add("@Username", System.Data.SqlDbType.VarChar, 50).Value = user.Username;
                        command.ExecuteNonQuery();


                        queryString = "UPDATE dbo.Users SET successfulLogins = successfulLogins + 1 WHERE username = @Uname";
                        command.Parameters.Add("@Uname", System.Data.SqlDbType.VarChar, 50).Value = user.Username;
                        command.ExecuteNonQuery();

                        success = true;
                    }
                    else
                    {
                        success = false;

                    }
                    connection.Close();

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return success;
        }

    }
}