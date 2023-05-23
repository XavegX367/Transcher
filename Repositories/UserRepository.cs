using Domain.Interfaces;
using MySql.Data.MySqlClient;
using System.Data;
using Transcher.Classes;

namespace Transcher.Repositories
{
    public class UserRepository : dbLayer, IUser
    {
        public bool Register(User user)
        {
            int rowsAffected = 0;
            try
            {
                MySqlCommand Cmd = new MySqlCommand("INSERT INTO USERS " +
                "(name, password, email) " +
                "VALUES(@name, @password, @email)",
                _conn);

                Cmd.Parameters.AddWithValue("@name", user.Name);
                Cmd.Parameters.AddWithValue("@password", user.GetPassword());
                Cmd.Parameters.AddWithValue("@email", user.GetEmail());

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

        public DataTable Login(User user)
        {
            DataTable dtData = new DataTable();
            try
            {
                _conn.Open();
                MySqlCommand command = _conn.CreateCommand();
                command.CommandText = "select * from users where email = @email";
                command.Parameters.AddWithValue("@email", user.GetEmail());
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

        public User GetUserByEmail(User user)
        {
            DataTable dtData = new DataTable();
            try
            {
                _conn.Open();
                MySqlCommand command = _conn.CreateCommand();
                command.CommandText = "select * from users where email = @email";
                command.Parameters.AddWithValue("@email", user.GetEmail());
                MySqlDataReader reader = command.ExecuteReader();

                dtData.Load(reader);

                foreach (DataRow row in dtData.Rows)
                {
                    user.Id = (int)row["id"];
                    user.SetEmail((string)row["email"]);
                    user.Name = (string)row["name"];
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _conn.Close();
            }

            return user;
        }
    }
}
