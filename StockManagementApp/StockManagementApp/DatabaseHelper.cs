using System.Data;
using MySql.Data.MySqlClient;

namespace StockManagementApp
{
    public class DatabaseHelper
    {
        private string connectionString = "Server=localhost;Database=StockManagement;Uid=root;Pwd=A.b.k.2808;";

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        public DataTable ExecuteQuery(string query)
        {
            DataTable table = new DataTable();
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(table);
                    }
                }
            }
            return table;
        }

        public int ExecuteNonQuery(string query)
        {
            int rowsAffected;
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    rowsAffected = command.ExecuteNonQuery();
                }
            }
            return rowsAffected;
        }
    }
}
