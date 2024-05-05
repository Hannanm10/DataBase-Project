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
    public partial class CustomerBuyTickets : Form
    {
        private static ICustomerDL CustomerDL = ObjectHandler.GetCustomerDL();
        private static IMatchDL MatchDL = ObjectHandler.GetMatchDL();
        public CustomerBuyTickets()
        {
            InitializeComponent();
            FillMatchesInComboBox();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != string.Empty && textBox2.Text != string.Empty && comboBox2.Text != string.Empty)
            {
                try
                {
                    int quantity = int.Parse(textBox2.Text);
                    string TicketType = comboBox1.Text;
                    string MatchName = comboBox2.Text;

                    Match match = new Match(MatchName);

                    Ticket ticket = new Ticket(TicketType,match);

                    CustomerDB.CurrentUser.BuyTicket(ticket);

                    if (CustomerDL.BuyTicket(quantity))
                    {
                        MessageBox.Show("Tickets Bought Successfully.");

                        textBox2.Text = "";
                        comboBox1.Text = "";
                        comboBox2.Text = ""; 
                    }
                    else
                    {
                        MessageBox.Show("Error!");
                    }
                }
                catch
                {
                    MessageBox.Show("Enter Integer Number In Quantity Please!");
                    textBox2.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Input Data In All Fields First!");
            }
        }

        private void FillMatchesInComboBox()
        {
            comboBox2.Items.Clear();

            foreach (string match in MatchDL.GetAllMatchesNames())
            {
                comboBox2.Items.Add(match);
            }
        }
    }
}
