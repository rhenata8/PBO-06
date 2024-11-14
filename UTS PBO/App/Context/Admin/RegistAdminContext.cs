using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTS_PBO.App.Core;
using UTS_PBO.App.Model;

namespace UTS_PBO.App.Context.Admin
{
    internal class RegistAdminContext : Database_admin
    {
        private static string table = "Admin";

        public static void AddAdmin(M_registadmin adminBaru)
        {
            string query = $@"
                INSERT INTO {table} (nama, username, password, no_telp, email) 
                VALUES (@nama, @username, @password, @no_telp, @email)";

            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@nama", adminBaru.nama ),
                new NpgsqlParameter("@username", adminBaru.username ),
                new NpgsqlParameter("@password", adminBaru.password ),
                new NpgsqlParameter("@no_telp",  adminBaru.no_telp ),
                new NpgsqlParameter("@email", adminBaru.email )
            };

            commandExecutor(query, parameters);
        }

        public static void UpdateAdmin(M_registadmin admin)
        {
            string query = $@"
                UPDATE {table} 
                SET nama = @nama, 
                    username = @username, 
                    email = @email, 
                    password = @password, 
                    no_telp = @no_telp 
                WHERE id = @id";

            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@nama", admin.nama ),
                new NpgsqlParameter("@username", admin.username ),
                new NpgsqlParameter("@password", admin.password ),
                new NpgsqlParameter("@no_telp",  admin.no_telp ),
                new NpgsqlParameter("@email", admin.email )
            };

            commandExecutor(query, parameters);
        }


    }
}
