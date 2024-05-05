using ProjectDLL.DL.DB;
using ProjectDLL.DL.FH;
using ProjectDLL.DLInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WindowFormsProject
{
    internal class ObjectHandler
    {
        private static IMUserDL MUserDL = new MUserDB();
        private static ICustomerDL CustomerDL = new CustomerDB();
        private static IAdminDL AdminDL = new AdminDB();
        private static ITicketDL TicketDL = new TicketDB();
        private static IMatchDL MatchDL = new MatchDB();
        //private static IMatchDL MatchDL = new MatchFH();

        public static IMUserDL GetMUserDL() { return MUserDL; }

        public static ICustomerDL GetCustomerDL() {  return CustomerDL; }

        public static IAdminDL GetAdminDL() {  return AdminDL; }

        public static ITicketDL GetTicketDL() {  return TicketDL; }

        public static IMatchDL GetMatchDL() { return MatchDL; }
    }
}
