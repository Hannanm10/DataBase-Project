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
    public partial class TicketsManagerAddTickets : Form
    {
        private static IMatchDL MatchDL = ObjectHandler.GetMatchDL();
        public TicketsManagerAddTickets()
        {
            InitializeComponent();
            FillAllMatchesInComboBox();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && comboBox1.Text != "")
            {
                try
                {
                    string name = comboBox1.Text;
                    int tickets = int.Parse(textBox1.Text);

                    Match match = new Match(name, tickets);

                    if (MatchDL.AddTicketsToMatch(match))
                    {
                        MessageBox.Show("Tickets Added Successfully!");
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
