using ProjectDLL.BL;
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
    public partial class MatchesManagerViewMatches : Form
    {
        private static IMatchDL MatchDL = ObjectHandler.GetMatchDL();
        public MatchesManagerViewMatches()
        {
            InitializeComponent();
        }

        private void MatchesManagerViewMatches_Load(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("Match", typeof(string));
            dataTable.Columns.Add("Schedule", typeof(string));
            dataTable.Columns.Add("Total Tickets", typeof(string));

            dataGridView1.DataSource = dataTable;

            List<Match> matches = MatchDL.GetAllMatches();
            foreach (Match match in matches)
            {
                dataTable.Rows.Add(match.GetMatchName(), match.GetSchedule(), match.GetTotalTickets());
            }
            dataGridView1.DataSource = dataTable;
        }
    }
}
