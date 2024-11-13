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
        private static string table = "Akun_admin";

        public static DataTable All()
        {
            string query = @"
        SELECT 
            m.id,
            m.nama,
            m.username,
            m.password";

            DataTable dataAdmin = queryExecutor(query);
            return dataAdmin;
        }

        public static DataTable getAdminById(int id)
        {
            string query = @"
                SELECT 
                    m.id,
                    m.nama,
                    m.username,
                    m.password";

            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@id", NpgsqlDbType.Integer) { Value = id }
            };

            DataTable dataAdmin = queryExecutor(query, parameters);
            return dataAdmin;
        }


        public static void AddAdmin(M_registadmin adminBaru)
        {
            string query = $"INSERT INTO {table} (nama, username, password) VALUES(@nama, @username, @password)";

            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@nama", adminBaru.nama),
                new NpgsqlParameter("@username", adminBaru.username),
                new NpgsqlParameter("@password", adminBaru.password)
            };

            commandExecutor(query, parameters);
        }

        //public static void UpdateMahasiswa(M_admin mahasiswa)
        //{
        //    string query = $"UPDATE {table} SET nama = @nama, nim = @nim, email = @email, semester = @semester, id_prodi = @id_prodi WHERE id = @id";

        //    NpgsqlParameter[] parameters =
        //    {
        //        new NpgsqlParameter("@nama", mahasiswa.nama),
        //        new NpgsqlParameter("@nim", mahasiswa.nim),
        //        new NpgsqlParameter("@email", mahasiswa.email),
        //        new NpgsqlParameter("@semester", mahasiswa.semester),
        //        new NpgsqlParameter("@id_prodi", mahasiswa.id_prodi),
        //        new NpgsqlParameter("@id", mahasiswa.id)
        //    };

        //    commandExecutor(query, parameters);
        //}

        //public static void DeleteMahasiswa(int id)
        //{
        //    string query = $"DELETE FROM {table} WHERE id = @id";

        //    NpgsqlParameter[] parameters =
        //    {
        //        new NpgsqlParameter("@id", id)
        //    };

        //    commandExecutor(query, parameters);
        //}
    }
}
