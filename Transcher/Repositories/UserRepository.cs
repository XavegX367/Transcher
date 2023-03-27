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
    internal class UserRepository : dbLayer
    {
        public void Register(string name, string password, string email)
        {
            password = password + "$Y.N3T~J*";
            string salt = BCrypt.Net.BCrypt.GenerateSalt();
            string encrypted = BCrypt.Net.BCrypt.HashPassword(password, salt);
            try
            {
                MySqlCommand Cmd = new MySqlCommand("INSERT INTO [USERS] " +
                "(name, password, email) " +
                "VALUES(@name, @password, @email)",
                _conn);

                Cmd.Parameters.AddWithValue("@name", name);
                Cmd.Parameters.AddWithValue("@password", encrypted);
                Cmd.Parameters.AddWithValue("@email", email);

                _conn.Open();

                int RowsAffected = Cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
            }
            finally
            {
                _conn.Close();
            }
        }

        public bool Login(string password, string email)
        {
            DataTable dtData = new DataTable();
            try
            {
                _conn.Open();
                MySqlCommand command = _conn.CreateCommand();
                command.CommandText = "select * from users where email = @email";
                command.Parameters.AddWithValue("@email", email);
                MySqlDataReader reader = command.ExecuteReader();

                dtData.Load(reader);
            }
            catch (Exception)
            {
            }
            finally
            {
                _conn.Close();
            }

            foreach (DataRow row in dtData.Rows)
            {
                string storedHashInDatabase = row["password"].ToString();
                password = password + "$Y.N3T~J*";
                bool doesPasswordMatch = BCrypt.Net.BCrypt.Verify(password, storedHashInDatabase);

                if (doesPasswordMatch)
                {
                    return true;
                }
            }

            return false;
        }

        public List<User> getUsers()
        {
            List<User> users = new List<User>();

            try
            {
                // Connect to the database
                _conn.Open();

                // Create the SQL command
                MySqlCommand sql = new MySqlCommand(
                    "SELECT id, email, name, role FROM `users`", _conn);

                // Execute Command
                MySqlDataReader reader = sql.ExecuteReader();

                // Load results into datatable
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);

                // Add results to list
                foreach (DataRow row in dataTable.Rows)
                {
                    users.Add(new User()
                    {
                        Id = (int)row["id"],
                        Email = (string)row["email"],
                        Name = (string)row["name"],
                        Role = (string)row["role"],
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

            return users;
        }
    }
}
