using ProjectDLL.BL;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowFormsProject.UI
{
    public partial class CustomerAddInformation : Form
    {
        private static ICustomerDL CustomerDL = ObjectHandler.GetCustomerDL();
        public CustomerAddInformation()
        {
            InitializeComponent();
            AddData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty || textBox2.Text == string.Empty || textBox3.Text == string.Empty)
            {
                MessageBox.Show("Input Data First In All Fields.");
            }
            else
            {
                string name = textBox1.Text;
                string address = textBox2.Text;
                string contact = textBox3.Text;


                try
                {
                    CustomerDB.CurrentUser.SetName(name);
                    CustomerDB.CurrentUser.SetAddress(address);
                    CustomerDB.CurrentUser.SetContact(contact);

                    if (CustomerDL.Save())
                    {
                        MessageBox.Show("Information Successfully Added.");
                        ClearDataFromForm();
                    }
                    else
                    {
                        MessageBox.Show("Error!");
                    }
                }
                catch
                {
                    MessageBox.Show("User Information Already Added!");
                }

            }
        }

        private void AddData()
        {
            if (CustomerDB.CurrentUser.GetName() != null)
            {
                textBox1.Text = CustomerDB.CurrentUser.GetName();
                textBox2.Text = CustomerDB.CurrentUser.GetAddress();
                textBox3.Text = CustomerDB.CurrentUser.GetContact();
            }
            else
            {
                try
                {
                    CustomerDL.GetCustomerInfo();
                    textBox1.Text = CustomerDB.CurrentUser.GetName();
                    textBox2.Text = CustomerDB.CurrentUser.GetAddress();
                    textBox3.Text = CustomerDB.CurrentUser.GetContact();
                }
                catch
                {
                    // Empty TextBoxes
                }
            }
        }
        private void ClearDataFromForm()
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
        }
    }
}
