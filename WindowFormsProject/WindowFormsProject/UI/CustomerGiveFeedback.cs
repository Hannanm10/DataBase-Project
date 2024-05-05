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
    public partial class CustomerGiveFeedback : Form
    {
        private static ICustomerDL CustomerDL = ObjectHandler.GetCustomerDL();
        public CustomerGiveFeedback()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != string.Empty)
            {
                string feedback = textBox1.Text;

                try
                {
                    if (CustomerDL.GiveFeedback(feedback))
                    {
                        MessageBox.Show("Feedback Successfully Added.");
                        textBox1.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Error!");
                    }
                }
                catch
                {
                    MessageBox.Show("User Feedback Already Added!");
                }
            }
            else
            {
                MessageBox.Show("Input Feedback First!");
            }
        }
    }
}
