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
    public partial class ChangePassword : Form
    {
        private static IMUserDL MUserDL = ObjectHandler.GetMUserDL();
        public ChangePassword()
        {
            InitializeComponent();
            textBox1.Text = MUserDB.CurrentUser.GetPassword();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != string.Empty && textBox3.Text != string.Empty)
            {
                string newpassword = textBox2.Text;
                string repassword = textBox3.Text;

                if (Validations(newpassword))
                {
                    if (newpassword == repassword)
                    {
                        if (MUserDL.UpdatePassword(newpassword))
                        {
                            MessageBox.Show("Password Successfully Updated.");
                            ClearDataFromForm();
                        }
                        else
                        {
                            MessageBox.Show("Error!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Correctly Re-Enter Your New Password!");
                    }
                }
                else
                {
                    MessageBox.Show("Password Length Must Be 4.");
                }
            }
            else
            {
                MessageBox.Show("Input Data In All Fields First!");
            }
        }

        private bool Validations(string password)
        {
            if (password.Length != 4)
            {
                return false;
            }

            return true;
        }

        private void ClearDataFromForm()
        {
            textBox1.Text = textBox2.Text;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
        }
    }
}
