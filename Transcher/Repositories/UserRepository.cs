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

        public User Login(string password, string email)
        {
            User user = new User();

            try
            {
                // Open connectie
                _conn.Open();

                // Maak SQL command aan
                MySqlCommand sql = new MySqlCommand(
                    "SELECT id, email, name, role FROM `users` WHERE password = @password AND email = @email", _conn);
                sql.Parameters.AddWithValue("@password", password);
                sql.Parameters.AddWithValue("@email", email);

                // Voer SQL command uit
                MySqlDataReader reader = sql.ExecuteReader();

                // Stopt result in een datatable
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);

                // Voeg resultaten toe in een account
                foreach (DataRow row in dataTable.Rows)
                {
                    user.Id = (int)row["id"];
                    user.Name = (string)row["name"];
                    user.Email = (string)row["email"];
                    user.Role = (string)row["role"];
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

            return user;
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
