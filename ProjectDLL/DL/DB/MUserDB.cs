using ProjectDLL.BL;
using ProjectDLL.DLInterfaces;
using ProjectDLL.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDLL.DL.DB
{
    public class MUserDB : IMUserDL
    {
        private static string connection = ConnectionString.GetConnectionString();
        public static MUser CurrentUser;

        public void SetUser(MUser user)
        {
            CurrentUser = user;
        }
        public bool Save(MUser mUser)
        {
            if (SignIn(mUser) == null && !IsUserNameAlreadyTaken(mUser.GetUserName()))
            {
                SqlConnection sqlConnection = new SqlConnection(connection);
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("insert into MUser values (@name,@pass,@role)", sqlConnection);
                cmd.Parameters.AddWithValue("@name", mUser.GetUserName());
                cmd.Parameters.AddWithValue("@pass", mUser.GetPassword());
                cmd.Parameters.AddWithValue("@role", mUser.GetUserRole());

                cmd.ExecuteNonQuery();
                sqlConnection.Close();
                return true;
            }
            else
            {
                return false;
            }
        }

        private List<string> GetUsernamesFromDataBase()
        {
            string query = "SELECT UserName FROM MUser";

            SqlConnection con = new SqlConnection(connection);
            con.Open();

            SqlCommand command = new SqlCommand(query, con);

            SqlDataReader reader = command.ExecuteReader();

            List<string> usernames = new List<string>();

            while (reader.Read())
            {
                usernames.Add(reader.GetString(0));
            }

            reader.Close();
            con.Close();
            return usernames;
        }

        //public static List<string> GetPassWordsFromDataBase()
        //{
        //    string query = "SELECT Password FROM MUser";

        //    SqlConnection con = new SqlConnection(connection);
        //    con.Open();

        //    SqlCommand command = new SqlCommand(query, con);

        //    SqlDataReader reader = command.ExecuteReader();

        //    List<string> passwords = new List<string>();

        //    while (reader.Read())
        //    {
        //        passwords.Add(reader.GetString(0));
        //    }

        //    reader.Close();
        //    con.Close();
        //    return passwords;
        //}

        private bool IsUserNameAlreadyTaken(string userName)
        {
            //SqlConnection sqlConnection = new SqlConnection(connection);
            //sqlConnection.Open();
            //SqlCommand cmd = new SqlCommand("select COUNT(*) from MUser where UserName=@name",sqlConnection);
            //cmd.Parameters.AddWithValue("@name", userName);
            //int check = (int)cmd.ExecuteScalar();
            //sqlConnection.Close();
            

            foreach(string name in GetUsernamesFromDataBase())
            {
                if (name == userName)
                {
                    return true;
                }
            }
            return false;
        }

        public string SignIn(MUser mUser)
        {
            foreach (string name in GetUsernamesFromDataBase())
            {
                if (name == mUser.GetUserName())
                {
                    //foreach (string pass in GetPassWordsFromDataBase())
                    //{
                        //if (pass == mUser.GetPassword())
                        //{
                            SqlConnection sqlConnection = new SqlConnection(connection);
                            sqlConnection.Open();

                            string query = "SELECT UserRole from MUser where UserName=@name AND Password=@pass";

                            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                            sqlCommand.Parameters.AddWithValue("@name",mUser.GetUserName());
                            sqlCommand.Parameters.AddWithValue("@pass",mUser.GetPassword());    

                            string role = Convert.ToString(sqlCommand.ExecuteScalar());
                            sqlConnection.Close();

                            if (role != "")
                            {
                                return role;
                            }
                        //}
                    //}
                }
            }
            return null;
        }

        public bool UpdatePassword(string newPassword)
        {
            SqlConnection sqlConnection = new SqlConnection(connection);
            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand("update MUser set Password=@newpass where Password=@oldpass", sqlConnection);

            sqlCommand.Parameters.AddWithValue("@oldpass", CurrentUser.GetPassword());
            sqlCommand.Parameters.AddWithValue("@newpass", newPassword);
            int i = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();

            if (i > 0)
            {
                return true;
            }
            return false;
        }

        public int GetUserID(string UserName,string Password)
        {
            SqlConnection sqlConnection = new SqlConnection(connection);
            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand("select ID from MUser where Password=@pass and UserName=@name", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@pass", Password);
            sqlCommand.Parameters.AddWithValue("@name", UserName);
            int id = Convert.ToInt32(sqlCommand.ExecuteScalar());

            sqlConnection.Close();

            return id;
        }
    }
}
