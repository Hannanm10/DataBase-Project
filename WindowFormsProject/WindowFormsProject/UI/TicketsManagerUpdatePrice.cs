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
    public partial class TicketsManagerUpdatePrice : Form
    {
        private static ITicketDL TicketDL = ObjectHandler.GetTicketDL();
        public TicketsManagerUpdatePrice()
        {
            InitializeComponent();
            FillAllTicketsInComboBox();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && comboBox1.Text != "")
            {
                try
                {
                    string name = comboBox1.Text;
                    double price = double.Parse(textBox1.Text);

                    Ticket ticket = new Ticket(name, price);

                    if (TicketDL.UpdatePrice(ticket))
                    {
                        MessageBox.Show("Ticket Price Updated Successfully!");
                        comboBox1.Text = "";
                        textBox1.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Error!");
                    }
                }
                catch
                {
                    MessageBox.Show("Enter Integer Value In Tickets Field!");
                }
            }
            else
            {
                MessageBox.Show("Input Data In All Fields First!");
            }
        }

        private void FillAllTicketsInComboBox()
        {
            comboBox1.Items.Clear();

            foreach (string ticket in TicketDL.GetTicketNames())
            {
                comboBox1.Items.Add(ticket);

            }
        }
    }
}
