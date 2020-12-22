using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Main
{
    public partial class SignUp : Form
    {
        string connectionString = @"Data Source = WIN-D7854B2J0DE\MYSQLSERVER21;Initial Catalog=Registration;Integrated Security=True";
        public SignUp()
        {
            InitializeComponent();
        }

        private void SignUp_Load(object sender, EventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtUsernameBox.Text == "" || txtPasswordBox.Text == "")
            {
                MessageBox.Show("Please fill out all sections!");
            }
            else if (txtPasswordBox.Text != txtConfirmPasswordBox.Text)
            {
                MessageBox.Show("Passwords are not matched!");
            }
            else
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("UserAdd", sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@FirstName", txtNameBox.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@LastName", txtSurnameBox.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Email", txtEmailBox.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Number", txtNumberBox.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Address", txtAddressBox.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@UserName", txtUsernameBox.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Password", txtPasswordBox.Text.Trim());
                    sqlCmd.ExecuteNonQuery();
                    MessageBox.Show("Registration is successfull!");
                    Clear();
                }
            }
            this.Hide();
            LogIn logIn = new LogIn();
            logIn.Show();
        }
        void Clear()
        {
            txtNameBox.Text = txtSurnameBox.Text = txtEmailBox.Text = txtNumberBox.Text = txtAddressBox.Text = txtUsernameBox.Text = txtPasswordBox.Text = txtConfirmPasswordBox.Text = "";
        }
    }
}
