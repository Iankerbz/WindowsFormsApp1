using Spire.Xls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            LoadExcelFile();
        }
        public void LoadExcelFile()
        {
            Workbook workbook = new Workbook();
            workbook.LoadFromFile(@"C:\Users\ACT-STUDENT\Downloads\Book1.xlsx");
            Worksheet sheet = workbook.Worksheets[0];
            DataTable dt = sheet.ExportDataTable();

            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void insert(string Name, string Gender, string Hobbies, string Color, string address, string email, string age, string username, string password ,string Sayings)
        {
            int y = dataGridView1.Rows.Add(Name, Gender, Hobbies, Color, Sayings);
            this.dataGridView1.Rows[y].Cells[0].Value = Name;
            this.dataGridView1.Rows[y].Cells[1].Value = Gender;
            this.dataGridView1.Rows[y].Cells[2].Value = Hobbies;
            this.dataGridView1.Rows[y].Cells[3].Value = Color;
            this.dataGridView1.Rows[y].Cells[4].Value = address;
            this.dataGridView1.Rows[y].Cells[5].Value = email;
            this.dataGridView1.Rows[y].Cells[7].Value = age;
            this.dataGridView1.Rows[y].Cells[8].Value = username;
            this.dataGridView1.Rows[y].Cells[9].Value = password;
            this.dataGridView1.Rows[y].Cells[10].Value = Sayings;
        }

        public void updated(int ID, string Name, string Gender, string Hobbies, string Color, string address, string email, string age, string username, string password, string Sayings)
        {
            
            this.dataGridView1.Rows[ID].Cells[0].Value = Name;
            this.dataGridView1.Rows[ID].Cells[1].Value = Gender;
            this.dataGridView1.Rows[ID].Cells[2].Value = Hobbies;
            this.dataGridView1.Rows[ID].Cells[3].Value = Color;
            this.dataGridView1.Rows[ID].Cells[4].Value = address;
            this.dataGridView1.Rows[ID].Cells[5].Value = email;
            this.dataGridView1.Rows[ID].Cells[7].Value = age;
            this.dataGridView1.Rows[ID].Cells[8].Value = username;
            this.dataGridView1.Rows[ID].Cells[9].Value = password;
            this.dataGridView1.Rows[ID].Cells[10].Value = Sayings;
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult Exit;
            Exit = MessageBox.Show("Are you sure you want to exit?", "EXIT", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Exit == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to delete?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    dataGridView1.Rows.Remove(row);

                    //march 20

                    Workbook book = new Workbook();
                    book.LoadFromFile(@"C:\Users\ACT-STUDENT\Downloads\Book1.xlsx");
                    Worksheet sheet = book.Worksheets[0];

                    int r = dataGridView1.CurrentCell.RowIndex + 3;
                    sheet.Range[r, 6].Value = "0";


                    book.SaveToFile(@"C:\Users\ACT-STUDENT\Downloads\Book1.xlsx", ExcelVersion.Version2016);

                    //march 19
                    DataTable dataTable = sheet.ExportDataTable();
                    dataGridView1.DataSource = dataTable;

                    MessageBox.Show("Successfully Deleted!");

                }
            }


        }
            //foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            //{
            //    DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this row?", "Confirmation", MessageBoxButtons.YesNo);
            //    if (dialogResult == DialogResult.Yes)
            //    {
            //        foreach (DataGridViewCell cell in row.Cells)
            //        {
            //            cell.Value = null;
            //        }
            //    }   
                //MessageBox.Show("Are you sure you want to delete?");
                //dataGridView1.Rows.Remove(row);
            
            
        

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int g = dataGridView1.CurrentCell.RowIndex;

            Form1 form = (Form1)Application.OpenForms["Form1"];

            form.txtName.Text = dataGridView1.Rows[g].Cells[0].Value.ToString();
            string gender = dataGridView1.Rows[g].Cells[1].Value.ToString();
            if (gender == "Male")
            {
                form.rdoMale.Checked = true;
            }
            else
            {
                form.rdoFemale.Checked = true;
            }
            string hobbies = dataGridView1.Rows[g].Cells[2].Value.ToString();
            string[] h = hobbies.Split(',');
            foreach (string val in h)
            {
                if (val.Trim() == "Basketball")
                {
                    form.chkBasketball.Checked = true;
                }
                if (val.Trim() == "Volleyball")
                {
                    form.chkVolleyball.Checked = true;
                }
                if (val.Trim() == "Soccer")
                {
                    form.chkSoccer.Checked = true;
                }
            }
            form.cmbFavColor.SelectedItem = dataGridView1.Rows[g].Cells[3].Value.ToString();
            form.txtAddress.Text = dataGridView1.Rows[g].Cells[4].Value.ToString();
            form.txtEmail.Text = dataGridView1.Rows[g].Cells[5].Value.ToString();
            form.txtAge.Text = dataGridView1.Rows[g].Cells[7].Value.ToString();
            form.txtUsername.Text = dataGridView1.Rows[g].Cells[8].Value.ToString();
            form.txtPassword.Text = dataGridView1.Rows[g].Cells[9].Value.ToString();
            form.txtSaying.Text = dataGridView1.Rows[g].Cells[10].Value.ToString();

            //form.lblID.Text = g.ToString();
            form.btnAdd.Visible = false;
            form.btnUpdate.Visible = true;

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Begin:
            {
                dataGridView1.ClearSelection();
                bool Itemfound = false;

                try
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells[0].Value != null && row.Cells[0].Value.ToString().Equals(txtSearch.Text))
                        {
                            row.Selected = true;
                            Itemfound = true;
                            break;
                        }
                    }

                    if (!Itemfound)
                    {
                        throw new Exception("Item was not in the list.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Search not found: " + ex.Message);
                }

                finally
                {
                    txtSearch.Clear();
                }

                goto Begin;
            }


        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Clear?", "Confirmation", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    dataGridView1.ClearSelection();
                }
            }
        }
    }
}
