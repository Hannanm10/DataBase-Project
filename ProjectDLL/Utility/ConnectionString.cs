using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDLL.Utility
{
    internal class ConnectionString
    {
        public static string connection = "Data Source=DESKTOP-NLQHPI9;Initial Catalog=StadiumManagement;Integrated Security=True";

        public static string GetConnectionString()
        {
            return connection;
        }
    }
}
