using Spire.Xls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class LoginForm : Form
    {
        DB dashboard = new DB();
        myLogs logs = new myLogs();

        //Form1 f1 = new Form1();
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            Workbook workbook = new Workbook();
            workbook.LoadFromFile("C:\\Users\\ACT-STUDENT\\Downloads\\Book1.xlsx");
            Worksheet sheet = workbook.Worksheets[0];
            int row = sheet.Rows.Length;

            myLogs logs = new myLogs();
            //logs.insertLogs(txtUsername.Text, "Successfully Added!");

            bool log = false;

            for (int i = 2; i <= row; i++)
            {
                if (sheet.Range[i, 4].Value == txtUsername.Text && sheet.Range[i, 5].Value == txtPassword.Text)
                {
                    //FINALS
                    dashboard.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    dashboard.pictureBox1.Image = Image.FromFile(@"" + sheet.Range[i, 14].Value);
                    logs.insertLogs(txtUsername.Text, "Successfully Added!");
                    dashboard.lblName.Text = txtUsername.Text;
                    dashboard.lblDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
                    log = true;
                    break;

                    //march 19
                    //MessageBox.Show("Login Successful!");
                    //db.Show();
                    //this.Hide();



                }
                else
                {
                    log = false;
                }
            }
            if (log == true)
            {
                MessageBox.Show("Login Successful!");
                dashboard.Show();
                this.Hide();
               
            }
            else
            {
                MessageBox.Show("Username and Password invalid. Please try again. ");
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
