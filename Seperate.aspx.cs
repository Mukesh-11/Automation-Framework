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
    public partial class Seperate : System.Web.UI.Page
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
            Response.TransmitFile(Server.MapPath("~/Files/Template-TestData.xlsx"));
             try { Response.End(); } catch { }
        }

        protected void ImageButton10_Click(object sender, ImageClickEventArgs e)
        {
            try { Response.Redirect("Login.aspx"); } catch { }
            Session["User"] = null;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (dwnld == 1)
            {
                dwnld = 0;

                Response.Clear();
                Response.ContentType = "application/octect-stream";
                Response.AppendHeader("content-disposition", "filename=" + fname1);
                Response.TransmitFile(Server.MapPath("~/Files/Report2.xlsx"));
                 try { Response.End(); } catch { }

            }

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
            else if (TextBox1.Text == "")
            {
                Response.Write("<script>alert('Enter Column No')</script>");
            }
            else if (TextBox2.Text == "")
            {
                Response.Write("<script>alert('Enter Cell Value')</script>");
            }
            else
            {
                int tb1 = 000;
                try
                {
                    tb1 = Convert.ToInt32(TextBox1.Text);
                }
                catch
                {
                    Response.Write("<script>alert('Enter only Numeric Value in COLUMN NO')</script>");
                    tb1 = 000;
                }

                if (tb1 != 000)
                {
                    //Upload File
                    FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Files/Report1.xlsx"));
                    FileUpload2.PostedFile.SaveAs(Server.MapPath("~/Files/Report2.xlsx"));
                    try
                    {
                        int Cno = Convert.ToInt32(TextBox1.Text);
                        string CellValue = TextBox2.Text;
                        seperate(Cno, CellValue);
                        System.Diagnostics.Process.Start(Server.MapPath("~/Files/Excel.vbs"));
                        dwnld = 1;
                        Response.Write("<script>alert('Seperated Successfully...')</script>");
                    }
                    catch
                    {
                        //Display alert
                        Response.Write("<script>alert('Invalid - Report Format')</script>");
                    }
                }
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("MainPage.aspx");
        }

        public void seperate(int cno, string Cvalue)
        {
            string path1 = @Server.MapPath("~/Files/Report1.xlsx");
            string path2 = @Server.MapPath("~/Files/Report2.xlsx");

            //Report
            Excel.Application xlApp1 = new Excel.Application();
            Excel.Workbook xlWorkbook1 = xlApp1.Workbooks.Open(path1);
            //Test Data
            Excel.Application xlApp2 = new Excel.Application();
            Excel.Workbook xlWorkbook2 = xlApp2.Workbooks.Open(path2);

            Excel.Worksheet xlWorksheetLast1 = xlWorkbook1.Sheets[xlWorkbook1.Worksheets.Count];
            Excel.Range sheet1 = xlWorksheetLast1.UsedRange;

            Excel.Worksheet xlWorksheetLast2 = xlWorkbook2.Sheets[1];
            Excel.Range sheet2 = xlWorksheetLast2.UsedRange;

            int Cno = cno, a = 1;
            int rowCount1 = sheet1.Rows.Count;
            int rowCount2 = sheet2.Rows.Count;
            int colCount2 = sheet2.Columns.Count;


            xlApp1.DisplayAlerts = false;

            Excel.Worksheet newSheet = (Excel.Worksheet)xlWorkbook2.Sheets.Add(Before: xlWorkbook2.Worksheets[1]);

            xlWorksheetLast2.Range["A1:EA1"].Copy();
            Excel.Range r = newSheet.Cells[a, 1];
            newSheet.Paste(r);

            for (int i = 3; i <= rowCount1 - 4; i++)
            {
                string CellValue = "";
                try
                {
                    CellValue = sheet1.Cells[i, Cno].Value2.ToString();
                }
                catch { }
                if (CellValue.ToLower().Equals(Cvalue.ToLower()))
                {
                    string sno1 = sheet1.Cells[i, 2].Value2.ToString();
                    for (int j = 2; j <= rowCount2; j++)
                    {
                        string sno2 = sheet2.Cells[j, 1].Value2.ToString();
                        if (sno1 == sno2)
                        {
                            a += 1;
                            xlWorksheetLast2.Range["A" + j + ":EA" + j].Copy();
                            Excel.Range rr = newSheet.Cells[a, 1];
                            newSheet.Paste(rr);
                            goto down;
                        }
                    }
                }
            down: { }
            }


            //Save
            xlWorkbook2.Save();
            xlWorkbook1.Close();
            xlWorkbook2.Close();

            //Clear garbage values

            GC.Collect();
            GC.WaitForPendingFinalizers();


            Marshal.ReleaseComObject(sheet1);
            Marshal.ReleaseComObject(sheet2);
            Marshal.ReleaseComObject(newSheet);
            Marshal.ReleaseComObject(xlWorkbook1);
            Marshal.ReleaseComObject(xlWorkbook2);
            Marshal.ReleaseComObject(xlApp1);
            Marshal.ReleaseComObject(xlApp2);

        }

    }
}