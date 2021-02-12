using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.IO;

namespace aUTOMATION
{
    public partial class Replace : System.Web.UI.Page
    {
        public static int dwnld;
        public static string fname1, fname2;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("content-disposition", "filename=Template.xlsx");
            Response.TransmitFile(Server.MapPath("~/Files/Template.xlsx"));
             try { Response.End(); } catch { }
        }

        protected void ImageButton10_Click(object sender, ImageClickEventArgs e)
        {
            try { Response.Redirect("Login.aspx"); } catch { }
            Session["User"] = null;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            fname1 = FileUpload1.FileName;
            fname2 = FileUpload2.FileName;

            if (fname1 == null || fname1 == "")
            {
                Response.Write("<script>alert('Upload Primary Report')</script>");
            }
            else if (fname2 == null || fname2 == "")
            {
                Response.Write("<script>alert('Upload Secondary Report')</script>");
            }
            else if (!fname1.Contains(".xlsx") || !fname1.Contains(".xls"))
            {
                Response.Write("<script>alert('Invalid - Primary Report File Format')</script>");
            }
            else if (!fname2.Contains(".xlsx") || !fname2.Contains(".xls"))
            {
                Response.Write("<script>alert('Invalid - Secondary Report File Format')</script>");
            }
            else
            {
                //Upload File
                FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Files/Report1.xlsx"));
                FileUpload2.PostedFile.SaveAs(Server.MapPath("~/Files/Report2.xlsx"));
                try
                {
                    replace();
                    System.Diagnostics.Process.Start(Server.MapPath("~/Files/Excel.vbs"));
                    dwnld = 1;
                    Response.Write("<script>alert('Replaced Successfully...')</script>");
                }
                catch
                {
                    //Display alert
                    Response.Write("<script>alert('Invalid - Report Format')</script>");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (dwnld == 1)
            {
                dwnld = 0;

                Response.Clear();
                Response.ContentType = "application/octect-stream";
                Response.AppendHeader("content-disposition", "filename=" + fname1);
                Response.TransmitFile(Server.MapPath("~/Files/Report1.xlsx"));
                 try { Response.End(); } catch { }
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("MainPage.aspx");
        }

        public void replace()
        {
            string path1 = @Server.MapPath("~/Files/Report1.xlsx");
            string path2 = @Server.MapPath("~/Files/Report2.xlsx");

            //Report1
            Excel.Application xlApp1 = new Excel.Application();
            Excel.Workbook xlWorkbook1 = xlApp1.Workbooks.Open(path1);

            //Report2
            Excel.Application xlApp2 = new Excel.Application();
            Excel.Workbook xlWorkbook2 = xlApp2.Workbooks.Open(path2);

            //Test Execution Report 1
            Excel.Worksheet xlWorksheetLast1 = xlWorkbook1.Sheets[xlWorkbook1.Worksheets.Count];
            Excel.Range lastSheet1 = xlWorksheetLast1.UsedRange;

            int rowCount1 = lastSheet1.Rows.Count;

            //Test Execution Report 2
            Excel.Worksheet xlWorksheetLast2 = xlWorkbook2.Sheets[xlWorkbook2.Worksheets.Count];
            Excel.Range lastSheet2 = xlWorksheetLast2.UsedRange;

            int totalSheets1 = xlWorkbook1.Worksheets.Count;
            int rowCount2 = lastSheet2.Rows.Count;

            xlApp1.DisplayAlerts = false;

            //Delete unwanted Sheets - 1
            xlApp1.DisplayAlerts = false;

            int rowCount11 = rowCount1 - 6;
            int totalSheets11 = totalSheets1 - 1;

            for (int a = totalSheets11; a > rowCount11; a--)
            {
                Excel.Worksheet xlWorksheet1 = xlWorkbook1.Worksheets[a];
                xlWorksheet1.Delete();
            }

            for (int i = 3; i <= rowCount2 - 4; i++)
            {
                string slno2 = lastSheet2.Cells[i, 2].Value2.ToString();
                xlWorksheetLast2.Range["B" + i + ":M" + i + ""].Copy();

                for (int j = 3; j <= rowCount1 - 4; j++)
                {

                    string slno1 = lastSheet1.Cells[j, 2].Value2.ToString();

                    if (slno1 == slno2)
                    {
                        Excel.Range r = lastSheet1.Cells[j, 2];
                        xlWorksheetLast1.Paste(r);

                        Excel.Worksheet s2 = xlWorkbook2.Sheets[(i - 2)];
                        Excel.Worksheet s1 = xlWorkbook1.Sheets[(j - 2)];
                        s1.UsedRange.EntireRow.EntireColumn.Delete();
                        s2.UsedRange.Copy();
                        Excel.Range r1 = s1.Cells[1, 1];
                        s1.Paste(r1);

                        break;
                    }
                }


            }


            //4lines
            int pass = 0;
            int fail = 0;

            for (int k = 3; k <= rowCount1 - 4; k++)
            {
                string finalResult = lastSheet1.Cells[k, 8].Value2.ToString();
                if (finalResult.ToUpper() == "PASS")
                {
                    pass += 1;
                }
                else
                {
                    fail += 1;
                }
            }

            xlWorksheetLast1.Range["E" + (rowCount1 - 3) + ":K" + (rowCount1 - 3) + ""].Copy();
            Excel.Range rr = lastSheet1.Range["E" + (rowCount1 - 2) + ":K" + (rowCount1 - 2) + ""];
            xlWorksheetLast1.Paste(rr);

            xlWorksheetLast1.Range["E" + (rowCount1 - 2) + ":K" + (rowCount1 - 2) + ""].Value = "=SUM(E3:E" + (rowCount1 - 4) + ")";
            xlWorksheetLast1.Range["E" + (rowCount1 - 1) + ":K" + (rowCount1 - 1) + ""].Value = pass;
            xlWorksheetLast1.Range["E" + rowCount1 + ":K" + rowCount1 + ""].Value = fail;


            xlApp1.DisplayAlerts = true;

            xlWorkbook1.Save();
            xlWorkbook1.Close();
            xlWorkbook2.Close();

            GC.Collect();
            GC.WaitForPendingFinalizers();

            Marshal.ReleaseComObject(xlWorksheetLast1);
            Marshal.ReleaseComObject(xlWorksheetLast2);
            Marshal.ReleaseComObject(xlWorkbook1);
            Marshal.ReleaseComObject(xlApp1);
            Marshal.ReleaseComObject(xlWorkbook2);
            Marshal.ReleaseComObject(xlApp2);

        }

    }
}