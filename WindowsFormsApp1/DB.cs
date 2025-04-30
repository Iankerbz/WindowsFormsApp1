using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Spire.Xls;

namespace WindowsFormsApp1
{
    public partial class DB: Form
    {
        Workbook workbook = new Workbook();
        Form1 form1 = new Form1();
        public DB()
        {
            InitializeComponent();
            lblActive.Text = Showcount(13, "1").ToString();
            lblInactive.Text = Showcount(13, "0").ToString();
            lblMale.Text = Showcount(2, "Male").ToString();
            lblFemale.Text = Showcount(2, "Female").ToString();
            lblSoccer.Text = Showcount(3, "Soccer").ToString();
            lblBasketball.Text = Showcount(3, "Baketball").ToString();
            lblVolleyball.Text = Showcount(3, "Volleyball").ToString();
            lblRed.Text = Showcount(4, "Red").ToString();
            lblBlue.Text = Showcount(4, "Blue").ToString();
            lblPink.Text = Showcount(4, "Purple").ToString();
            lblCS.Text = Showcount(9, "CS").ToString();
            lblBSIT.Text = Showcount(9, "BSIT").ToString();
            lblCpE.Text = Showcount(9, "CpE").ToString();
        }

        public void Showlogs(DataGridView d)
        {
            Workbook workbook = new Workbook();
            workbook.LoadFromFile(@"C:\Users\ACT-STUDENT\Downloads\Book1.xlsx");
            Worksheet worksheet = workbook.Worksheets[1];
            DataTable dataTable = worksheet.ExportDataTable();
            d.DataSource = dataTable;
        }

        public int Showcount(int c, string val)
        {
            Workbook workbook = new Workbook();
            workbook.LoadFromFile(@"C:\Users\ACT-STUDENT\Downloads\Book1.xlsx");
            Worksheet worksheet = workbook.Worksheets[0];
            int r = worksheet.Rows.Length;
            int counter = 0;

            for (int i = 2; i < r; i++)
            {
                if (worksheet.Range[i, c].Value == val)
                {
                    counter++;
                }
            }
            return counter;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnLogs_Click(object sender, EventArgs e)
        {
            form1.Show();
        }
    }
}
