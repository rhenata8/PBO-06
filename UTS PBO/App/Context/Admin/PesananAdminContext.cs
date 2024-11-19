using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTS_PBO.App.Context.Admin
{
    internal class PesananAdminContext
    {
         private NpgsqlConnection conn = new NpgsqlConnection();

 public DataTable GetAllReservations()
 {
     NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM reservations", conn.GetConnection());
     NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);
     DataTable table = new DataTable();
     adapter.Fill(table);
     return table;
 }

 public bool MakeReservation(int nomer, string nama, string makanan, string minuman, int harga, DateTime tanggal, Enum status)
 {
     NpgsqlCommand command = new NpgsqlCommand();
     string query = "INSERT INTO reservations (nomer_meja, nama, makanan, minuman, harga, tanggal, status) " +
                    "VALUES (@nomer_meja, @nama, @makanan, @minuman, @harga, @tanggal, 'Active')";
     command.CommandText = query;
     command.Connection = conn.GetConnection();

     command.Parameters.AddWithValue("@nomer_meja", nomer);
     command.Parameters.AddWithValue("@nama", nama);
     command.Parameters.AddWithValue("@makanan", makanan);
     command.Parameters.AddWithValue("@minuman", minuman);
     command.Parameters.AddWithValue("@harga", harga);
     command.Parameters.AddWithValue("@tanggal", tanggal);
     command.Parameters.AddWithValue("@status", status);

     conn.OpenConnection();
     bool isInserted = command.ExecuteNonQuery() == 1;
     conn.CloseConnection();
     return isInserted;
 }

 public void CancelExpiredReservations()
 {
     string query = "UPDATE reservations SET status = 'Canceled' " +
                    "WHERE date_out < @currentDateTime AND status = 'Active'";
     NpgsqlCommand command = new NpgsqlCommand(query, conn.GetConnection());
     command.Parameters.AddWithValue("@currentDateTime", DateTime.Now);

     conn.OpenConnection();
     int canceledCount = command.ExecuteNonQuery();
     conn.CloseConnection();

     Console.WriteLine($"{canceledCount} expired reservations have been canceled.");
 }

 public void CheckReservationsOnAdminLogin()
 {
     CancelExpiredReservations();
 }
    }
}
