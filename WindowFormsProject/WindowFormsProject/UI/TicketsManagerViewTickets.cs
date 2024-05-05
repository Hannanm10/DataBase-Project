using ProjectDLL.BL;
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
    public partial class TicketsManagerViewTickets : Form
    {
        private static ITicketDL TicketDL = ObjectHandler.GetTicketDL();
        public TicketsManagerViewTickets()
        {
            InitializeComponent();
        }

        private void TicketsManagerViewTickets_Load(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("Ticket Type", typeof(string));
            dataTable.Columns.Add("Ticket Price", typeof(string));

            dataGridView1.DataSource = dataTable;

            List<Ticket> tickets = TicketDL.GetAllTickets();
            foreach (Ticket ticket in tickets)
            {
                dataTable.Rows.Add(ticket.GetTypeName(), ticket.GetPrice());
            }
            dataGridView1.DataSource = dataTable;
        }
    }
}
