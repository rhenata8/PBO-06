using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTS_PBO.App.Core;
using System.Configuration;
using NpgsqlTypes;
using UTS_PBO.App.Model;
using Npgsql;
using UTS_PBO.App.Model.M_Admin;
using System.Data;

namespace UTS_PBO.App.Context.Admin
{
    internal class DataMejaContext : Database_admin
    {
        private static string table = "Data_Meja";

        public static DataTable All()
        {
            string query = @"
                SELECT 
                    m.id,
                    m.Nomor_meja,
                    m.Kapasitas,
                    m.Lantai,
                    m.Status
                FROM data_meja m";

            return queryExecutor(query);
        }

        public static DataTable Getdata_mejaById(int id)
        {
            string query = @"
                SELECT 
                    m.id,
                    m.Nomor_meja,
                    m.Kapasitas,
                    m.Lantai,
                    m.Status
                FROM data_meja m
                WHERE m.id = @id";

            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@id", NpgsqlDbType.Integer) { Value = id }
            };

            return queryExecutor(query, parameters);
        }

        public static void AddMeja(M_DataMeja mejaBaru)
        {
            string query = $@"
                INSERT INTO {table} (Nomor_meja, Kapasitas, Lantai, Status) 
                VALUES (@Nomor_meja, @Kapasitas, @Lantai, @Status)";

            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@Nomor_meja", mejaBaru.Nomor_meja ),
                new NpgsqlParameter("@Kapasitas", mejaBaru.Kapasitas ),
                new NpgsqlParameter("@Lantai", mejaBaru.Lantai ),
                new NpgsqlParameter("@Status",  mejaBaru.Status ),
            };

            commandExecutor(query, parameters);
        }

        public static void UpdateMeja(M_DataMeja meja)
        {
            string query = $@"
                UPDATE {table} 
                SET Nomor_meja = @Nomor_meja, 
                    Kapasitas = @Kapasitas, 
                    Lantai = @Lantai, 
                    Status = @Status, 
                WHERE id = @id";

            NpgsqlParameter[] parameters =
            {
               new NpgsqlParameter("@Nomor_meja", meja.Nomor_meja ),
                new NpgsqlParameter("@Kapasitas", meja.Kapasitas ),
                new NpgsqlParameter("@Lantai", meja.Lantai ),
                new NpgsqlParameter("@Status",  meja.Status ),
            };

            commandExecutor(query, parameters);
        }

        public static void DeleteMeja(int id)
        {
            string query = $"DELETE FROM {table} WHERE id = @id";

            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@id", id)
            };

            commandExecutor(query, parameters);
        }
    }
}
