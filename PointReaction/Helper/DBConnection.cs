using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace PointReaction.Helper
{
    public class DBConnection
    {
        public static SqlConnection GetDBConnection()
        {
            return new SqlConnection(@"Server=192.168.2.210;Database=PointReaction;User Id=sa;Password = 123456; ");
        }
    }
}