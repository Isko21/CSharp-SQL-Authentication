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
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=WIN-D7854B2J0DE\\MYSQLSERVER21;Initial Catalog=Registration;Integrated Security=True;");
            SqlDataAdapter data = new SqlDataAdapter("Select Count (*) From Registrations where UserName ='" + textUserBox.Text + "' and Password ='" + textPasswordBox.Text + "'", con);
            DataTable dt = new DataTable();
            data.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                MessageBox.Show("You are succesfully log in!");
            }
            else
            {
                MessageBox.Show("Incorrect username or password!");
            }
            Clear();
            this.Hide();
            Home home = new Home();
            home.Show();
        }
        void Clear()
        {
            textPasswordBox.Text = textUserBox.Text = "";
        }
    }
}
