using ProjectDLL.BL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDLL.DLInterfaces
{
    public interface ITicketDL
    {
        List<Ticket> GetAllTickets();

        //bool AddTicketsToMatch(string MatchName, int Tickets);

        //bool RemoveTicketsFromMatch(string MatchName, int Tickets);

        List<string> GetTicketNames();

        bool UpdatePrice(Ticket ticket);

        double GetTicketPrice(string typename, SqlConnection sqlConnection);
    }
}
