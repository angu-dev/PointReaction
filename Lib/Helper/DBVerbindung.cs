using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Helper
{
    public class DBVerbindung
    {
        public static SqlConnection GetDBVerbindung()
        {
            return new SqlConnection(@"Server=192.168.2.210;Database=PointReaction;User Id=sa;Password = 123456; ");
        }
    }
}
