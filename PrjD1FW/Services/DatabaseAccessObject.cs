using PrjD1FW.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;

//Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\hp - laptop\source\repos\Prj_D1\PrjD1\PrjD1FW\App_Data\DatenbankUser.mdf; Integrated Security = True

namespace PrjD1FW.Services
{
    public class DatabaseAccessObject
    {
        //string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hp-laptop\source\repos\Prj_D1\PrjD1\PrjD1FW\App_Data\DatenbankUser.mdf;Integrated Security=True";
        //string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\wuat\source\repos\mashen456\PrjD1\PrjD1FW\App_Data\DatenbankUser.mdf;Integrated Security=True";
        //string connectionString = @"Data Source=danielprj1.database.windows.net;Initial Catalog=userdb;User ID=danielWebApp;Password=E@c%%xP#TiE8;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        string connectionString = @"Data Source=tcp:danielprj1.database.windows.net,1433;Initial Catalog=userdb;User Id=danielWebApp@danielprj1;Password=E@c%%xP#TiE8";

        string test = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);

        
        internal bool AuthUser(user user)
        {
            bool success = false;

            string queryString = "SELECT * FROM [dbo].[Table] WHERE username = @Username AND password = @Password";



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
                        success = IterateLoginCount(user);
                    }
                    else
                    {
                        IterateFailedLoginCount(user);
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



        //Helper Functions

        internal bool IterateLoginCount(user user)
        {
            bool success = false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    try
                    {
                        command.CommandText = "UPDATE [dbo].[Table] SET lastLogin = GETDATE() where username = @Username";
                        command.Parameters.Add("@Username", System.Data.SqlDbType.VarChar, 50).Value = user.Username;
                        command.ExecuteNonQuery();

                        command.CommandText = "UPDATE[dbo].[Table] SET successfulLogins = successfulLogins + 1 WHERE username = @Username";
                        command.ExecuteNonQuery();
                        success = true;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        success = false;
                    }


                }
                return success;
            }
        }

        internal bool IterateFailedLoginCount(user user)
        {
            bool success = false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    try
                    {
                        command.CommandText = "UPDATE[dbo].[Table] SET failedLogins = failedLogins + 1 WHERE username = @Username";
                        command.Parameters.Add("@Username", System.Data.SqlDbType.VarChar, 50).Value = user.Username;
                        command.ExecuteNonQuery();
                        success = true;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        success = false;
                    }


                }
                return success;
            }
        }

    }
}


//reader.Read();

//var test = reader["id"];
//reader.Close();
