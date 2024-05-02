using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDLL.BL
{
    public class MatchesManager : MUser
    {
        public MatchesManager() { }

        public MatchesManager(string name, string pass) : base(name, pass) { }

        public MatchesManager(string name, string pass, string role) : base(name, pass, role) { }
    }
}
