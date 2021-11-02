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
    public partial class Homes : Form
    {
        public Homes()
        {
            InitializeComponent();
            EmpNameLbl.Text = Login.Employee;
            CountDogs();
            CountBirds();
            CountCats();
            CountFoods();
            Finance();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Billings Obj = new Billings();
            Obj.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Homes Obj = new Homes();
            Obj.Show();
            this.Hide();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Sam Allen\Documents\PetShopDb.mdf"";Integrated Security=True;Connect Timeout=30");
        private void CountDogs()
        {
            string Cat = "Dog";
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from ProductTbl where PrCat='" + Cat + "'",Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DogsLbl.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }
        private void Finance()
        {
           
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Sum(Amt) from BillTbl", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            FinanceLbl.Text = dt.Rows[0][0].ToString();
            int Riel = (int) dt.Rows[0][0];
            FinanceKHLbl.Text = (Riel * 4100).ToString();
            Con.Close();
        }
        private void CountBirds()
        {
            string Cat = "Bird";
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from ProductTbl where PrCat='" + Cat + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            BirdsLbl.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }
        private void CountCats()
        {
            string Cat = "Cat";
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from ProductTbl where PrCat='" + Cat + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            CatsLbl.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }

        private void CountFoods()
        {
            string Cat = "Food";
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from ProductTbl where PrCat='" + Cat + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            FoodsLbl.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Products Obj = new Products();
            Obj.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Employees Obj = new Employees();
            Obj.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Customers Obj = new Customers();
            Obj.Show();
            this.Hide();
        }
    }
}
