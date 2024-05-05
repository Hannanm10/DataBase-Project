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
    public partial class AdminViewManagers : Form
    {
        private static string connection = ConnectionString.GetConnectionString();
        public AdminViewManagers()
        {
            InitializeComponent();
        }

        private void AdminViewManagers_Load(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(connection);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("select UserName,Password from MUser where UserRole like '%Manager'", sqlConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataTable Managers = new DataTable();
            adapter.Fill(Managers);
            sqlConnection.Close();
            dataGridView1.DataSource = Managers;
        }
    }
}
