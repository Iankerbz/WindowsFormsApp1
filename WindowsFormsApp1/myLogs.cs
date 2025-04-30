using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spire.Xls;

namespace WindowsFormsApp1
{
    internal class myLogs
    {
        Workbook workbook = new Workbook();

        public void insertLogs(string user, string message)
        {
            workbook.LoadFromFile(@"");
            Worksheet sheet = workbook.Worksheets[1];
            int r = sheet.Rows.Length + 1;
            sheet.Range[r, 1].Value = user;
            sheet.Range[r, 2].Value = message;
            sheet.Range[r, 3].Value = DateTime.Now.ToString("MM/dd/yyyy");
            sheet.Range[r, 4].Value = DateTime.Now.ToString("hh:mm:ss tt");
            workbook.SaveToFile(@"");
        }
    }
}
