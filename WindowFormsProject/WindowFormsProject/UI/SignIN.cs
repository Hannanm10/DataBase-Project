using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ProjectDLL.DL.DB;
using ProjectDLL.BL;
using WindowFormsProject.UI;
using WindowFormsProject;
using ProjectDLL.DLInterfaces;

namespace Task_01__SIGNIN_SIGNUP_.UI
{
    public partial class SignIN : Form
    {
        private static IMUserDL MUserDL = ObjectHandler.GetMUserDL();
        private static ICustomerDL CustomerDL = ObjectHandler.GetCustomerDL();
        private static IAdminDL AdminDL = ObjectHandler.GetAdminDL();
        public SignIN()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }


        private void ClearDataFromForm()
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty || textBox2.Text == string.Empty)
            {
                MessageBox.Show("Input Data In All Fields First!");
            }
            else
            {
                string username = textBox1.Text;
                string password = textBox2.Text;

                MUser user = new MUser(username, password);

                if (MUserDL.SignIn(user) != null)
                {
                    ClearDataFromForm();

                    user.SetRole(MUserDL.SignIn(user));
                    MUserDL.SetUser(user);

                    if (user.GetUserRole() == "Customer")
                    {

                        CustomerDL.SetCustomer(username, password);

                        CustomerMenu customerMenu = new CustomerMenu();
                        foreach(Form form in Application.OpenForms)
                        {
                            form.Hide();
                        }
                        customerMenu.Show();
                    }
                    else if (user.GetUserRole() == "Admin")
                    {
                        AdminDL.SetAdmin(username, password);

                        AdminMenu adminMenu = new AdminMenu();
                        foreach (Form form in Application.OpenForms)
                        {
                            form.Hide();
                        }
                        adminMenu.Show();
                    }
                    else if(user.GetUserRole() == "Matches Manager")
                    {
                        MatchesManagerDB.SetCurrentUser(username, password);

                        MatchesManagerMenu matchesManagerMenu = new MatchesManagerMenu();
                        foreach (Form form in Application.OpenForms)
                        {
                            form.Hide();
                        }
                        matchesManagerMenu.Show();
                    }
                    else if (user.GetUserRole() == "Tickets Manager")
                    {
                        TicketsManagerDB.SetCurrentUser(username, password);

                        TicketsManagerMenu ticketsmenu = new TicketsManagerMenu();
                        foreach (Form form in Application.OpenForms)
                        {
                            form.Hide();
                        }
                        ticketsmenu.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Credentials!!!");
                }
                
            }
        }
    }
}
