using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowFormsProject.UI;

namespace Task_01__SIGNIN_SIGNUP_.UI
{
    public partial class AdminMenu : Form
    {
        public AdminMenu()
        {
            InitializeComponent();
        }

        private void AdminMenu_Load(object sender, EventArgs e)
        {

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

        private void button8_Click(object sender, EventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
        {
            AdminViewCustomers adminViewCustomers = new AdminViewCustomers();
            DisplayFormInPanel(adminViewCustomers);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AdminViewOrders adminViewOrders = new AdminViewOrders();
            DisplayFormInPanel(adminViewOrders);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ChangePassword changePassword = new ChangePassword();
            DisplayFormInPanel(changePassword);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AdminViewFeedbacks adminViewFeedbacks = new AdminViewFeedbacks();
            DisplayFormInPanel(adminViewFeedbacks);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AdminDeleteCustomer adminDeleteAccount = new AdminDeleteCustomer();
            DisplayFormInPanel(adminDeleteAccount);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminViewManagers adminViewManagers = new AdminViewManagers();
            DisplayFormInPanel(adminViewManagers);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdminUpdateManagers adminUpdateManagers = new AdminUpdateManagers();
            DisplayFormInPanel(adminUpdateManagers);
        }


    }
}
