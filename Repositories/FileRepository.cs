using Domain.Interfaces;
using MySql.Data.MySqlClient;
using System.Data;

namespace Transcher.Repositories
{
    public class FileRepository : dbLayer, IFile
    {
        public Classes.File Upload(Classes.File file)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("INSERT INTO FILES " +
                "(name, extension, user_id, created_at, downloads) " +
                "VALUES(@name, @extension, @user_id, @created_at, @downloads)",
                _conn);

                cmd.Parameters.AddWithValue("@name", file.Name);
                cmd.Parameters.AddWithValue("@extension", file.Extension);
                cmd.Parameters.AddWithValue("@user_id", file.GetUserId());
                cmd.Parameters.AddWithValue("@created_at", file.GetCreationDate());
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

        public Classes.File RetrieveCreatedFile(Classes.File file)
        {
            DataTable dtData = new DataTable();
            try
            {
                _conn.Open();
                MySqlCommand cmd = _conn.CreateCommand();
                cmd.CommandText = "select * from FILES where name = @name and extension = @extension and user_id = @user_id and downloads = @downloads ORDER BY created_at DESC limit 1";

                cmd.Parameters.AddWithValue("@name", file.Name);
                cmd.Parameters.AddWithValue("@extension", file.Extension);
                cmd.Parameters.AddWithValue("@user_id", file.GetUserId());
                cmd.Parameters.AddWithValue("@created_at", file.GetCreationDate());
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

        public List<Classes.File> RetrieveFiles()
        {
            DataTable dtData = new DataTable();
            List<Classes.File> files = new List<Classes.File>();
            try
            {
                _conn.Open();
                MySqlCommand cmd = _conn.CreateCommand();
                cmd.CommandText = "SELECT files.id, files.name, files.extension, files.created_at, files.user_id, files.downloads, count(file_has_reviews.id) as amount_of_reviews FROM `files` left join file_has_reviews on file_has_reviews.file_id = files.id GROUP BY files.id";

                MySqlDataReader reader = cmd.ExecuteReader();

                dtData.Load(reader);

                foreach (DataRow row in dtData.Rows)
                {
                    // ToDo: Add constructor so we don't need to do everything seperated
                    Classes.File file = new Classes.File();
                    file.SetData(
                        (int)row["id"],
                        (string)row["name"],
                        (string)row["extension"],
                        (int)row["downloads"],
                        (DateTime)row["created_at"],
                        (int)row["user_id"],
                        (int)(Int64)row["amount_of_reviews"]
                    );

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
