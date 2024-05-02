using ProjectDLL.BL;
using ProjectDLL.DLInterfaces;
using ProjectDLL.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDLL.DL.DB
{
    public class TicketDB : ITicketDL
    {
        private static string connection = ConnectionString.GetConnectionString();
        //private static IMatchDL MatchDL = new MatchDB();
        public List<Ticket> GetAllTickets()
        {
            SqlConnection sqlConnection = new SqlConnection(connection);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("select * from Tickets", sqlConnection);

            SqlDataReader reader = sqlCommand.ExecuteReader();

            List<Ticket> tickets = new List<Ticket>();

            while (reader.Read())
            {
                string typename = reader["TypeName"].ToString();
                double price = double.Parse(reader["Price"].ToString());

                Ticket ticket = new Ticket(typename,price);
                tickets.Add(ticket);
            }

            reader.Close();
            sqlConnection.Close();

            return tickets;
        }

        public List<string> GetTicketNames()
        {

            string query = "SELECT TypeName FROM Tickets";

            SqlConnection con = new SqlConnection(connection);
            con.Open();

            SqlCommand command = new SqlCommand(query, con);

            SqlDataReader reader = command.ExecuteReader();

            List<string> TypeNames = new List<string>();

            while (reader.Read())
            {
                TypeNames.Add(reader.GetString(0));
            }

            reader.Close();
            con.Close();

            return TypeNames;
        }

        public bool UpdatePrice(Ticket ticket)
        {
            SqlConnection sqlConnection = new SqlConnection(connection);
            sqlConnection.Open();
            SqlCommand sql = new SqlCommand("update Tickets set Price=@newprice where TypeName=@type", sqlConnection);
            sql.Parameters.AddWithValue("@newprice",ticket.GetPrice());
            sql.Parameters.AddWithValue("@type",ticket.GetTypeName());
            int i = sql.ExecuteNonQuery();
            sqlConnection.Close();
            return i > 0;
        }

        public double GetTicketPrice(string typename, SqlConnection sqlConnection)
        {

            SqlCommand cmd = new SqlCommand("select Price from Tickets where TypeName=@type", sqlConnection);
            cmd.Parameters.AddWithValue("@type", typename);
            double Amount = double.Parse(cmd.ExecuteScalar().ToString());

            return Amount;
        }
    }
}
