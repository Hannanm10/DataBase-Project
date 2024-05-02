using ProjectDLL.BL;
using ProjectDLL.DLInterfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDLL.DL.FH
{
    public class MatchFH : IMatchDL
    {
        private static List<Match> Matches = new List<Match>();
        private static string FileName = "Matches.txt";

        public MatchFH()
        {
            if (ReadDataFromFile())
            {
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Data Loading Failed");
            }
        }
        public bool AddTicketsToMatch(Match match)
        {
            try
            {
                int OldTickets = GetTotalTickets(match.GetMatchName());

                foreach (Match m in Matches)
                {
                    if (m.GetMatchName() == match.GetMatchName())
                    {
                        m.SetTotalTickets(OldTickets + match.GetTotalTickets());

                        WriteAllDataInFile();

                        break;
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(Match match)
        {
            foreach (Match m in Matches)
            {
                if (m.GetMatchName() == match.GetMatchName())
                {
                    Matches.Remove(m);

                    WriteAllDataInFile();

                    return true;
                }
            }
            return false;
        }

        public List<Match> GetAllMatches()
        {
            return Matches;
        }

        public List<string> GetAllMatchesNames()
        {
            List<string> Names = new List<string>();
            foreach (Match match in Matches)
            {
                Names.Add(match.GetMatchName());
            }
            return Names;
        }

        public int GetTotalTickets(string match)
        {
            foreach(Match m in Matches)
            {
                if (m.GetMatchName() == match)
                {
                    return m.GetTotalTickets();
                }
            }
            return 0;
        }

        public void RemoveTickets(string match, int oldQuantity, int Reduce)
        {
            foreach (Match m in Matches)
            {
                if (m.GetMatchName() == match)
                {
                    m.SetTotalTickets(oldQuantity - Reduce);
                }
            }
        }

        public bool RemoveTicketsFromMatch(Match match)
        {
            try
            {
                int OldTickets = GetTotalTickets(match.GetMatchName());

                RemoveTickets(match.GetMatchName(), OldTickets, match.GetTotalTickets());

                WriteAllDataInFile();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Save(Match match)
        {
            try
            {
                Matches.Add(match);

                StreamWriter streamWriter = new StreamWriter(FileName, true);
                streamWriter.WriteLine($"{match.GetMatchName()},{Convert.ToDateTime(match.GetSchedule())},{match.GetTotalTickets()}");
                streamWriter.Flush();
                streamWriter.Close();

                WriteAllDataInFile();

                return true;
            }
            catch
            {
                return false;
            }
        }
        
        private bool ReadDataFromFile()
        {
            StreamReader streamReader = new StreamReader(FileName);
            string record;

            if (File.Exists(FileName))
            {
                while((record = streamReader.ReadLine()) != null)
                {
                    string[] splittedRecord = record.Split(',');
                    string MatchName = splittedRecord[0];
                    string Schedule = splittedRecord[1];
                    int TotalTickets = int.Parse(splittedRecord[2]);

                    Match match = new Match(MatchName, Schedule, TotalTickets);
                    Matches.Add(match);
                }
                streamReader.Close();
                return true;
            }
            else
            {
                return false;
            }
        }

        private void WriteAllDataInFile()
        {
            StreamWriter streamWriter = new StreamWriter(FileName);

            foreach (Match match in Matches)
            {
                streamWriter.WriteLine($"{match.GetMatchName()},{Convert.ToDateTime(match.GetSchedule())},{match.GetTotalTickets()}");
            }

            streamWriter.Close();
        }
    }
}
