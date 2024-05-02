using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDLL.BL
{
    public class TicketsManager : MUser
    {
        public TicketsManager() { }

        public TicketsManager(string name, string pass) : base(name, pass) { }

        public TicketsManager(string name, string pass, string role) : base(name, pass, role) { }
    }
}
