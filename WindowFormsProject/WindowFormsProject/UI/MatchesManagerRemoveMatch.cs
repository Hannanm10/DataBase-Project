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
    public partial class MatchesManagerRemoveMatch : Form
    {
        private static IMatchDL MatchDL = ObjectHandler.GetMatchDL();
        public MatchesManagerRemoveMatch()
        {
            InitializeComponent();
            FillAllMatchesInComboBox();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text != "")
                {
                    Match match = new Match(comboBox1.Text);

                    if (MatchDL.Delete(match))
                    {
                        MessageBox.Show("Match Removed Successfully!");
                        comboBox1.Text = "";
                        FillAllMatchesInComboBox();
                    }
                    else
                    {
                        MessageBox.Show("Choose Valid Match From The Options!");
                    }
                }
                else
                {
                    MessageBox.Show("Choose The Match You Want To Delete First!");
                }
            }
            catch
            {
                MessageBox.Show("Selected Match Cannot Be Removed!");
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
