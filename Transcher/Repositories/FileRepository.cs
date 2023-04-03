using MySql.Data.MySqlClient;
using System;
using System.Data;
using Transcher.Classes;

namespace Transcher.Repositories
{
    internal class FileRepository : dbLayer
    {
        File uploadedFile = new();

        public bool Upload(User user, string name, string extension, string saveName, string path)
        {
            int rowsAffected = 0;
            try
            {
                MySqlCommand Cmd = new MySqlCommand("INSERT INTO FILES " +
                "(name, extension, save_name, path, created_at) " +
                "VALUES(@name, @extension, @saveName, @path, @createdAt)",
                _conn);

                Cmd.Parameters.AddWithValue("name", name);
                Cmd.Parameters.AddWithValue("@extension", extension);
                Cmd.Parameters.AddWithValue("@saveName", saveName);
                Cmd.Parameters.AddWithValue("@path", path);
                Cmd.Parameters.AddWithValue("@createdAt", DateTime.Now);

                _conn.Open();

                MySqlDataReader reader = Cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);

                foreach (DataRow row in dataTable.Rows)
                {
                    uploadedFile.SetData((int)row["id"], (string)row["name"], (string)row["extension"], (string)row["save_name"], (string)row["path"]);
                    rowsAffected++;
                }
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

            return LinkFileToUser(user);
        }

        public bool LinkFileToUser(User user)
        {
            int rowsAffected = 0;
            try
            {
                MySqlCommand Cmd = new MySqlCommand("INSERT INTO USER_HAS_FILES " +
                "(user_id, file_id) " +
                "VALUES(@userId, @fileId)",
                _conn);

                Cmd.Parameters.AddWithValue("userId", user.GetId());
                Cmd.Parameters.AddWithValue("@fileId", uploadedFile.GetId());

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

            if (rowsAffected == 0)
            {
                return false;
            }

            return true;
        }
    }
}
