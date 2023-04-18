using Data.DTO;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Transcher.Repositories
{
    public class UserRepository : dbLayer
    {
        public bool Register(UserDTO user)
        {
            int rowsAffected = 0;
            try
            {
                MySqlCommand Cmd = new MySqlCommand("INSERT INTO USERS " +
                "(name, password, email) " +
                "VALUES(@name, @password, @email)",
                _conn);

                Cmd.Parameters.AddWithValue("@name", user.Name);
                Cmd.Parameters.AddWithValue("@password", user.Password);
                Cmd.Parameters.AddWithValue("@email", user.Email);

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

        public DataTable Login(UserDTO user)
        {
            DataTable dtData = new DataTable();
            try
            {
                _conn.Open();
                MySqlCommand command = _conn.CreateCommand();
                command.CommandText = "select * from users where email = @email";
                command.Parameters.AddWithValue("@email", user.Email);
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

        public UserDTO GetUserByEmail(UserDTO user)
        {
            DataTable dtData = new DataTable();
            try
            {
                _conn.Open();
                MySqlCommand command = _conn.CreateCommand();
                command.CommandText = "select * from users where email = @email";
                command.Parameters.AddWithValue("@email", user.Email);
                MySqlDataReader reader = command.ExecuteReader();

                dtData.Load(reader);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                _conn.Close();
            }

            return dtData;
        }
    }
}
