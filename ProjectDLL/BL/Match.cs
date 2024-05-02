using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDLL.BL
{
    public class Match
    {
        private string MatchName;
        private string Schedule;
        private int TotalTickets;

        public Match() { }  

        public Match(string MatchName, int TotalTickets)
        {
            this.MatchName= MatchName;
            this.TotalTickets = TotalTickets;
        }
        public Match(string matchName, string schedule, int totalTickets)
        {
            this.MatchName = matchName;
            this.Schedule = schedule;
            this.TotalTickets = totalTickets;
        }

        public Match(string MatchName)
        {
            this.MatchName = MatchName;
        }

        public void SetMatchName(string MatchName)
        {
            this.MatchName = MatchName;
        }

        public void SetSchedule(string Schedule)
        {
            this.Schedule = Schedule;
        }

        public void SetTotalTickets(int TotalTickets)
        {
            this.TotalTickets = TotalTickets;
        }

        public string GetMatchName()
        {
            return this.MatchName;
        }

        public string GetSchedule()
        {
            return this.Schedule;
        }

        public int GetTotalTickets()
        {
            return this.TotalTickets;
        }

        public new string ToString()
        {
            string Match = $"Match Name: {this.MatchName}\n   Schedule: {this.Schedule}\n   TotalTickets: {this.TotalTickets}";
            return Match;
        }
    }
}
