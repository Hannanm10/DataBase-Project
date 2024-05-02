using ProjectDLL.BL;
using ProjectDLL.DLInterfaces;
using ProjectDLL.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectDLL.DL.DB
{
    public class CustomerDB : ICustomerDL
    {
        private static string connection = ConnectionString.GetConnectionString();
        public static Customer CurrentUser;
        private static IMUserDL MUserDL = new MUserDB();
        private static ITicketDL TicketDL = new TicketDB();
        private static IMatchDL MatchDL = new MatchDB();

        public void SetCustomer(string name, string pass)
        {
            CurrentUser = new Customer(name,pass,"Customer");

        }

        public bool Save()
        {
            if (CurrentUser.GetName() != null || CurrentUser.GetAddress() != null || CurrentUser.GetContact() != null)
            {
                SqlConnection sqlConnection = new SqlConnection(connection);
                sqlConnection.Open();

                int id = MUserDL.GetUserID(CurrentUser.GetUserName(), CurrentUser.GetPassword());

                SqlCommand cmd = new SqlCommand("insert into Customers values (@id,@name,@address,@contact)", sqlConnection);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", CurrentUser.GetName());
                cmd.Parameters.AddWithValue("@address", CurrentUser.GetAddress());
                cmd.Parameters.AddWithValue("@contact", CurrentUser.GetContact());

                cmd.ExecuteNonQuery();
                sqlConnection.Close();
                return true;
            }
            else
            {
                return false;
            }
        }

        //public static bool UpdatePassword(string newPassword)
        //{
        //    SqlConnection sqlConnection = new SqlConnection(connection);
        //    sqlConnection.Open();

        //    SqlCommand sqlCommand = new SqlCommand("update MUser set Password=@newpass where Password=@oldpass", sqlConnection);

        //    sqlCommand.Parameters.AddWithValue("@oldpass", CurrentUser.GetPassword());
        //    sqlCommand.Parameters.AddWithValue("@newpass", newPassword);
        //    int i = sqlCommand.ExecuteNonQuery();
        //    sqlConnection.Close();

        //    if (i > 0)
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        public bool GiveFeedback(string newFeedback)
        {
            SqlConnection sqlConnection = new SqlConnection(connection);
            sqlConnection.Open();

            int id = MUserDL.GetUserID(CurrentUser.GetUserName(), CurrentUser.GetPassword());

            SqlCommand sqlCommand1 = new SqlCommand("insert into Feedbacks values (@id,@feedback,@datetime)", sqlConnection);
            sqlCommand1.Parameters.AddWithValue("@id", id);
            sqlCommand1.Parameters.AddWithValue("@feedback", newFeedback);
            sqlCommand1.Parameters.AddWithValue("@datetime",DateTime.Now);

            int i = sqlCommand1.ExecuteNonQuery();
            sqlConnection.Close();

            if (i > 0)
            {
                return true;
            }
            return false;
        }

        public bool DeleteAccount(string Name)
        {
            SqlConnection sqlConnection = new SqlConnection(connection);
            sqlConnection.Open();

            int id;

            if (Name == "")
            {
                id = MUserDL.GetUserID(CurrentUser.GetUserName(), CurrentUser.GetPassword());
            }
            else
            {
                SqlCommand sqlCommand = new SqlCommand("select ID from MUser where UserName=@name", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@name", Name);
                id = Convert.ToInt32(sqlCommand.ExecuteScalar());
            }

            DeleteFromFeedbacks(id, sqlConnection);
            DeleteFromOrders(id, sqlConnection);
            DeleteFromCustomers(id, sqlConnection);

            SqlCommand sqlCommand3 = new SqlCommand($"delete from MUser where ID={id}", sqlConnection);
            int i = sqlCommand3.ExecuteNonQuery();

            sqlConnection.Close();

            if(i > 0) { return true;}
            return false;
        }

        private void DeleteFromFeedbacks(int id,SqlConnection sqlConnection)
        {
            SqlCommand sqlCommand1 = new SqlCommand($"delete from Feedbacks where Customer_id={id}", sqlConnection);
            sqlCommand1.ExecuteNonQuery();

        }

        private void DeleteFromOrders(int id, SqlConnection sqlConnection)
        {
            SqlCommand sql = new SqlCommand($"delete from Orders where User_id={id}", sqlConnection);
            sql.ExecuteNonQuery();

        }

        private void DeleteFromCustomers(int id, SqlConnection sqlConnection)
        {
            SqlCommand sqlCommand2 = new SqlCommand($"delete from Customers where User_id={id}", sqlConnection);
            sqlCommand2.ExecuteNonQuery();

        }

        public bool BuyTicket(int quantity)
        {
            SqlConnection sqlConnection = new SqlConnection(connection);
            sqlConnection.Open();

            string typename = CurrentUser.GetTicket().GetTypeName();
            string match = CurrentUser.GetTicket().GetMatch().GetMatchName();

            int id = MUserDL.GetUserID(CurrentUser.GetUserName(), CurrentUser.GetPassword());

            double Amount = TicketDL.GetTicketPrice(typename, sqlConnection);

            int OldQuantity = MatchDL.GetTotalTickets(match);

            SqlCommand command = new SqlCommand("update Matches set TotalTickets=@quantity where MatchName=@name", sqlConnection);
            command.Parameters.AddWithValue("@quantity", OldQuantity - quantity);
            command.Parameters.AddWithValue("@name", match);
            command.ExecuteNonQuery();

            SqlCommand cmd1 = new SqlCommand("insert into Orders values (@type,@quantity,@amount,@userid,@date,@match)", sqlConnection);
            cmd1.Parameters.AddWithValue("@type", typename);
            cmd1.Parameters.AddWithValue("@quantity", quantity);
            cmd1.Parameters.AddWithValue("@amount", Amount * quantity);
            cmd1.Parameters.AddWithValue("@userid", id);
            cmd1.Parameters.AddWithValue("@date", DateTime.Now);
            cmd1.Parameters.AddWithValue("@match", match);

            int i = cmd1.ExecuteNonQuery();

            if (i > 0) { return true;}
            return false;
        }

        public DataTable ViewReceipt()
        {
            SqlConnection sqlConnection = new SqlConnection(connection);
            sqlConnection.Open();

            int id = MUserDL.GetUserID(CurrentUser.GetUserName(), CurrentUser.GetPassword());

            SqlCommand sqlCommand = new SqlCommand($"select Match,TicketType,Quantity,Amount from Orders where User_id={id}", sqlConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataTable Receipt = new DataTable();
            adapter.Fill(Receipt);
            sqlConnection.Close();
            return Receipt;
        }

        public DataTable GetCustomerCredentials()
        {
            SqlConnection sqlConnection = new SqlConnection(connection);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("select UserName,Password from MUser where UserRole='Customer'", sqlConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataTable Customers = new DataTable();
            adapter.Fill(Customers);
            sqlConnection.Close();
            return Customers;

        }

        public void GetCustomerInfo()
        {
            SqlConnection sqlConnection = new SqlConnection(connection);
            sqlConnection.Open();

            int id = MUserDL.GetUserID(CurrentUser.GetUserName(), CurrentUser.GetPassword());

            SqlCommand sqlCommand = new SqlCommand($"select Name,Address,Contact from Customers where User_id={id}", sqlConnection);

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            
            while (sqlDataReader.Read())
            {
                CurrentUser.SetName(sqlDataReader["Name"].ToString());
                CurrentUser.SetAddress(sqlDataReader["Address"].ToString());
                CurrentUser.SetContact(sqlDataReader["Contact"].ToString());
            }
            sqlDataReader.Close();
            sqlConnection.Close();
        }

        public List<string> GetCustomerUserNames()
        {
            SqlConnection sqlConnection = new SqlConnection(connection);
            sqlConnection.Open();
            SqlCommand sqlCommand1 = new SqlCommand("select UserName from MUser where UserRole='Customer'", sqlConnection);

            SqlDataReader reader = sqlCommand1.ExecuteReader();

            List<string> CustomerNames = new List<string>();

            while (reader.Read())
            {
                CustomerNames.Add(reader["UserName"].ToString());
            }
            reader.Close();
            sqlConnection.Close();
            return CustomerNames;
        }
    }
}
