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
    public partial class TicketsManagerMenu : Form
    {
        public TicketsManagerMenu()
        {
            InitializeComponent();
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

        private void button6_Click(object sender, EventArgs e)
        {
            Main_Menu main_Menu = new Main_Menu();
            foreach (Form form in Application.OpenForms)
            {
                form.Hide();
            }
            main_Menu.Show();
            SignIN signIN = new SignIN();
            main_Menu.DisplayFormInPanel(signIN);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TicketsManagerViewTickets ticketsManagerViewTickets = new TicketsManagerViewTickets();
            DisplayFormInPanel(ticketsManagerViewTickets);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TicketsManagerAddTickets ticketsManagerAddTickets = new TicketsManagerAddTickets();
            DisplayFormInPanel(ticketsManagerAddTickets);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TicketsManagerRemoveTickets ticketsManagerRemoveTickets = new TicketsManagerRemoveTickets();
            DisplayFormInPanel(ticketsManagerRemoveTickets);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TicketsManagerUpdatePrice ticketsManagerUpdatePrice = new TicketsManagerUpdatePrice();
            DisplayFormInPanel(ticketsManagerUpdatePrice);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ChangePassword changePassword = new ChangePassword();
            DisplayFormInPanel(changePassword);
        }
    }
}
