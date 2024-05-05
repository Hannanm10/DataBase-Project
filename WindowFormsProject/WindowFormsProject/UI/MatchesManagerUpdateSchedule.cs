using ProjectDLL.DLInterfaces;
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
    public partial class MatchesManagerUpdateSchedule : Form
    {
        private static IMatchDL MatchDL = ObjectHandler.GetMatchDL();
        private static string connection = ConnectionString.GetConnectionString();
        public MatchesManagerUpdateSchedule()
        {
            InitializeComponent();
            FillAllMatchesInComboBox();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (comboBox1.Text != "" && dateTimePicker1.Text != "")
            {
                string name = comboBox1.Text;
                string schedule = dateTimePicker1.Text;

                SqlConnection sqlConnection = new SqlConnection(connection);
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand($"update Matches set Schedule='{Convert.ToDateTime(schedule)}' where MatchName='{name}'", sqlConnection);
                int i = sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                comboBox1.Text = "";

                if (i != 0)
                {
                    MessageBox.Show("Match Schedule Updated Successfully.");
                }
                else
                {
                    MessageBox.Show("Error!");
                }
            }
            else
            {
                MessageBox.Show("Input Data In All Fields First!");
            }
        }

        private void FillAllMatchesInComboBox()
        {
            comboBox1.Items.Clear();

            foreach (string match in MatchDL.GetAllMatchesNames())
            {
                comboBox1.Items.Add(match);

            }
        }
    }
}
