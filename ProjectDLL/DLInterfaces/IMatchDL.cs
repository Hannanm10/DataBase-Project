using ProjectDLL.BL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDLL.DLInterfaces
{
    public interface IMatchDL
    {
        List<Match> GetAllMatches();

        List<string> GetAllMatchesNames();

        bool Save(Match match);

        bool Delete(Match match);

        int GetTotalTickets(string match);

        void RemoveTickets(string match, int oldQuantity, int Reduce);

        bool AddTicketsToMatch(Match match);

        bool RemoveTicketsFromMatch(Match match);
    }
}
