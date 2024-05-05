using ProjectDLL.BL;
using ProjectDLL.DL.DB;
using ProjectDLL.DLInterfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowFormsProject.UI
{
    public partial class CustomerViewTickets : Form
    {
        private static ITicketDL TicketDL = ObjectHandler.GetTicketDL();
        private static IMatchDL MatchDL = ObjectHandler.GetMatchDL();
        public CustomerViewTickets()
        {
            InitializeComponent();
            LoadGridView();
            LoadGridView2();
        }

        private void CustomerViewTickets_Load(object sender, EventArgs e)
        {

        }

        private void LoadGridView()
        {
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("Ticket Type", typeof(string));
            dataTable.Columns.Add("Ticket Price", typeof(string));

            dataGridView1.DataSource = dataTable;

            List<Ticket> tickets = TicketDL.GetAllTickets();
            foreach (Ticket ticket in tickets)
            {
                dataTable.Rows.Add(ticket.GetTypeName(),ticket.GetPrice());
            }
            dataGridView1.DataSource = dataTable;
        }

        private void LoadGridView2()
        {
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("Match", typeof(string));
            dataTable.Columns.Add("Schedule", typeof(string));
            dataTable.Columns.Add("Total Tickets", typeof(string));

            dataGridView2.DataSource = dataTable;

            List<Match> matches = MatchDL.GetAllMatches();
            foreach (Match match in matches)
            {
                dataTable.Rows.Add(match.GetMatchName(),match.GetSchedule(),match.GetTotalTickets());
            }
            dataGridView2.DataSource = dataTable;
        }
    }
}
