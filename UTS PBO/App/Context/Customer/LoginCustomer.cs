using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTS_PBO.App.Context.Customer
{
    internal class LoginCustomer
    {
         internal class CustomerAdContext : Database_customer
 {
     private static string table = "Customer";

     public static bool ValidateLogin(string username, string password)
     {
         string query = @"
             SELECT 
             id, 
             username, 
             password 
             FROM " + table + @" 
             WHERE username = @username 
             AND password = @password";

         NpgsqlParameter[] parameters =
         {
             new NpgsqlParameter("@username", NpgsqlDbType.Varchar) { Value = username },
             new NpgsqlParameter("@password", NpgsqlDbType.Varchar) { Value = password }
         };

         try
         {
             using (DataTable data = queryExecutor(query, parameters))
             {
                 return data.Rows.Count > 0;
             }
         }
         catch (Exception ex)
         {
             throw new Exception("Error saat validasi login: " + ex.Message);
         }
     }

     private static DataTable queryExecutor(string query, NpgsqlParameter[] parameters)
     {
         throw new NotImplementedException();
     }
 }
    }
}
