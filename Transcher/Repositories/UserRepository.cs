using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transcher.Classes;

namespace Transcher.Repositories
{
    internal class UserRepository
    {
        MySqlConnection _conn;

        public UserRepository()
        {
            _conn = new MySqlConnection
                (
                $"Server=localhost;" +
                 $"Database=transcher;" +
                 $"Uid=root;" +
                 $"Pwd=;"
                );
        }

        public List<User> getUsers()
        {
            List<User> result = new List<User>();

            try
            {
                // Connect to the database
                _conn.Open();

                // Create the SQL command
                MySqlCommand sql = new MySqlCommand(
                    "SELECT * FROM `user`", _conn);

                // Execute Command
                MySqlDataReader reader = sql.ExecuteReader();

                // Load results into datatable
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);

                // Add results to list
                foreach (DataRow row in dataTable.Rows)
                {
                    result.Add(new User()
                    {
                        Id = (int)row["Id"],
                        Email = (string)row["Email"],
                        Name = (string)row["Name"],
                        Role = (string)row["Role"],
                    });
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                _conn.Close();
            }

            return result;
        }
    }
}
