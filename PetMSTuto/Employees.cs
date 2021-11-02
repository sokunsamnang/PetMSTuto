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
namespace PetMSTuto
{
    public partial class Employees : Form
    {
        public Employees()
        {
            InitializeComponent();
            EmpNameLbl.Text = Login.Employee;
            DisplayEmployees();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Sam Allen\Documents\PetShopDb.mdf"";Integrated Security=True;Connect Timeout=30");
        private void DisplayEmployees()
        {
            Con.Open();
            string Query = "Select * from Employeetbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            EmployeeDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void Clear()
        {
            EmpNameTb.Text = "";
            EmpAddTb.Text = "";
            EmpPhoneTb.Text = "";
            PasswordTb.Text = "";
        }
        private void Savebtn_Click(object sender, EventArgs e)
        {

        }
        int Key = 0;

        private void Savebtn_Click_1(object sender, EventArgs e)
        {
            if(EmpNameTb.Text == "" || EmpPhoneTb.Text == "" || PasswordTb.Text == ""||EmpAddTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into EmployeeTbl (EmpName,EmpAdd,EmpDOB,EmpPhone,EmpPass) values(@EN,@EA,@ED,@EP,@EPa)", Con);
                    cmd.Parameters.AddWithValue("@EN", EmpNameTb.Text);
                    cmd.Parameters.AddWithValue("@EA", EmpAddTb.Text);
                    cmd.Parameters.AddWithValue("@ED", EmpDOB.Value.Date);
                    cmd.Parameters.AddWithValue("@EP", EmpPhoneTb.Text);
                    cmd.Parameters.AddWithValue("@EPa", PasswordTb.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Added!!!");
                    Con.Close();
                    DisplayEmployees();
                    Clear();
                }catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void EmployeeDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            EmpNameTb.Text = EmployeeDGV.SelectedRows[0].Cells[1].Value.ToString();
            EmpAddTb.Text = EmployeeDGV.SelectedRows[0].Cells[2].Value.ToString();
            EmpDOB.Text = EmployeeDGV.SelectedRows[0].Cells[3].Value.ToString();
            EmpPhoneTb.Text = EmployeeDGV.SelectedRows[0].Cells[4].Value.ToString();
            PasswordTb.Text = EmployeeDGV.SelectedRows[0].Cells[5].Value.ToString();
            if(EmpNameTb.Text == "")
            {
                Key = 0;
            }else
            {
                Key = Convert.ToInt32(EmployeeDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (EmpNameTb.Text == "" || EmpPhoneTb.Text == "" || PasswordTb.Text == "" || EmpAddTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Update EmployeeTbl set EmpName=@EN,EmpAdd=@EA,EmpDOB=@ED,EmpPhone=@EP,EmpPass=@EPa where EmpNum=@EKey", Con);
                    cmd.Parameters.AddWithValue("@EN", EmpNameTb.Text);
                    cmd.Parameters.AddWithValue("@EA", EmpAddTb.Text);
                    cmd.Parameters.AddWithValue("@ED", EmpDOB.Value.Date);
                    cmd.Parameters.AddWithValue("@EP", EmpPhoneTb.Text);
                    cmd.Parameters.AddWithValue("@EPa", PasswordTb.Text);
                    cmd.Parameters.AddWithValue("@EKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Updated!!!");
                    Con.Close();
                    DisplayEmployees();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Select An Employee");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("delete from EmployeeTbl where EmpNum = @EmpKey", Con);
                    cmd.Parameters.AddWithValue("@EmpKey", Key);
                   
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Deleted!!!");
                    Con.Close();
                    DisplayEmployees();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
           
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {
         
        }

        private void label5_Click(object sender, EventArgs e)
        {
           
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }
    }
}
