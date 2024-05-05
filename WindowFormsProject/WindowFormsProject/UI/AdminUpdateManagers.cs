using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowFormsProject.UI
{
    public partial class AdminUpdateManagers : Form
    {
        private static string connection = ConnectionString.GetConnectionString();
        public AdminUpdateManagers()
        {
            InitializeComponent();
            AddData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && comboBox1.Text != "")
            {
                
                string name = comboBox1.Text;
                string password = textBox1.Text;

                if (Validations(password))
                {
                    SqlConnection sqlConnection = new SqlConnection(connection);
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand($"update MUser set Password='{password}' where UserName='{name}'", sqlConnection);
                    int i = sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                    if (i != 0)
                    {
                        MessageBox.Show("Password Updated Successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Error!");
                    }
                }
                else
                {
                    MessageBox.Show("Password Length Must Be 4.");
                }
            }
            else
            {
                MessageBox.Show("Input Data In All Fields First!");
            }
        }

        private void AddData()
        {
            SqlConnection sqlConnection = new SqlConnection(connection);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("select UserName from MUser where UserRole like '%Manager'", sqlConnection);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            comboBox1.Items.Clear();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader.GetString(0));
            }
            reader.Close();
            sqlConnection.Close();
        }

        private bool Validations(string password)
        {
            if (password.Length != 4)
            {
                return false;
            }

            return true;
        }
    }
}
