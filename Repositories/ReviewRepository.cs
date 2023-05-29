using Domain.Interfaces;
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
    public class ReviewRepository : dbLayer, IReview
    {
        public bool PublishReview(Review review)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("INSERT INTO FILE_HAS_REVIEWS " +
                "(user_id, file_id, header, text, rating, created_at) " +
                "VALUES(@user_id, @file_id, @header, @text, @rating, @created_at)",
                _conn);

                cmd.Parameters.AddWithValue("@user_id", review.GetUserId());
                cmd.Parameters.AddWithValue("@file_id", review.GetFileId());
                cmd.Parameters.AddWithValue("@header", review.Header);
                cmd.Parameters.AddWithValue("@text", review.Comment);
                cmd.Parameters.AddWithValue("@rating", review._Rating);
                cmd.Parameters.AddWithValue("@created_at", review.GetCreationDate());

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

            review = RetrieveCreatedReview(review);

            if (review != null)
            {
                return true;
            }

            return false;
        }

        public Review RetrieveCreatedReview(Review review)
        {
            DataTable dtData = new DataTable();
            try
            {
                _conn.Open();
                MySqlCommand cmd = _conn.CreateCommand();
                cmd.CommandText = "select * from FILE_HAS_REVIEWS where user_id = @user_id and file_id = @file_id and header = @header and text = @text and rating = @rating ORDER BY created_at DESC limit 1";

                cmd.Parameters.AddWithValue("@user_id", review.GetUserId());
                cmd.Parameters.AddWithValue("@file_id", review.GetFileId());
                cmd.Parameters.AddWithValue("@header", review.Header);
                cmd.Parameters.AddWithValue("@text", review.Comment);
                cmd.Parameters.AddWithValue("@rating", review._Rating);

                MySqlDataReader reader = cmd.ExecuteReader();

                dtData.Load(reader);

                foreach (DataRow row in dtData.Rows)
                {
                    review.Id = (int)row["id"];
                }

            }
            catch (Exception)
            {
            }
            finally
            {
                _conn.Close();
            }

            return review;
        }
    }
}
