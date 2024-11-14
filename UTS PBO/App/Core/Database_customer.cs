using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTS_PBO.App.Core
{
    internal class Database_customer
    {
         private static readonly string DB_HOST = "localhost";
 private static readonly string DB_DATABASE = "UAS PBO";
 private static readonly string DB_USERNAME = "postgres";
 private static readonly string DB_PASSWORD = "1";
 private static readonly string DB_PORT = "5432";

 private static NpgsqlConnection connection;

 public static void openConnection()
 {
     connection = new NpgsqlConnection($"Host={DB_HOST};Username={DB_USERNAME};Password={DB_PASSWORD};Database={DB_DATABASE};Port={DB_PORT}");
     connection.Open();
 }

 public static void closeConnection()
 {
     connection.Close();
 }

 public static DataTable queryExecutor(string query, NpgsqlParameter[] parameters = null)
 {
     try
     {
         openConnection();
         using (var command = new NpgsqlCommand(query, connection))
         {
             if (parameters != null)
             {
                 command.Parameters.AddRange(parameters);
             }

             using (NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(command))
             {
                 DataTable dataTable = new DataTable();
                 dataAdapter.Fill(dataTable);
                 return dataTable;
             }
         }
     }
     catch (Exception e)
     {
         throw new Exception(e.Message);
     }
     finally
     {
         closeConnection();
     }
 }

 public static void commandExecutor(string query, NpgsqlParameter[] parameters = null)
 {
     try
     {
         openConnection();
         using (var command = new NpgsqlCommand(query, connection))
         {
             if (parameters != null)
             {
                 command.Parameters.AddRange(parameters);
             }
             command.ExecuteNonQuery();
         }
     }
     catch (Exception e)
     {
         throw new Exception(e.Message);
     }
     finally
     {
         closeConnection();
     }
    }
}
