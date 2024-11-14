using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTS_PBO.App.Core;
using System.Configuration;
using NpgsqlTypes;
using UTS_PBO.App.Model;


namespace UTS_PBO.App.Context.Admin
{
    internal class LoginAdminContext : Database_admin
    {
        private static string table = "Admin";

        public static bool ValidateLogin(string username, string password)
        {
            string query = @"
                SELECT id, username, password 
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

    }
}

