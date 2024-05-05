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
    public partial class AdminViewFeedbacks : Form
    {
        private static IAdminDL AdminDL = ObjectHandler.GetAdminDL();
        public AdminViewFeedbacks()
        {
            InitializeComponent();
        }

        private void AdminViewFeedbacks_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dataTable = AdminDL.ViewFeedBacks();
                dataGridView1.DataSource = dataTable;

                if (dataTable.Rows.Count == 0)
                {

                    MessageBox.Show("There Are No Feedbacks Yet!");
                }
            }
            catch
            {
                MessageBox.Show("There Are No Feedbacks Yet!");
            }
        }
    }
}
