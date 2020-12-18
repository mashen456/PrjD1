using PrjD1FW.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using CryptoHelper;

//Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\hp - laptop\source\repos\Prj_D1\PrjD1\PrjD1FW\App_Data\DatenbankUser.mdf; Integrated Security = True

namespace PrjD1FW.Services
{
    public class DatabaseAccessObject
    {
        logger log = new logger();
        string connectionString = @"Data Source=tcp:danielprj1.database.windows.net,1433;Initial Catalog=userdb;User Id=danielWebApp@danielprj1;Password=E@c%%xP#TiE8";


        
        internal bool AuthUser(user user)
        {
            bool success = false;

            string queryString = "SELECT * FROM [dbo].[Table] WHERE username = @Username AND password = @Password";



            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                log.Info("auth: " + user.Username);
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
                        //Care! NULL not handled! 
                        IterateFailedLoginCount(user);
                    }

                    

                }
                catch (Exception e)
                {
                    //return user not found in DB
                    log.Error(e.Message);
                }
                connection.Close();
            }
            
            return success;
        }

        internal bool RegisterUser(user user)
        {
            bool success = false;
            string queryString = "INSERT INTO [dbo].[Table] (username, password) VALUES (@Username,@Password)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                command.Parameters.Add("@Username", System.Data.SqlDbType.VarChar, 50).Value = user.Username;
                command.Parameters.Add("@Password", System.Data.SqlDbType.VarChar, 50).Value = HashPassword(user.Password);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    success = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                connection.Close();
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



        // Hash a password
        public string HashPassword(string password)
        {
            return Crypto.HashPassword(password);
        }

        // Verify the password hash against the given password
        public bool VerifyPassword(string hash, string password)
        {
            return Crypto.VerifyHashedPassword(hash, password);
        }

}
}


//reader.Read();

//var test = reader["id"];
//reader.Close();
