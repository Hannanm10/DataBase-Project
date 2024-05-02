using ProjectDLL.BL;
using ProjectDLL.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDLL.DL.DB
{
    public class TicketsManagerDB
    {
        private static string connection = ConnectionString.GetConnectionString();
        public static TicketsManager CurrentUser;
        public static void SetCurrentUser(string name, string pass)
        {
            CurrentUser = new TicketsManager();

            CurrentUser.SetUsername(name);
            CurrentUser.SetPassword(pass);
            CurrentUser.SetRole("Tickets Manager");

        }
    }
}
