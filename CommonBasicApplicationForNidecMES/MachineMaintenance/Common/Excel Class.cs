using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Common
{
    public class Excel_Class
    {
        public void exportexcel(ref DataGridViewCommon dgv, string link, string filename)
        {
            try
            {
                Excel.Application excelApp = new Excel.Application();
                excelApp.Workbooks.Add();
                Excel.Worksheet ws = excelApp.ActiveSheet;
                // column headings
                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    ws.Cells[1, (i + 1)] = dgv.Columns[i].HeaderText;
                }
                // rows
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    for (int j = 0; j < dgv.Columns.Count; j++)
                    {
                        if (dgv[j, i].Value != null)

                            ws.Cells[(i + 2), (j + 1)] = dgv[j, i].Value.ToString();
                    }
                }
                excelApp.Visible = true;

                ws.SaveAs(link + @"\" + filename + ".xlsx");
            }
            catch
            {
                MessageBox.Show("ERROR. Please create folder " + link + " to save as...");
                return;
            }
        }

        public void Export(ref DataGridViewCommon dgv, string filename)
        {
            try
            {
                Excel.Application excelApp = new Excel.Application();
                excelApp.Workbooks.Add();
                Excel.Worksheet ws = excelApp.ActiveSheet;
                // column headings
                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    ws.Cells[1, (i + 1)] = dgv.Columns[i].HeaderText;
                }
                // rows
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    for (int j = 0; j < dgv.Columns.Count; j++)
                    {
                        if (dgv[j, i].Value != null)

                            ws.Cells[(i + 2), (j + 1)] = dgv[j, i].Value.ToString();
                    }
                }
                excelApp.Visible = true;

                //ws.SaveAs(link + @"\" + filename + ".xlsx");
            }
            catch
            {
                MessageBox.Show("ERROR. Can not export this data...");
                return;
            }
        }
    }
}
