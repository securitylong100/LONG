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
        public void exportexcelGA1(ref DataGridViewCommon dgv, string link, string filename, string model, string line, string dateFrom, string dateTo)
        {
            try
            {
                Excel.Application excelApp = new Excel.Application();
                excelApp.Workbooks.Add();
                Excel.Worksheet ws = excelApp.ActiveSheet;

                ws.Cells[1, 1] = "Model:"; ws.Cells[1, 2] = model;
                ws.Cells[1, 3] = "Line:"; ws.Cells[1, 4] = line;
                ws.Cells[2, 1] = "From;"; ws.Cells[2, 2] = dateFrom;
                ws.Cells[2, 3] = "To:"; ws.Cells[2, 4] = dateTo;
                // column headings
                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    ws.Cells[4, (i + 1)] = dgv.Columns[i].HeaderText;
                }
                // rows

                for (int j = 0; j < dgv.Columns.Count; j++)
                {
                    for (int i = 0; i < dgv.Rows.Count; i++)
                    {
                        ws.Cells[(i + 5), (j + 1)] = dgv[j, i].Value.ToString();
                        if (i < dgv.RowCount - 1)
                        {
                            if (dgv.Rows[i].Cells["process"].Value.ToString() == dgv.Rows[i + 1].Cells["process"].Value.ToString())
                            {
                                ws.Range[ws.Cells[i + 5, 1], ws.Cells[i + 6, 1]].Merge();
                            }
                        }
                    }
                }
                excelApp.Visible = true;
                if (link.Length == 3)
                {
                    ws.SaveAs(link + filename + ".xlsx");
                }
                else ws.SaveAs(link + @"\" + filename + ".xlsx");
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
