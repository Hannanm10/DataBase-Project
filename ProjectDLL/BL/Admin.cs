using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDLL.BL
{
    public class Admin : MUser
    {
        public Admin() { }

        public Admin(string name, string pass) : base(name, pass) { }
        
        public Admin(string name, string pass, string role) : base(name, pass, role) { }

    }
}
