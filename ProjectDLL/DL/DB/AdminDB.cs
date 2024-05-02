using ProjectDLL.BL;
using ProjectDLL.DLInterfaces;
using ProjectDLL.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDLL.DL.DB
{
    public class AdminDB : IAdminDL
    {
        private static string connection = ConnectionString.GetConnectionString();
        public static Admin CurrentUser;

        public void SetAdmin(string name, string pass)
        {
            CurrentUser = new Admin();

            CurrentUser.SetUsername(name);
            CurrentUser.SetPassword(pass);
            CurrentUser.SetRole("Admin");

        }

        public DataTable ViewOrders()
        {
            SqlConnection sqlConnection = new SqlConnection(connection);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("select UserName,Match,TicketType,Quantity,Amount,DateCreated from Orders o,MUser m " +
                "where o.User_id=m.ID", sqlConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataTable Orders = new DataTable();
            adapter.Fill(Orders);
            sqlConnection.Close();
            return Orders;
        }
        public DataTable ViewFeedBacks()
        {
            SqlConnection sqlConnection = new SqlConnection(connection);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("select UserName,Feedback,[Date Created] from Feedbacks f,MUser m where " +
                "f.Customer_id = m.ID", sqlConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataTable Feedbacks = new DataTable();
            adapter.Fill(Feedbacks);
            sqlConnection.Close();
            return Feedbacks;
        }
    }
}
