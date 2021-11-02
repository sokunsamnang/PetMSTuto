using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetMSTuto
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Employees Obj = new Employees();
            Obj.Show();
            this.Hide();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Sam Allen\Documents\PetShopDb.mdf"";Integrated Security=True;Connect Timeout=30");
        public static string Employee;

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if (UnameTb.Text == "" || PasswordTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter("Select count(*) from EmployeeTbl where EmpName='" + UnameTb.Text + "' and EmpPass='" + PasswordTb.Text + "'", Con);
                    DataTable d = new DataTable();
                    sda.Fill(d);
                    if (d.Rows[0][0].ToString() == "1")
                    {
                        Employee = UnameTb.Text;
                        Homes Obj = new Homes();
                        Obj.Show();
                        this.Hide();
                    }
                    Con.Close();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
