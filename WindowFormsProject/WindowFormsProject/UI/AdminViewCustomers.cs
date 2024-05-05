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
    public partial class AdminViewCustomers : Form
    {
        private static ICustomerDL CustomerDL = ObjectHandler.GetCustomerDL();
        public AdminViewCustomers()
        {
            InitializeComponent();
            AddData();
        }

        private void AddData()
        {

            try
            {
                DataTable dataTable = CustomerDL.GetCustomerCredentials();
                dataGridView1.DataSource = dataTable;

                if (dataTable.Rows.Count == 0)
                {

                    MessageBox.Show("There Are No Customers Yet!");
                }
            }
            catch
            {
                MessageBox.Show("There Are No Customers Yet!");
            }
        }
    }
}
