using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Task_01__SIGNIN_SIGNUP_.UI;

namespace WindowFormsProject.UI
{
    public partial class Main_Menu : Form
    {
        public Main_Menu()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SignIN signIN = new SignIN();
            DisplayFormInPanel(signIN);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SignUP signUP = new SignUP();
            DisplayFormInPanel(signUP);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public void DisplayFormInPanel(Form formToShow)
        {
            // Set the TopLevel property of the form to false
            // to ensure it can be added to another form or control
            formToShow.TopLevel = false;

            // Clear the panel's controls
            panel1.Controls.Clear();

            // Set the form's Dock property to Fill
            // so it fills the panel completely
            formToShow.Dock = DockStyle.Fill;

            // Add the form to the panel's controls collection
            panel1.Controls.Add(formToShow);

            // Show the form
            formToShow.Show();
        }
    }
}
