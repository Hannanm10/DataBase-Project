using ProjectDLL.BL;
using ProjectDLL.DLInterfaces;
using ProjectDLL.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Match = ProjectDLL.BL.Match;

namespace ProjectDLL.DL.DB
{
    public class MatchDB : IMatchDL
    {
        private static string connection = ConnectionString.GetConnectionString();
        public List<Match> GetAllMatches()
        {
            SqlConnection sqlConnection = new SqlConnection(connection);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("select * from Matches", sqlConnection);

            SqlDataReader reader = sqlCommand.ExecuteReader();

            List<Match> matches = new List<Match>();

            while (reader.Read())
            {
                string name = reader["MatchName"].ToString();
                string schedule = reader["Schedule"].ToString();
                int tickets = int.Parse(reader["TotalTickets"].ToString());

                Match match = new Match(name,schedule,tickets);
                matches.Add(match);
            }

            reader.Close();
            sqlConnection.Close();

            return matches;
        }


        public List<string> GetAllMatchesNames()
        {
            string query = "SELECT MatchName FROM Matches";

            SqlConnection con = new SqlConnection(connection);
            con.Open();

            SqlCommand command = new SqlCommand(query, con);

            SqlDataReader reader = command.ExecuteReader();

            List<string> matchesNames = new List<string>();

            while (reader.Read())
            {
                matchesNames.Add(reader.GetString(0));
            }

            reader.Close();
            con.Close();

            return matchesNames;
        }

        public bool Save(Match match)
        {
            SqlConnection sqlConnection = new SqlConnection(connection);
            sqlConnection.Open();
            SqlCommand command = new SqlCommand("insert into Matches values(@name,@schedule,@tickets)", sqlConnection);
            command.Parameters.AddWithValue("@name", match.GetMatchName());
            command.Parameters.AddWithValue("@schedule", Convert.ToDateTime(match.GetSchedule()));
            command.Parameters.AddWithValue("@tickets", match.GetTotalTickets());
            int i = command.ExecuteNonQuery();
            sqlConnection.Close();
            if (i == 0)
            {
                return false;
            }
            return true;
        }

        public bool Delete(Match match)
        {
            SqlConnection sqlConnection = new SqlConnection(connection);
            sqlConnection.Open();
            SqlCommand command = new SqlCommand($"delete from Matches where MatchName='{match.GetMatchName()}'", sqlConnection);
            int i = command.ExecuteNonQuery();

            sqlConnection.Close();

            if (i == 0)
            {
                return false;
            }
            return true;
        }

        public int GetTotalTickets(string match)
        {
            SqlConnection sqlConnection = new SqlConnection (connection);
            sqlConnection.Open();
            SqlCommand sql = new SqlCommand("select TotalTickets from Matches where MatchName=@name", sqlConnection);
            sql.Parameters.AddWithValue("@name", match);
            int OldQuantity = Convert.ToInt32(sql.ExecuteScalar());
            sqlConnection.Close();
            return OldQuantity;
        }

        public void RemoveTickets(string match,int oldQuantity,int Reduce)
        {
            SqlConnection sqlConnection= new SqlConnection(connection);
            sqlConnection.Open();
            SqlCommand command = new SqlCommand("update Matches set TotalTickets=@quantity where MatchName=@name", sqlConnection);
            command.Parameters.AddWithValue("@quantity", oldQuantity - Reduce);
            command.Parameters.AddWithValue("@name", match);
            sqlConnection.Close();
            command.ExecuteNonQuery();
        }

        public bool AddTicketsToMatch(Match match)
        {
            SqlConnection sqlConnection = new SqlConnection(connection);
            sqlConnection.Open();

            int OldTickets = GetTotalTickets(match.GetMatchName());

            SqlCommand sqlCommand = new SqlCommand($"update Matches set TotalTickets=@add where MatchName='{match.GetMatchName()}'", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@add", OldTickets + match.GetTotalTickets());
            int i = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return i > 0;

        }


        public bool RemoveTicketsFromMatch(Match match)
        {
            SqlConnection sqlConnection = new SqlConnection(connection);
            sqlConnection.Open();

            int OldTickets = GetTotalTickets(match.GetMatchName());

            SqlCommand sqlCommand = new SqlCommand($"update Matches set TotalTickets=@add where MatchName='{match.GetMatchName()}'", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@add", OldTickets - match.GetTotalTickets());
            int i = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return i > 0;

        }
    }
}
