using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;

namespace UTS_PBO.App.Context.Admin
{
    internal class PesananAdminContext
    {
        private NpgsqlConnection conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["YourConnectionStringName"].ConnectionString);

        public DataTable GetAllReservations()
        {
            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM reservations", conn);
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public bool MakeReservation(int nomer, string nama, string makanan, string minuman, int harga, DateTime tanggal, string status)
        {
            NpgsqlCommand command = new NpgsqlCommand();
            string query = "INSERT INTO reservations (nomer_meja, nama, makanan, minuman, harga, tanggal, status) " +
                           "VALUES (@nomer_meja, @nama, @makanan, @minuman, @harga, @tanggal, @status)";
            command.CommandText = query;
            command.Connection = conn;

            command.Parameters.AddWithValue("@nomer_meja", nomer);
            command.Parameters.AddWithValue("@nama", nama);
            command.Parameters.AddWithValue("@makanan", makanan);
            command.Parameters.AddWithValue("@minuman", minuman);
            command.Parameters.AddWithValue("@harga", harga);
            command.Parameters.AddWithValue("@tanggal", tanggal);
            command.Parameters.AddWithValue("@status", status);

            conn.Open();
            bool isInserted = command.ExecuteNonQuery() == 1;
            conn.Close();
            return isInserted;
        }

        public void CancelExpiredReservations()
        {
            string query = "UPDATE reservations SET status = 'Canceled' " +
                           "WHERE tanggal < @currentDateTime AND status = 'Active'";
            NpgsqlCommand command = new NpgsqlCommand(query, conn);
            command.Parameters.AddWithValue("@currentDateTime", DateTime.Now);

            conn.Open();
            int canceledCount = command.ExecuteNonQuery();
            conn.Close();

            Console.WriteLine($"{canceledCount} expired reservations have been canceled.");
        }

        public void CheckReservationsOnAdminLogin()
        {
            CancelExpiredReservations();
        }
    }
}
