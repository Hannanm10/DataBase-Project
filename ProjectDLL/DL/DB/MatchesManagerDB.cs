using ProjectDLL.BL;
using ProjectDLL.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDLL.DL.DB
{
    public class MatchesManagerDB
    {
        private static string connection = ConnectionString.GetConnectionString();
        public static MatchesManager CurrentUser;
        public static void SetCurrentUser(string name, string pass)
        {
            CurrentUser = new MatchesManager();

            CurrentUser.SetUsername(name);
            CurrentUser.SetPassword(pass);
            CurrentUser.SetRole("Matches Manager");

        }
    }
}
