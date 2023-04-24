using Data.DTO;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Data;
using System.Xml.Linq;

namespace Transcher.Repositories
{
    public class FileRepository : dbLayer
    {
        public FileDTO Upload(FileDTO file)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("INSERT INTO FILES " +
                "(name, extension, user_id, created_at, downloads) " +
                "VALUES(@name, @extension, @user_id, @created_at, @downloads)",
                _conn);

                cmd.Parameters.AddWithValue("@name", file.Name);
                cmd.Parameters.AddWithValue("@extension", file.Extension);
                cmd.Parameters.AddWithValue("@user_id", file.UserId);
                cmd.Parameters.AddWithValue("@created_at", file.CreatedAt);
                cmd.Parameters.AddWithValue("@downloads", file.Downloads);

                _conn.Open();

                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
            }
            finally
            {
                _conn.Close();
            }

            file = RetrieveCreatedFile(file);

            return file;
        }

        public FileDTO RetrieveCreatedFile(FileDTO file)
        {
            DataTable dtData = new DataTable();
            try
            {
                _conn.Open();
                MySqlCommand cmd = _conn.CreateCommand();
                cmd.CommandText = "select * from FILES where name = @name and extension = @extension and user_id = @user_id and downloads = @downloads ORDER BY created_at DESC limit 1";

                cmd.Parameters.AddWithValue("@name", file.Name);
                cmd.Parameters.AddWithValue("@extension", file.Extension);
                cmd.Parameters.AddWithValue("@user_id", file.UserId);
                cmd.Parameters.AddWithValue("@created_at", file.CreatedAt);
                cmd.Parameters.AddWithValue("@downloads", file.Downloads);

                MySqlDataReader reader = cmd.ExecuteReader();

                dtData.Load(reader);

                foreach (DataRow row in dtData.Rows)
                {
                    file.Id = (int)row["id"];
                }

            }
            catch (Exception)
            {
            }
            finally
            {
                _conn.Close();
            }

            return file;
        }

        public List<FileDTO> RetrieveFiles()
        {
            DataTable dtData = new DataTable();
            List<FileDTO> files = new List<FileDTO>();
            try
            {
                _conn.Open();
                MySqlCommand cmd = _conn.CreateCommand();
                cmd.CommandText = "SELECT files.id, files.name, files.extension, files.created_at, files.user_id, files.downloads, count(file_has_reviews.id) as amount_of_reviews FROM `files` left join file_has_reviews on file_has_reviews.file_id = files.id GROUP BY files.id";

                MySqlDataReader reader = cmd.ExecuteReader();

                dtData.Load(reader);

                foreach (DataRow row in dtData.Rows)
                {
                    FileDTO file = new FileDTO();
                    file.Id = (int)row["id"];
                    file.Name = (string)row["name"];
                    file.Extension = (string)row["extension"];
                    file.Downloads = (int)row["downloads"];
                    file.UserId = (int)row["user_id"];
                    file.CreatedAt = (DateTime)row["created_at"];
                    file.AmountOfReviews = (int)(Int64)row["amount_of_reviews"];

                    files.Add(file);
                }

            }
            catch (Exception)
            {
            }
            finally
            {
                _conn.Close();
            }

            return files;
        }
    }
}
