using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transcher.Repositories
{
    public class dbLayer
    {
        public MySqlConnection _conn;
        public dbLayer()
        {
            _conn = new MySqlConnection
            (
            $"Server=localhost;" +
                $"Database=transcher;" +
                $"Uid=root;" +
                $"Pwd=;"
            );
        }
    }
}
