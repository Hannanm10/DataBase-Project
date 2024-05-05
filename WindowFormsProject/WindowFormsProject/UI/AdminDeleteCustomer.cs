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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowFormsProject.UI
{
    public partial class AdminDeleteCustomer : Form
    {
        private static ICustomerDL CustomerDL = ObjectHandler.GetCustomerDL();
        public AdminDeleteCustomer()
        {
            InitializeComponent();
            FillAllCustomersInComboBox();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {

                if (CustomerDL.DeleteAccount(comboBox1.Text))
                {
                    MessageBox.Show("Customer Account Deleted Successfully!");
                    comboBox1.Text = "";
                    FillAllCustomersInComboBox();
                }
                else
                {
                    MessageBox.Show("Choose Valid Customer From The Options!");
                }
            }
            else
            {
                MessageBox.Show("Choose The Customer You Want To Delete First!");
            }
        }


        private void FillAllCustomersInComboBox()
        {
            comboBox1.Items.Clear();

            foreach (string customer in CustomerDL.GetCustomerUserNames())
            {
                comboBox1.Items.Add(customer);
            }
        }
    }
}
