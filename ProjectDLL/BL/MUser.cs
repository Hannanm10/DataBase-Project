using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDLL.BL
{
    public class MUser
    {
        protected string UserName;
        protected string Password;
        protected string UserRole;
        

        public MUser(string userName, string password, string userRole)
        {
            this.UserName = userName;
            this.Password = password;
            this.UserRole = userRole;
        }

        public MUser(string userName, string password)
        {
            this.UserName = userName;
            this.Password = password;
        }


        public MUser() { }

        public string GetUserName()
        {
            return this.UserName;
        }

        public string GetPassword()
        {
            return this.Password;
        }

        public string GetUserRole()
        {
            return this.UserRole;
        }

        
        public void SetUsername(string username)
        {
            this.UserName = username;
        }

        public void SetPassword(string password)
        {
            this.Password = password;
        }

        public void SetRole(string role)
        {
            this.UserRole = role;
        }

        
    }
}
