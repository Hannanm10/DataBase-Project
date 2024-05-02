using ProjectDLL.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDLL.DLInterfaces
{
    public interface IMUserDL
    {
        bool Save(MUser user);

        string SignIn(MUser user);

        void SetUser(MUser user);

        bool UpdatePassword(string newPassword);

        int GetUserID(string UserName, string Password);
    }
}
