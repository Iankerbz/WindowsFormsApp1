using Spire.Xls;
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


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Form2 form2 = new Form2();

        //string[] Student = new string[5];
        //int i = 0;
        public Form1()
        {
            InitializeComponent();
        }

        


        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string data = "";
            string data1 = "";
            string data2 = "";
            string data3 = "";
            string data4 = "";
            string address = txtAddress.Text;
            string email = txtEmail.Text;
            //string birthday = 
            string age = txtAge.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            data += txtName.Text;

            lblError.Text = checkEmpty();
            return;
            

            if (rdoMale.Checked )
            {
                data1 = rdoMale.Text;
            }
            else
            {
                data1 = rdoFemale.Text;
            }

           

            if (chkBasketball.Checked)
            {
                data2 += chkBasketball.Text;  
            }
            if (chkVolleyball.Checked)
            {
                data2 += chkVolleyball.Text;
            }
            if (chkSoccer.Checked)
            {
                data2 += chkSoccer.Text;
            }

            data3 += cmbFavColor.Text;

            data4 += txtSaying.Text;

            //form2.insert(txtName.Text, data, data2, data3, data4);
            Workbook workbook = new Workbook();
            workbook.LoadFromFile("C:\\Users\\ACT-STUDENT\\Downloads\\Book1.xlsx");
            Worksheet sheet = workbook.Worksheets[0];
            int row = sheet.Rows.Length +1;
            sheet.Range[row, 1].Value = name;
            sheet.Range[row, 2].Value = data1;
            sheet.Range[row, 3].Value = data2;
            sheet.Range[row, 4].Value = data3;
            sheet.Range[row, 5].Value = address;
            sheet.Range[row, 6].Value = email;
            //sheet.Range[row, 7].Value = birthday
            sheet.Range[row, 8].Value = age;
            sheet.Range[row, 9].Value = username;
            sheet.Range[row, 10].Value = password;
            sheet.Range[row, 11].Value = data4;
            sheet.Range[row, 6].Value = "1";

            //march 19
            workbook.SaveToFile("C:\\Users\\ACT-STUDENT\\Downloads\\Book1.xlsx", ExcelVersion.Version2016);
            DataTable dt = sheet.ExportDataTable();
            form2.dataGridView1.DataSource = dt;

            MessageBox.Show("Successfully Added!");

            txtName.Clear();
            rdoMale.Checked = false;
            rdoFemale.Checked = false;
            chkBasketball.Checked = false;
            chkVolleyball.Checked = false;
            chkSoccer.Checked = false;
            cmbFavColor.SelectedIndex = -1;
            txtAddress.Clear();
            txtEmail.Clear();
            txtAge.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            txtSaying.Clear();

            txtName.Focus();

            //Student[i] = data;
            //i++;


        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            form2.Show();
            //string val = "";
            //for(int x = 0; x < Student.Length; x++)
            //{
            //    val += "[" + x + "] = " + Student[x] + "\n";
            //}
            //MessageBox.Show(val);
        }

        private void txtSaying_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string data = "";
            string data2 = "";
            string data3 = "";
            string data4 = "";
            data += txtName.Text;
            string address = txtAddress.Text;
            string email = txtEmail.Text;
            //string birthday = 
            string age = txtAge.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            lblError.Text = checkEmpty();
            return;



            if (rdoMale.Checked)
            {
                data = rdoMale.Text;
            }
            else
            {
                data = rdoFemale.Text;
            }



            if (chkBasketball.Checked)
            {
                data2 += chkBasketball.Text;
            }
            if (chkVolleyball.Checked)
            {
                data2 += chkVolleyball.Text;
            }
            if (chkSoccer.Checked)
            {
                data2 += chkSoccer.Text;
            }

            data3 += cmbFavColor.Text;

            data4 += txtSaying.Text;

            //form2.updated(Convert.ToInt32(lblID.Text),txtName.Text, data, data2, data3, data4);
            //MessageBox.Show("Successfully Updated!");
            Workbook workbook = new Workbook();
            workbook.LoadFromFile("C:\\Users\\ACT-STUDENT\\Downloads\\Book1.xlsx");
            Worksheet sheet = workbook.Worksheets[0];

            int row = form2.dataGridView1.CurrentCell.RowIndex + 2;
            sheet.Range[row, 1].Value = name;
            sheet.Range[row, 2].Value = data;
            sheet.Range[row, 3].Value = data2;
            sheet.Range[row, 4].Value = data3;
            sheet.Range[row, 5].Value = address;
            sheet.Range[row, 6].Value = email;
            //sheet.Range[row, 7].Value = birthday
            sheet.Range[row, 8].Value = age;
            sheet.Range[row, 9].Value = username;
            sheet.Range[row, 10].Value = password;
            sheet.Range[row, 11].Value = data4;

            workbook.SaveToFile("C:\\Users\\ACT-STUDENT\\Downloads\\Book1.xlsx", ExcelVersion.Version2016);

            //march 19 
            DataTable dt = sheet.ExportDataTable();
            form2.dataGridView1.DataSource = dt;

            MessageBox.Show("Successfully Updated!");
            btnAdd.Visible = true;
            btnUpdate.Visible = false;


            txtName.Clear();
            rdoMale.Checked = false;
            rdoFemale.Checked = false;
            chkBasketball.Checked = false;
            chkVolleyball.Checked = false;
            chkSoccer.Checked = false;
            cmbFavColor.SelectedIndex = -1;
            txtAddress.Clear();
            txtEmail.Clear();
            txtAge.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            txtSaying.Clear();

            txtName.Focus();
        }

        private void cmbFavColor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnBrowsePic_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtPP.Text = openFileDialog.FileName;
            }
        }

        public string checkEmpty()
        {
            string error = "";
            foreach (Control c in Controls)
            {
                if (c is TextBox)
                {
                    if (c.Text == "")
                    {
                        error += c.Name + " is Empty. +\n ";
                    }
                }
            }
            return error;
        }

        private void lblError_Click(object sender, EventArgs e)
        {
            lblError.Text = checkEmpty();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime bday = DateTime.Parse(dateTimePicker1.Text);
            int age = DateTime.Now.Year - bday.Year;

            if (DateTime.Now < bday.AddYears(age))
            {
                age--;
            }

            txtAge.Text = age.ToString();
        }
    }
}
