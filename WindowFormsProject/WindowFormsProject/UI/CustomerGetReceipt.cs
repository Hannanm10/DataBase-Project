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

namespace WindowFormsProject.UI
{
    public partial class CustomerGetReceipt : Form
    {
        private static ICustomerDL CustomerDL = ObjectHandler.GetCustomerDL();
        public CustomerGetReceipt()
        {
            InitializeComponent();
        }

        private void CustomerGetReceipt_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dataTable = CustomerDL.ViewReceipt();
                dataGridView1.DataSource = dataTable;

                if (dataTable.Rows.Count == 0)
                {

                    MessageBox.Show("You Have Not Bought Any Tickets Yet!");
                }
            }
            catch
            {
                MessageBox.Show("You Have Not Bought Any Tickets Yet!");
            }
        }
    }
}
