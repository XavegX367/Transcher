using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Transcher.Repositories
{
    internal class UserRepository : dbLayer
    {
        public bool Register(string name, string encrypted, string email)
        {
            int rowsAffected = 0;

            try
            {
                MySqlCommand Cmd = new MySqlCommand("INSERT INTO USERS " +
                "(name, password, email) " +
                "VALUES(@name, @password, @email)",
                _conn);

                Cmd.Parameters.AddWithValue("@name", name);
                Cmd.Parameters.AddWithValue("@password", encrypted);
                Cmd.Parameters.AddWithValue("@email", email);

                _conn.Open();

                rowsAffected = Cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
            }
            finally
            {
                _conn.Close();
            }

            if(rowsAffected == 0)
            {
                return false;
            }

            return true;
        }

        public DataTable Login(string password, string email)
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

            return dtData;
        }
    }
}
