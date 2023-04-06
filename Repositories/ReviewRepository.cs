using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transcher.Repositories
{
    internal class ReviewRepository : dbLayer
    {
        public void createReview(Object review)
        {
            //try
            //{
            //    _conn.Open();
            //    MySqlCommand sql = new MySqlCommand(
            //        "INSERT INTO `user` (`id`, `name`, `balance`, `account_number`) VALUES (NULL, @name, '20', @accountNumber);", _conn);
            //    sql.Parameters.AddWithValue("@name", name);
            //    sql.Parameters.AddWithValue("@accountNumber", accountNumber);

            //    sql.ExecuteNonQuery();
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}
            //finally
            //{
            //    _conn.Close();
            //}
        }
    }
}
