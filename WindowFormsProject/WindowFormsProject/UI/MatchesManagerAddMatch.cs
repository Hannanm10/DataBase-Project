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
    public partial class MatchesManagerAddMatch : Form
    {
        private static IMatchDL MatchDL = ObjectHandler.GetMatchDL();
        public MatchesManagerAddMatch()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox3.Text != "" && dateTimePicker1.Text != "")
            {
                try
                {
                    int tickets = int.Parse(textBox3.Text);
                    string name = textBox1.Text;
                    string schedule = dateTimePicker1.Text;

                    Match match = new Match(name, schedule, tickets);

                    if (MatchDL.Save(match))
                    {
                        MessageBox.Show("Match Added Successfully.");
                        ClearDataFromForm();
                    }
                    else
                    {
                        MessageBox.Show("Match Already Added!");
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

        private void ClearDataFromForm()
        {
            textBox1.Text = string.Empty;
            dateTimePicker1.Text = string.Empty;
            textBox3.Text = string.Empty;
        }
    }
}
