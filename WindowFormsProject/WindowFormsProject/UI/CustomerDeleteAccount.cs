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
using Task_01__SIGNIN_SIGNUP_.UI;

namespace WindowFormsProject.UI
{
    public partial class CustomerDeleteAccount : Form
    {
        private static ICustomerDL CustomerDL = ObjectHandler.GetCustomerDL();
        public CustomerDeleteAccount()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked )
            {
                if (CustomerDL.DeleteAccount(""))
                {
                    MessageBox.Show("Account Deleted Successfully! GoodBye!");

                    Main_Menu main_Menu = new Main_Menu();
                    foreach (Form form in Application.OpenForms)
                    {
                        form.Hide();
                    }
                    main_Menu.Show();
                    SignUP signUP = new SignUP();
                    main_Menu.DisplayFormInPanel(signUP);
                }
                else
                {
                    MessageBox.Show("Error!");
                }
            }
            else
            {
                MessageBox.Show("Fill The CheckBox First!");
            }
        }
    }
}
