using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectDLL.BL;
using ProjectDLL.DL.DB;
using ProjectDLL.DLInterfaces;
using WindowFormsProject;
using WindowFormsProject.UI;

namespace Task_01__SIGNIN_SIGNUP_.UI
{
    public partial class SignUP : Form
    {
        private static IMUserDL MUserDL = ObjectHandler.GetMUserDL();
        public SignUP()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }


        private void ClearDataFromForm()
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty || textBox2.Text == string.Empty)
            {
                MessageBox.Show("Input Data First In All Fields!");
            }
            else
            {
                string username = textBox1.Text;
                string password = textBox2.Text;
                string role = "Customer";


                if (Validations(username, password))
                {
                    MUser user = new MUser(username, password, role);
                    if (MUserDL.Save(user))
                    {
                        MUserDB.CurrentUser = user;
                        MessageBox.Show("Congratulations! Your Account Has Been Created.");
                        ClearDataFromForm();

                    }
                    else
                    {
                        MessageBox.Show("UserName Already In Use! Try Something Different.");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Input! There should be no space in Username and Password length must be 4.");
                }
                
            }
        }

        private bool Validations(string username, string password)
        {
            int len = username.Length;

            for (int i = 0; i < len; i++)
            {
                if (username[i] == ' ')
                {
                    return false;
                }
            }

            if (password.Length != 4)
            {
                return false;
            }

            return true;
        }

    }
}
