using System;
using System.Collections.Generic;
using System.Data;
using Npgsql; 

namespace UTS_PBO.App.Context.Admin
{
    internal class RiwayatAdminContext
    {
        private readonly string connectionString;

        public RiwayatAdminContext()
        {
            connectionString = "Host=localhost;Port=5432;Username=postgres;Password=venyra;Database=pbo_projek;";
        }

        public DataTable GetAllReservations()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT id, nomor_meja, tanggal, nama_customer, makanan, minuman, harga, status FROM reservations;";
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, connection);

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                return dt;
            }
        }

        public bool CancelReservation(int reservationId)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE reservations SET status = 'Canceled' WHERE id = @reservationId;";
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@reservationId", reservationId);

                    int affectedRows = cmd.ExecuteNonQuery();
                    return affectedRows > 0;
                }
            }
        }

        public DataTable SearchReservations(string keyword)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string query = @"SELECT id, nomor_meja, tanggal, nama_customer, makanan, minuman, harga, status 
                                 FROM reservations 
                                 WHERE LOWER(nama_customer) LIKE @keyword OR CAST(nomor_meja AS TEXT) LIKE @keyword;";
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@keyword", $"%{keyword.ToLower()}%");

                    NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    return dt;
                }
            }
        }

        public DataTable RefreshReservations()
        {
            return GetAllReservations();
        }
    }
}
