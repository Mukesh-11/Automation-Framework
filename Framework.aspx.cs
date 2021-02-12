using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;
using ClassLibrary7.reports;
using System.IO;
using System.Drawing.Imaging;
using System.Data.SqlClient;
using System.Data;
using OpenQA.Selenium.Interactions;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.Extensions;
using System.Diagnostics;
using System.Text;

namespace aUTOMATION
{
    public partial class Framework : System.Web.UI.Page
    {
        public static int dwnld;
        public static string fname1;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        public class GlobalVariables
        {
            public static int countOfTestMethods = 0, tot = countOfTestMethods, passed = 0, faild = 0, totalsteps = 170, r = 0;
            public static dynamicemailtemplate dct = new ClassLibrary7.reports.dynamicemailtemplate();
            public static string Asmbname, prjpath, name, methodname, Filename, link, TC = "0", PC = "0", FC = "0";
        }

        public static string f1 = DateTime.Now.ToString("MM-dd_HHmmss");
        int /*count,*/ i = 0, g = 0;

        public static string url;
        public static string appname, headless, browser, prjname, nagvpath, scPath, ExpFilePath, g1, txt = "", txt1 = "", mailID, mailID1;


        public void Screenshot()
        {

            string alertText = "";

            GlobalVariables.link = @scPath + prjname + g + " " + DateTime.Now.ToString("yyyy - MM - dd_HHmmss") + ".png";

            try { alertText = driver.SwitchTo().Alert().Text; } catch { }

            if (alertText == "")
            {
                GlobalVariables.link = @scPath + prjname + g + " " + DateTime.Now.ToString("yyyy - MM - dd_HHmmss") + ".png";
            }
            else
            {
                driver.SwitchTo().Alert().Accept();

                GlobalVariables.link = @scPath + prjname + g + " " + alertText + DateTime.Now.ToString("yyyy - MM - dd_HHmmss") + ".png";
            }

            GetEntireScreenshot().Save(GlobalVariables.link);

            //Bitmap bmpScreenshot = new Bitmap(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height, PixelFormat.Format32bppArgb);
            //Graphics gfxScreenshot = Graphics.FromImage(bmpScreenshot);
            //gfxScreenshot.CopyFromScreen(Screen.PrimaryScreen.WorkingArea.X, Screen.PrimaryScreen.WorkingArea.Y, 0, 0, Screen.PrimaryScreen.WorkingArea.Size, CopyPixelOperation.SourceCopy);
            //bmpScreenshot.Save(GlobalVariables.link, ImageFormat.Png);
        }

        public void methodnamefiningfunction(string mname)
        {
            if (mname != "")
            {
                GlobalVariables.methodname = mname;
                i = i + 1;
            }
        }

        public static Excel.Application xlApps;
        public static Excel.Workbook xlWorkbooks;
        public static Excel.Worksheet xlWorksheets, xlWorksheets2, xlWorksheets3, xlWorksheets4;
        public static Excel.Range sheet1, sheet2, sheet3, sheet4;

        public static IWebDriver driver;
        public static WebDriverWait Wait, Wait1;
        public static string ParentWindow, ChildWindow1, scrollElementIntoMiddle = "var viewPortHeight = Math.max(document.documentElement.clientHeight, window.innerHeight || 0);"
                                             + "var elementTop = arguments[0].getBoundingClientRect().top;"
                                             + "window.scrollBy(0, elementTop-(viewPortHeight/2));";

        public static string sno, testcaseid, testcasedesc, Expected_Status, MenuID, Username, Password, LoginUnit, AccPeriod, value;
        public int a, n1 = 1, d, tv;

        public static string mname, action, condition, id, xpath, name, lt, plt, css, thread1, val, ModeCondition, dummy, TableAction;
        public static int thread, cnt;

        public static string[] xpath1;

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("content-disposition", "filename=Template.xlsx");
            Response.TransmitFile(Server.MapPath("~/Files/Template-Framework.xlsx"));
            try { Response.End(); } catch (ThreadAbortException) { }
        }

        protected void ImageButton10_Click(object sender, ImageClickEventArgs e)
        {
            try { Response.Redirect("Login.aspx"); } catch { }
            Session["User"] = null;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            fname1 = FileUpload1.FileName;


            if (fname1 == null || fname1 == "")
            {
                Response.Write("<script>alert('Upload File')</script>");
            }
            else if (!fname1.Contains(".xlsx") || !fname1.Contains(".xls"))
            {
                Response.Write("<script>alert('Invalid - File Format')</script>");
            }
            else
            {
                //Upload File
                try
                {
                    Process.Start(Server.MapPath("~/Files/Excel.vbs"));
                    Process.Start(Server.MapPath("~/Files/Chrome.vbs"));
                }
                catch { }
                FileUpload1.PostedFile.SaveAs(Server.MapPath("~/UploadedFiles/" + fname1));
                try
                {
                    framework();
                    System.Diagnostics.Process.Start(Server.MapPath("~/Files/Excel.vbs"));
                    dwnld = 1;
                    Response.Write("<script>alert('Executed Successfully...')</script>");
                }
                catch //(Exception ex)
                {
                    //Display alert

                    //StreamWriter objWriter = default(StreamWriter);
                    //string filename = @"\\192.169.1.55\Automation reports\STFC\Exception\Error" + DateTime.Now.ToString("yyyy-MM-dd_HHmmss") + ".txt";
                    //Console.WriteLine(ex.Message);
                    //if ((!System.IO.Directory.Exists(filename)))
                    //{
                    //    objWriter = File.CreateText(filename);
                    //    objWriter.WriteLine(ex.ToString());
                    //    objWriter.Close();
                    //}

                    Response.Write("<script>alert('Invalid - Format')</script>");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(Server.MapPath("~/Files/Excel.vbs"));
                Process.Start(Server.MapPath("~/Files/Chrome.vbs"));
            }
            catch { }
            if (dwnld == 1)
            {
                dwnld = 0;

                Response.Clear();
                Response.ContentType = "application/octect-stream";
                Response.AppendHeader("content-disposition", "filename=" + prjname + ".xlsx");
                Response.TransmitFile(Server.MapPath("~/Files/aUTOMATION.xlsx"));
                try { Response.End(); } catch { }
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("MainPage.aspx");
        }

        public void framework()
        {
            GlobalVariables.countOfTestMethods = 0; GlobalVariables.tot = GlobalVariables.countOfTestMethods; GlobalVariables.passed = 0; GlobalVariables.faild = 0; GlobalVariables.totalsteps = 170; GlobalVariables.r = 0;
            GlobalVariables.TC = "0"; GlobalVariables.PC = "0"; GlobalVariables.FC = "0";

            f1 = DateTime.Now.ToString("MM-dd_HHmmss");

            i = 0; g = 0;

            txt = ""; txt1 = "";

            Username = ""; Password = ""; LoginUnit = ""; AccPeriod = "";

            Thread.Sleep(8000);
            string path1 = "";

            path1 = @Server.MapPath("~/UploadedFiles/" + fname1 + ".xlsx");


            Excel.Application xlApp = null;

            //Report1
            try { xlApp = new Excel.Application(); }
            catch
            {
                Thread.Sleep(1500);
                xlApp = new Excel.Application();
            }

            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(path1);

            //Sheet1
            Excel.Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range sheet11 = xlWorksheet.UsedRange;

            //Sheet2
            Excel.Worksheet xlWorksheet2 = xlWorkbook.Sheets[2];
            Excel.Range sheet21 = xlWorksheet2.UsedRange;

            //Sheet3
            Excel.Worksheet xlWorksheet3 = xlWorkbook.Sheets[3];
            Excel.Range sheet31 = xlWorksheet3.UsedRange;

            //Sheet4
            Excel.Worksheet xlWorksheet4 = xlWorkbook.Sheets[4];
            Excel.Range sheet41 = xlWorksheet4.UsedRange;

            int rowCount1 = sheet11.Rows.Count;
            int colCount1 = sheet11.Columns.Count;

            int rowCount2 = sheet31.Rows.Count;
            int colCount2 = sheet31.Columns.Count;

            int rowCount4 = sheet41.Rows.Count;
            int colCount4 = sheet41.Columns.Count;

            appname = sheet21.Cells[2, 1].Value2.ToString();
            prjname = fname1.Replace(".xlsx", "").Replace(".xls", "");
            headless = sheet21.Cells[2, 2].Value2.ToString();
            browser = sheet21.Cells[2, 3].Value2.ToString();
            url = sheet21.Cells[2, 4].Value2.ToString();
            scPath = sheet21.Cells[2, 5].Value2.ToString();
            ExpFilePath = sheet21.Cells[2, 6].Value2.ToString();


            //if (appname == "STFC" && appname == "SCUF") mailID = "sureshkumar.s@novactech.in";
            //else if (appname == "Cameo" && appname == "Property(Admin)" && appname == "Property(Buyer)" && appname == "Gold") mailID = "rajdurai@novactech.in";
            /*else */
            mailID = ""; mailID1 = "";


            if (sheet11.Cells[2, 4] != null && sheet11.Cells[2, 4].Value2 != null)
            {
                MenuID = sheet11.Cells[2, 4].Value2.ToString();
            }
            else
            {
                MenuID = "";
            }


            //===========================================================================================//



            GlobalVariables.r = rowCount1;


            GC.Collect();
            GC.WaitForPendingFinalizers();

            Marshal.ReleaseComObject(sheet11);
            Marshal.ReleaseComObject(sheet21);
            Marshal.ReleaseComObject(sheet31);
            Marshal.ReleaseComObject(sheet41);
            Marshal.ReleaseComObject(xlWorksheet);
            Marshal.ReleaseComObject(xlWorkbook);
            Marshal.ReleaseComObject(xlApp);


            for (int i = 2; i <= rowCount1; i++)
            {

                dummy = "";

                g = g + 1;

                g1 = g.ToString();


                GlobalVariables.dct.starttime_method();


                GlobalVariables.passed = 0;
                GlobalVariables.faild = 0;
                GlobalVariables.countOfTestMethods = 0;

                GlobalVariables.name = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
                GlobalVariables.Filename = prjname;
                GlobalVariables.prjpath = AppDomain.CurrentDomain.BaseDirectory + "\\" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + ".dll";
                GlobalVariables.dct.CreateExcel(ref GlobalVariables.Filename, ref g1, ref GlobalVariables.r);



                Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
                Wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(5));


                try
                {
                    a = 13;

                    xlApps = new Excel.Application();
                    xlWorkbooks = xlApps.Workbooks.Open(path1);

                    //Sheet1
                    xlWorksheets = xlWorkbooks.Sheets[1];
                    sheet1 = xlWorksheets.UsedRange;

                    //Sheet2
                    xlWorksheets2 = xlWorkbooks.Sheets[2];
                    sheet2 = xlWorksheets2.UsedRange;

                    //Sheet3
                    xlWorksheets3 = xlWorkbooks.Sheets[3];
                    sheet3 = xlWorksheets3.UsedRange;

                    //Sheet4
                    xlWorksheets4 = xlWorkbooks.Sheets[4];
                    sheet4 = xlWorksheets4.UsedRange;


                    if (sheet1.Cells[i, 3] != null && sheet1.Cells[i, 3].Value2 != null)
                    {
                        testcaseid = sheet1.Cells[i, 3].Value2.ToString();
                    }
                    else
                    {
                        testcaseid = "";
                    }

                    if (sheet1.Cells[i, 4] != null && sheet1.Cells[i, 4].Value2 != null)
                    {
                        MenuID = sheet1.Cells[i, 4].Value2.ToString();
                    }
                    else
                    {
                        MenuID = "";
                    }

                    if (sheet1.Cells[i, 9] != null && sheet1.Cells[i, 9].Value2 != null)
                    {
                        testcasedesc = sheet1.Cells[i, 9].Value2.ToString();
                    }
                    else
                    {
                        testcasedesc = "";
                    }

                    if (sheet1.Cells[i, 12] != null && sheet1.Cells[i, 12].Value2 != null)
                    {
                        Expected_Status = sheet1.Cells[i, 12].Value2.ToString();
                    }
                    else
                    {
                        Expected_Status = "";
                    }


                    if (sheet2.Cells[2, 7] != null && sheet2.Cells[2, 7].Value2 != null)
                    {
                        Username = sheet2.Cells[2, 7].Value2.ToString();
                    }
                    else if (sheet1.Cells[i, a] != null && sheet1.Cells[i, a].Value2 != null)
                    {
                        Username = sheet1.Cells[i, a].Value2.ToString();
                        a += 1;
                    }

                    if (sheet2.Cells[2, 8] != null && sheet2.Cells[2, 8].Value2 != null)
                    {
                        Password = sheet2.Cells[2, 8].Value2.ToString();
                    }
                    else if (sheet1.Cells[i, a] != null && sheet1.Cells[i, a].Value2 != null)
                    {
                        Password = sheet1.Cells[i, a].Value2.ToString();
                        a += 1;
                    }


                    if (appname == "Cameo" || appname == "STFC" || appname == "SCUF")
                    {
                        if (sheet2.Cells[2, 9] != null && sheet2.Cells[2, 9].Value2 != null)
                        {
                            LoginUnit = sheet2.Cells[2, 9].Value2.ToString();
                        }
                        else if (sheet1.Cells[i, a] != null && sheet1.Cells[i, a].Value2 != null)
                        {
                            LoginUnit = sheet1.Cells[i, a].Value2.ToString();
                            a += 1;
                        }
                    }

                    if (appname == "UNO")
                    {
                        if (sheet2.Cells[2, 10] != null && sheet2.Cells[2, 10].Value2 != null)
                        {
                            AccPeriod = sheet2.Cells[2, 10].Value2.ToString();
                        }
                        else if (sheet1.Cells[i, a] != null && sheet1.Cells[i, a].Value2 != null)
                        {
                            AccPeriod = sheet1.Cells[i, a].Value2.ToString();
                            a += 1;
                        }
                    }


                    if (driver == null || a > 13)
                    {
                        //Launching URL
                        if (appname == "UNO")
                        {
                            unologin(url, browser);
                        }
                        else if (appname == "Property(Admin)")
                        {
                            PropertyAdmin(url, browser);
                        }
                        else if (appname == "Property(Buyer)")
                        {
                            PropertyBuyer(url, browser);
                        }
                        else if (appname == "Gold")
                        {
                            GoldLogin(url, browser);
                        }
                        else if (appname == "Cameo")
                        {
                            cameologin(url, browser);
                        }
                        else if (appname == "STFC")
                        {
                            STFClogin(url, browser);
                        }
                        else if (appname == "SCUF")
                        {
                            SCUFlogin(url, browser);
                        }
                        else if (appname == "Others")
                        {
                            Launch(url, browser);
                        }
                        else { throw new Exception(); }
                    }


                    for (int j = 2; j <= rowCount2; j++)
                    {

                        if (sheet3.Cells[j, 2] != null && sheet3.Cells[j, 2].Value2 != null)
                        {
                            mname = sheet3.Cells[j, 2].Value2.ToString();
                        }
                        else
                        {
                            mname = "";
                        }

                        if (sheet3.Cells[j, 3] != null && sheet3.Cells[j, 3].Value2 != null)
                        {
                            action = sheet3.Cells[j, 3].Value2.ToString();
                        }
                        else
                        {
                            action = "";
                        }

                        if (sheet3.Cells[j, 4] != null && sheet3.Cells[j, 4].Value2 != null)
                        {
                            if (action == "Dynamic Table") TableAction = sheet3.Cells[j, 4].Value2.ToString();
                            else action = sheet3.Cells[j, 4].Value2.ToString();
                        }
                        else
                        {
                            TableAction = "";
                        }

                        if (sheet3.Cells[j, 5] != null && sheet3.Cells[j, 5].Value2 != null)
                        {
                            condition = sheet3.Cells[j, 5].Value2.ToString();
                        }
                        else
                        {
                            condition = "";
                        }

                        if (sheet3.Cells[j, 6] != null && sheet3.Cells[j, 6].Value2 != null)
                        {
                            id = sheet3.Cells[j, 6].Value2.ToString();
                        }
                        else
                        {
                            id = "";
                        }

                        if (sheet3.Cells[j, 7] != null && sheet3.Cells[j, 7].Value2 != null)
                        {
                            xpath = sheet3.Cells[j, 7].Value2.ToString();
                        }
                        else
                        {
                            xpath = "";
                        }

                        if (sheet3.Cells[j, 8] != null && sheet3.Cells[j, 8].Value2 != null)
                        {
                            name = sheet3.Cells[j, 8].Value2.ToString();
                        }
                        else
                        {
                            name = "";
                        }

                        if (sheet3.Cells[j, 9] != null && sheet3.Cells[j, 9].Value2 != null)
                        {
                            lt = sheet3.Cells[j, 9].Value2.ToString();
                        }
                        else
                        {
                            lt = "";
                        }

                        if (sheet3.Cells[j, 10] != null && sheet3.Cells[j, 10].Value2 != null)
                        {
                            plt = sheet3.Cells[j, 10].Value2.ToString();
                        }
                        else
                        {
                            plt = "";
                        }

                        if (sheet3.Cells[j, 11] != null && sheet3.Cells[j, 11].Value2 != null)
                        {
                            css = sheet3.Cells[j, 11].Value2.ToString();
                        }
                        else
                        {
                            css = "";
                        }

                        if (sheet3.Cells[j, 12] != null && sheet3.Cells[j, 12].Value2 != null)
                        {
                            thread1 = sheet3.Cells[j, 12].Value2.ToString();
                        }
                        else
                        {
                            thread1 = "";
                        }

                        if (sheet3.Cells[j, 13] != null && sheet3.Cells[j, 13].Value2 != null)
                        {
                            val = sheet3.Cells[j, 13].Value2.ToString();
                        }
                        else
                        {
                            val = "";
                        }

                        if (condition == "Last Iteration")
                        {
                            if (g != (GlobalVariables.r - 1))
                            {
                                goto last;
                            }
                        }

                        if (sheet3.Cells[j, 14] != null && sheet3.Cells[j, 14].Value2 != null)
                        {
                            ModeCondition = sheet3.Cells[j, 14].Value2.ToString();
                        }
                        else
                        {
                            ModeCondition = "";
                        }


                        if (ModeCondition != "")
                        {
                            if (dummy == "")
                            {
                                dummy = sheet1.Cells[i, a].Value2.ToString();
                                a += 1;
                            }

                            if (!ModeCondition.ToLower().Trim().Contains(dummy.ToLower())) goto last;
                        }

                        //if (action == "Save Value")
                        //{

                        //    if (sheet1.Cells[i, a] != null && sheet1.Cells[i, a].Value2 != null)
                        //    {
                        //        value = sheet1.Cells[i, a].Value2.ToString();
                        //    }
                        //    else
                        //    {
                        //        value = "";
                        //    }
                        //    sheet3.Cells[1, 15].Value2 = "";
                        //    sheet3.Cells[1, 15].Value2 = value;
                        //    xlWorkbooks.Save();

                        //    goto last;
                        //}



                        //Getting Values

                        if (action == "Dynamic Table") goto down;

                        if (txt == "" && ((action.Contains("Click") && condition != "") || action.Contains("TextBox") || action == "DatePicker" || action == "File Upload" || action.Contains("DropDown") || action == "LookUp"))
                        {
                            if (condition == "Not Null")
                            {

                                if (sheet1.Cells[i, a] != null && sheet1.Cells[i, a].Value2 != null)
                                {
                                    value = sheet1.Cells[i, a].Value2.ToString();
                                }
                                else
                                {
                                    value = "";
                                }

                                if (value != "")
                                {
                                    a = a + 1;
                                }
                                else
                                {
                                    a = a + 1;
                                    goto last;
                                }
                            }

                            else if (condition == "Else Equal To")
                            {
                                if (sheet1.Cells[i, a] != null && sheet1.Cells[i, a].Value2 != null)
                                {
                                    value = sheet1.Cells[i, a].Value2.ToString();
                                }
                                else
                                {
                                    value = "";
                                }

                                if (value.ToUpper().Contains(val.ToUpper())) { }
                                else goto last;
                            }
                            else if (condition == "Not Equal To")
                            {
                                if (sheet1.Cells[i, a] != null && sheet1.Cells[i, a].Value2 != null)
                                {
                                    value = sheet1.Cells[i, a].Value2.ToString();
                                }
                                else
                                {
                                    value = "";
                                }

                                if (value.ToUpper() != val.ToUpper())
                                {
                                    a = a + 1;
                                }
                                else
                                {
                                    a = a + 1;
                                    goto last;
                                }
                            }

                            else if (condition == "Else Not Equal To")
                            {
                                if (sheet1.Cells[i, a] != null && sheet1.Cells[i, a].Value2 != null)
                                {
                                    value = sheet1.Cells[i, a].Value2.ToString();
                                }
                                else
                                {
                                    value = "";
                                }

                                if (value.ToUpper() != val.ToUpper()) { }
                                else goto last;
                            }
                            else if (condition == "Equal To")
                            {
                                if (sheet1.Cells[i, a] != null && sheet1.Cells[i, a].Value2 != null)
                                {
                                    value = sheet1.Cells[i, a].Value2.ToString();
                                }
                                else
                                {
                                    value = "";
                                }

                                if (value.ToUpper().Contains(val.ToUpper()))
                                {
                                    a = a + 1;
                                }
                                else
                                {
                                    a = a + 1;
                                    goto last;
                                }
                            }
                            else if (val != "" && (condition == "" || condition == "Last Iteration"))
                            {
                                value = val;
                            }
                            else
                            {
                                if (sheet1.Cells[i, a] != null && sheet1.Cells[i, a].Value2 != null)
                                {
                                    value = sheet1.Cells[i, a].Value2.ToString();
                                }
                                else
                                {
                                    value = "";
                                }
                                a = a + 1;
                            }

                        }
                        else
                        {
                            if (condition == "Text Not Null")
                            {
                                if (txt != "")
                                {
                                    value = txt;
                                    txt = "";
                                }
                                else
                                {
                                    txt = "";
                                    goto last;
                                }
                            }
                            else if (condition == "Text Equal To")
                            {
                                if (!txt.ToUpper().Contains(val.ToUpper()))
                                {
                                    txt = "";
                                    goto last;
                                }
                                else
                                {
                                    value = txt;
                                    txt = "";
                                }
                            }
                            else if (condition == "Else Text Equal To")
                            {
                                if (!txt.ToUpper().Contains(val.ToUpper()))
                                {
                                    goto last;
                                }
                                else
                                {
                                    value = txt;
                                }
                            }
                            else if (condition == "Text Not Equal To")
                            {
                                if (txt.ToUpper().Equals(val.ToUpper()))
                                {
                                    txt = "";
                                    goto last;
                                }
                                else
                                {
                                    value = txt;
                                    txt = "";
                                }
                            }
                            else if (condition == "Else Text Not Equal To")
                            {
                                if (txt.ToUpper().Equals(val.ToUpper()))
                                {
                                    goto last;
                                }
                                else
                                {
                                    value = txt;
                                }
                            }
                        }

                        //Thread
                        if (thread1 != "")
                        {
                            if (!thread1.Contains(",")) Thread.Sleep(Convert.ToInt32(thread1));
                        }


                        down:


                        //Click
                        if (action == "Click")
                        {
                            if (id != "")
                            {
                                byid(id, mname);
                                goto last;
                            }
                            else if (xpath != "")
                            {
                                byxp(xpath, mname);
                                goto last;
                            }
                            else if (name != "")
                            {
                                byname(name, mname);
                                goto last;
                            }
                            else if (lt != "")
                            {
                                bylt(lt, mname);
                                goto last;
                            }
                            else if (plt != "")
                            {
                                byplt(plt, mname);
                                goto last;
                            }
                            else if (css != "")
                            {
                                bycss(css, mname);
                                goto last;
                            }
                            else goto last;
                        }

                        //TextBox
                        else if (action == "TextBox")
                        {
                            if (id != "")
                            {
                                byid(id, value, mname);
                                goto last;
                            }
                            else if (xpath != "")
                            {
                                byxp(xpath, value, mname);
                                goto last;
                            }
                            else if (name != "")
                            {
                                byname(name, value, mname);
                                goto last;
                            }
                            else if (lt != "")
                            {
                                bylt(lt, value, mname);
                                goto last;
                            }
                            else if (plt != "")
                            {
                                byplt(plt, value, mname);
                            }
                            else if (css != "")
                            {
                                bycss(css, value, mname);
                                goto last;
                            }
                            else goto last;
                        }

                        else if (action == "File Upload")
                        {
                            if (id != "")
                            {
                                fbyid(id, value, mname);
                                goto last;
                            }
                            else if (xpath != "")
                            {
                                fbyxp(xpath, value, mname);
                                goto last;
                            }
                            else if (name != "")
                            {
                                fbyname(name, value, mname);
                                goto last;
                            }
                            else if (lt != "")
                            {
                                fbylt(lt, value, mname);
                                goto last;
                            }
                            else if (plt != "")
                            {
                                fbyplt(plt, value, mname);
                            }
                            else if (css != "")
                            {
                                fbycss(css, value, mname);
                                goto last;
                            }
                            else goto last;
                        }

                        //DropDown
                        else if (action == "DropDown")
                        {
                            if (id != "")
                            {
                                bytextid(id, value, mname);
                                goto last;
                            }
                            else if (xpath != "")
                            {
                                bytextxp(xpath, value, mname);
                                goto last;
                            }
                            else if (name != "")
                            {
                                bytextname(name, value, mname);
                                goto last;
                            }

                            else goto last;
                        }

                        //TryCatch Click
                        else if (action == "TryCatch Click")
                        {
                            if (id != "")
                            {
                                try
                                {
                                    byid(id, mname);
                                    goto last;
                                }
                                catch { }
                            }
                            else if (xpath != "")
                            {
                                try
                                {
                                    byxp(xpath, mname);
                                    goto last;
                                }
                                catch { }
                            }
                            else if (name != "")
                            {
                                try
                                {
                                    byname(name, mname);
                                    goto last;
                                }
                                catch { }
                            }
                            else if (lt != "")
                            {
                                try
                                {
                                    bylt(lt, mname);
                                    goto last;
                                }
                                catch { }
                            }
                            else if (plt != "")
                            {
                                try
                                {
                                    byplt(plt, mname);
                                    goto last;
                                }
                                catch { }
                            }
                            else if (css != "")
                            {
                                try
                                {
                                    bycss(css, mname);
                                    goto last;
                                }
                                catch { }
                            }
                            else goto last;
                        }

                        //TryCatch TextBox
                        else if (action == "TryCatch TextBox")
                        {
                            if (id != "")
                            {
                                try
                                {
                                    byid(id, value, mname);
                                    goto last;
                                }
                                catch { }
                            }
                            else if (xpath != "")
                            {
                                try
                                {
                                    byxp(xpath, value, mname);
                                    goto last;
                                }
                                catch { }
                            }
                            else if (name != "")
                            {
                                try
                                {
                                    byname(name, value, mname);
                                    goto last;
                                }
                                catch { }
                            }
                            else if (lt != "")
                            {
                                try
                                {
                                    bylt(lt, value, mname);
                                    goto last;
                                }
                                catch { }
                            }
                            else if (plt != "")
                            {
                                try
                                {
                                    byplt(plt, value, mname);
                                    goto last;
                                }
                                catch { }
                            }
                            else if (css != "")
                            {
                                try
                                {
                                    bycss(css, value, mname);
                                    goto last;
                                }
                                catch { }
                            }
                            else goto last;
                        }

                        //TryCatch DropDown
                        else if (action == "TryCatch DropDown")
                        {
                            if (id != "")
                            {
                                try
                                {
                                    bytextid(id, value, mname);
                                    goto last;
                                }
                                catch { }
                            }
                            else if (xpath != "")
                            {
                                try
                                {
                                    bytextxp(xpath, value, mname);
                                    goto last;
                                }
                                catch { }
                            }
                            else if (name != "")
                            {
                                try
                                {
                                    bytextname(name, value, mname);
                                    goto last;
                                }
                                catch { }
                            }

                            else goto last;
                        }

                        else if (action == "Switch To New Window")
                        {

                            switchWindow();

                            goto last;
                        }

                        else if (action == "Switch To Parent Window")
                        {

                            parentWindow();

                            goto last;
                        }

                        //JS Click
                        else if (action == "JS Click")
                        {
                            if (id != "")
                            {
                                jbyid(id, mname);
                                goto last;
                            }
                            else if (xpath != "")
                            {
                                jbyxp(xpath, mname);
                                goto last;
                            }
                            else if (name != "")
                            {
                                jbyname(name, mname);
                                goto last;
                            }
                            else if (lt != "")
                            {
                                jbylt(lt, mname);
                                goto last;
                            }
                            else if (plt != "")
                            {
                                jbyplt(plt, mname);
                                goto last;
                            }
                            else if (css != "")
                            {
                                jbycss(css, mname);
                                goto last;
                            }
                            else goto last;
                        }

                        //Try Catch - JS Click
                        else if (action == "TryCatch JS Click")
                        {
                            try
                            {
                                if (id != "")
                                {
                                    jbyid(id, mname);
                                    goto last;
                                }
                                else if (xpath != "")
                                {
                                    jbyxp(xpath, mname);
                                    goto last;
                                }
                                else if (name != "")
                                {
                                    jbyname(name, mname);
                                    goto last;
                                }
                                else if (lt != "")
                                {
                                    jbylt(lt, mname);
                                    goto last;
                                }
                                else if (plt != "")
                                {
                                    jbyplt(plt, mname);
                                    goto last;
                                }
                                else if (css != "")
                                {
                                    jbycss(css, mname);
                                    goto last;
                                }
                                else goto last;
                            }
                            catch { goto last; }
                        }

                        else if (action == "Dynamic Table")
                        {
                            string[] tableAction = TableAction.Split(',');
                            string[] Xpath = xpath.Split(',');
                            string[] Mname = mname.Split(',');
                            string[] val1 = val.Split(',');
                            string[] condition1 = condition.Split(',');
                            string[] thread2 = thread1.Split(',');

                            //Note: Xpath[0]=Count

                            Thread.Sleep(4000);
                            int count = driver.FindElements(By.XPath(Xpath[0])).Count;

                            for (int d = 1; d <= count; d++)
                            {
                                for (int m = 0; m < tableAction.Length; m++)
                                {

                                    if (m == 0) tv = 0;

                                    string[] valu = new string[50];

                                    if ((tableAction[m].Contains("Click") && condition1[m] != "") || tableAction[m].Contains("TextBox") || tableAction[m] == "DatePicker" || tableAction[m] == "File Upload" || tableAction[m] == "LookUp" || tableAction[m].Contains("DropDown"))
                                    {
                                        if (txt == "")
                                        {
                                            if (condition1[m] == "Not Null")
                                            {
                                                if (sheet1.Cells[i, (a + tv)] != null && sheet1.Cells[i, (a + tv)].Value2 != null)
                                                {
                                                    valu = sheet1.Cells[i, (a + tv)].Value2.ToString().Split(',');
                                                }

                                                try
                                                {
                                                    if (valu[d - 1] == "")
                                                    {
                                                        tv += 1;
                                                        goto last1;
                                                    }
                                                }
                                                catch { tv += 1; goto last1; }
                                            }

                                            else if (condition1[m] == "Else Equal To")
                                            {
                                                if (sheet1.Cells[i, (a + tv)] != null && sheet1.Cells[i, (a + tv)].Value2 != null)
                                                {
                                                    valu = sheet1.Cells[i, (a + tv)].Value2.ToString().Split(',');
                                                }

                                                try
                                                {
                                                    if (valu[d - 1].ToUpper().Contains(val1[m].ToUpper())) { }
                                                    else goto last1;
                                                }
                                                catch { goto last1; }
                                            }
                                            else if (condition1[m] == "Not Equal To")
                                            {
                                                if (sheet1.Cells[i, (a + tv)] != null && sheet1.Cells[i, (a + tv)].Value2 != null)
                                                {
                                                    valu = sheet1.Cells[i, (a + tv)].Value2.ToString().Split(',');
                                                }

                                                try
                                                {
                                                    if (valu[d - 1].ToUpper() != val1[m].ToUpper())
                                                    {
                                                        tv += 1;
                                                    }
                                                    else
                                                    {
                                                        tv += 1;
                                                        goto last1;
                                                    }
                                                }
                                                catch { goto last1; }
                                            }

                                            else if (condition1[m] == "Else Not Equal To")
                                            {
                                                if (sheet1.Cells[i, (a + tv)] != null && sheet1.Cells[i, (a + tv)].Value2 != null)
                                                {
                                                    valu = sheet1.Cells[i, (a + tv)].Value2.ToString().Split(',');
                                                }

                                                try
                                                {
                                                    if (valu[d - 1].ToUpper() != val1[m].ToUpper()) { }
                                                    else goto last1;
                                                }
                                                catch { goto last1; }
                                            }
                                            else if (condition1[m] == "Equal To")
                                            {
                                                if (sheet1.Cells[i, (a + tv)] != null && sheet1.Cells[i, (a + tv)].Value2 != null)
                                                {
                                                    valu = sheet1.Cells[i, (a + tv)].Value2.ToString().Split(',');
                                                }

                                                try
                                                {
                                                    if (valu[d - 1].ToUpper().Contains(val1[m].ToUpper()))
                                                    {
                                                        tv += 1;
                                                    }
                                                    else
                                                    {
                                                        tv += 1;
                                                        goto last1;
                                                    }
                                                }
                                                catch { goto last1; }
                                            }
                                            else if (val1[m] != "" && (condition1[m] == "" || condition1[m] == "Last Iteration"))
                                            {
                                                valu[d - 1] = val1[m];
                                            }
                                            else
                                            {
                                                if (sheet1.Cells[i, (a + tv)] != null && sheet1.Cells[i, (a + tv)].Value2 != null)
                                                {
                                                    valu[d - 1] = sheet1.Cells[i, (a + tv)].Value2.ToString();
                                                }

                                                tv += 1;
                                            }

                                        }
                                        else
                                        {
                                            if (condition == "Text Not Null")
                                            {
                                                if (txt != "")
                                                {
                                                    txt = "";
                                                }
                                                else
                                                {
                                                    txt = "";
                                                    goto last1;
                                                }
                                            }
                                            else if (condition1[m] == "Text Equal To")
                                            {
                                                if (sheet1.Cells[i, (a + tv)] != null && sheet1.Cells[i, (a + tv)].Value2 != null)
                                                {
                                                    valu = sheet1.Cells[i, (a + tv)].Value2.ToString().Split(',');
                                                }

                                                if (!txt.ToUpper().Contains(valu[d - 1].ToUpper()))
                                                {
                                                    txt = "";
                                                    goto last2;
                                                }
                                                else
                                                {
                                                    tv += 1;
                                                    txt = "";
                                                }
                                            }
                                            else if (condition1[m] == "Else Text Equal To")
                                            {
                                                if (sheet1.Cells[i, (a + tv)] != null && sheet1.Cells[i, (a + tv)].Value2 != null)
                                                {
                                                    valu = sheet1.Cells[i, (a + tv)].Value2.ToString().Split(',');
                                                }

                                                if (!txt.ToUpper().Contains(valu[d - 1].ToUpper()))
                                                {
                                                    goto last2;
                                                }
                                            }
                                            else if (condition1[m] == "Text Not Equal To")
                                            {
                                                if (sheet1.Cells[i, (a + tv)] != null && sheet1.Cells[i, (a + tv)].Value2 != null)
                                                {
                                                    valu = sheet1.Cells[i, (a + tv)].Value2.ToString().Split(',');
                                                }

                                                if (txt.ToUpper().Equals(valu[d - 1].ToUpper()))
                                                {
                                                    txt = "";
                                                    goto last2;
                                                }
                                                else
                                                {
                                                    tv += 1;
                                                    txt = "";
                                                }
                                            }
                                            else if (condition1[m] == "Else Text Not Equal To")
                                            {
                                                if (sheet1.Cells[i, (a + tv)] != null && sheet1.Cells[i, (a + tv)].Value2 != null)
                                                {
                                                    valu = sheet1.Cells[i, (a + tv)].Value2.ToString().Split(',');
                                                }

                                                if (txt.ToUpper().Equals(val1[m].ToUpper()))
                                                {
                                                    goto last2;
                                                }
                                            }
                                        }
                                    }

                                    if (thread2[d - 1] != "")
                                    {
                                        Thread.Sleep(Convert.ToInt32(thread2[d - 1]));
                                    }

                                    if ((tableAction[m] == "Click" && condition != "") || tableAction[m] == "TextBox" || tableAction[m] == "File Upload" || tableAction[m] == "LookUp" || tableAction[m] == "DropDown" || tableAction[m] == "TryCatch TextBox" || tableAction[m] == "TryCatch DropDown")
                                    {
                                        try { if (valu[d - 1] == "") goto last1; } catch { goto last1; }
                                    }

                                    //Xpath[0] is for row count
                                    xpath = Xpath[m + 1];
                                    if (xpath.Contains('+'))
                                    {
                                        xpath1 = xpath.Split('"');
                                        xpath = xpath1[0] + d + xpath1[2];
                                    }
                                    mname = Mname[m];
                                    val = val1[m];

                                    if (tableAction[m] == "Click")
                                    {
                                        if (xpath != "")
                                        {
                                            byxp(xpath, mname);
                                        }
                                    }

                                    //TextBox
                                    else if (tableAction[m] == "TextBox")
                                    {
                                        if (xpath != "")
                                        {
                                            byxp(xpath, valu[d - 1], mname);
                                        }
                                    }

                                    else if (tableAction[m] == "File Upload")
                                    {
                                        if (xpath != "")
                                        {
                                            fbyxp(xpath, valu[d - 1], mname);
                                        }
                                    }

                                    //DropDown
                                    else if (tableAction[m] == "DropDown")
                                    {
                                        if (xpath != "")
                                        {
                                            bytextxp(xpath, valu[d - 1], mname);
                                        }
                                    }

                                    else if (tableAction[m] == "LookUp")
                                    {
                                        if (xpath != "")
                                        {
                                            Start();
                                            methodnamefiningfunction(mname);
                                            IWebElement s = Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(xpath)));
                                            LookupHandling(s, valu[d - 1]);
                                            End();
                                        }
                                    }

                                    else if (tableAction[m] == "DatePicker")
                                    {
                                        if (xpath != "")
                                        {
                                            Start();
                                            methodnamefiningfunction(mname);
                                            IWebElement s = Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(xpath)));
                                            DatePicker(s, valu[d - 1]);
                                            End();
                                        }
                                    }

                                    //TryCatch Click
                                    else if (tableAction[m] == "TryCatch Click")
                                    {
                                        if (xpath != "")
                                        {
                                            try
                                            {
                                                byxp(xpath, mname);
                                            }
                                            catch { }
                                        }
                                    }

                                    //TryCatch TextBox
                                    else if (tableAction[m] == "TryCatch TextBox")
                                    {
                                        if (xpath != "")
                                        {
                                            try
                                            {
                                                byxp(xpath, valu[d - 1], mname);
                                            }
                                            catch { }
                                        }
                                    }

                                    //TryCatch DropDown
                                    else if (tableAction[m] == "TryCatch DropDown")
                                    {
                                        if (xpath != "")
                                        {
                                            try
                                            {
                                                bytextxp(xpath, valu[d - 1], mname);
                                            }
                                            catch { }
                                        }
                                    }

                                    else if (tableAction[m] == "Switch To New Window")
                                    {
                                        switchWindow();
                                    }

                                    else if (tableAction[m] == "Switch To Parent Window")
                                    {
                                        parentWindow();
                                    }

                                    //JS Click
                                    else if (tableAction[m] == "JS Click")
                                    {
                                        if (xpath != "")
                                        {
                                            jbyxp(xpath, mname);
                                        }
                                    }

                                    //Try Catch - JS Click
                                    else if (tableAction[m] == "TryCatch JS Click")
                                    {
                                        try
                                        {
                                            if (xpath != "")
                                            {
                                                jbyxp(xpath, mname);
                                            }
                                        }
                                        catch { }
                                    }

                                    //Alert Accept
                                    else if (tableAction[m] == "Alert Accept")
                                    {
                                        alert(mname);
                                    }

                                    //Alert Dismiss
                                    else if (tableAction[m] == "Alert Dismiss")
                                    {
                                        alertDismiss(mname);
                                    }

                                    else if (tableAction[m] == "Keyboard Keys")
                                    {
                                        SendKeys.SendWait("{" + val + "}");
                                    }

                                    else if (tableAction[m] == "Get Text From Alert")
                                    {
                                        try { txt = driver.SwitchTo().Alert().Text; } catch { }
                                    }

                                    else if (tableAction[m] == "Get Text")
                                    {
                                        if (xpath != "")
                                        {
                                            try { txt = driver.FindElement(By.XPath(xpath)).Text; } catch { }
                                        }
                                    }

                                    else if (tableAction[m] == "Get Attribute")
                                    {
                                        if (xpath != "")
                                        {
                                            txt = driver.FindElement(By.XPath(xpath)).GetAttribute(val);
                                        }
                                    }

                                    else if (tableAction[m] == "Get Text - SubString")
                                    {
                                        txt1 = "";

                                        string[] v = val.Split(',');

                                        int m1 = Convert.ToInt32(v[0]);
                                        int n = Convert.ToInt32(v[1]);
                                        if (xpath != "")
                                        {
                                            txt1 = driver.FindElement(By.XPath(xpath)).Text;
                                            txt = txt1.Substring(m1, n);
                                        }
                                    }

                                    else if (tableAction[m] == "Action(MoveToElement)")
                                    {
                                        Actions dummy = new Actions(driver);
                                        if (xpath != "")
                                        {
                                            IWebElement element = Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
                                            dummy.MoveToElement(element).Build().Perform();
                                        }
                                    }

                                    else if (tableAction[m] == "MoveToElement & Click")
                                    {
                                        Actions dummy = new Actions(driver);
                                        if (xpath != "")
                                        {
                                            IWebElement element = Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
                                            dummy.MoveToElement(element).DoubleClick(element).Build().Perform();
                                        }
                                    }

                                    else if (tableAction[m] == "Scroll")
                                    {
                                        txt1 = "";

                                        if (val != "")
                                        {
                                            string[] v = val.Split(',');

                                            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollBy(" + v[0] + "," + v[1] + ")");
                                        }
                                        else
                                        {
                                            if (xpath != "")
                                            {
                                                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView();", driver.FindElement(By.XPath(xpath)));
                                            }
                                        }
                                    }

                                    else if (tableAction[m] == "Close driver")
                                    {
                                        driver.Close();
                                    }

                                    else if (tableAction[m] == "Throw Ex")
                                    {
                                        Start();
                                        methodnamefiningfunction(mname);
                                        throw new Exception();
                                    }

                                    else
                                    {
                                        Start();
                                        methodnamefiningfunction(mname);
                                        throw new Exception();
                                    }


                                    last1: { }
                                }
                                last2: { }
                            }

                            cnt = 0;

                            for (int n = 0; n < tableAction.Length; n++)
                            {
                                if (tableAction[n] == "TextBox" || tableAction[n] == "File Upload" || tableAction[n] == "LookUp" || tableAction[n] == "DropDown" || tableAction[n] == "TryCatch TextBox" || tableAction[n] == "TryCatch DropDown")
                                {
                                    cnt += 1;
                                }
                                else if ((tableAction[n] == "Click" && (condition1[n] == "Equal To" || condition1[n] == "Not Equal To" || condition1[n] == "Text Equal To" || condition1[n] == "Text Not Equal To")))
                                {
                                    cnt += 1;
                                }
                            }

                            a = a + cnt;

                            goto last;

                        }

                        //Alert Accept
                        else if (action == "Alert Accept")
                        {
                            alert(mname);
                            goto last;
                        }

                        //Alert Dismiss
                        else if (action == "Alert Dismiss")
                        {
                            alertDismiss(mname);
                            goto last;
                        }

                        //ScreenShot
                        else if (action == "ScreenShot")
                        {
                            Screenshot();
                            goto last;
                        }

                        //Get Value From DB
                        else if (action == "Get Value From DB")
                        {
                            database(val);
                            goto last;
                        }

                        else if (action == "Keyboard Keys")
                        {
                            SendKeys.SendWait("{" + val + "}");
                        }

                        else if (action == "Get Text From Alert")
                        {
                            try { txt = driver.SwitchTo().Alert().Text; } catch { }
                            goto last;
                        }

                        else if (action == "Get Text")
                        {
                            try
                            {
                                if (id != "")
                                {
                                    txt = driver.FindElement(By.Id(id)).Text;
                                    goto last;
                                }
                                else if (xpath != "")
                                {
                                    txt = driver.FindElement(By.XPath(xpath)).Text;
                                    goto last;
                                }
                                else if (name != "")
                                {
                                    txt = driver.FindElement(By.Name(name)).Text;
                                    goto last;
                                }
                                else if (lt != "")
                                {
                                    txt = driver.FindElement(By.LinkText(lt)).Text;
                                    goto last;
                                }
                                else if (plt != "")
                                {
                                    txt = driver.FindElement(By.PartialLinkText(plt)).Text;
                                    goto last;
                                }
                                else if (css != "")
                                {
                                    txt = driver.FindElement(By.CssSelector(css)).Text;
                                    goto last;
                                }
                                else goto last;
                            }
                            catch { }
                        }

                        else if (action == "Get Attribute")
                        {
                            if (id != "")
                            {
                                txt = driver.FindElement(By.Id(id)).GetAttribute(val);
                                goto last;
                            }
                            else if (xpath != "")
                            {
                                txt = driver.FindElement(By.XPath(xpath)).GetAttribute(val);
                                goto last;
                            }
                            else if (name != "")
                            {
                                txt = driver.FindElement(By.Name(name)).GetAttribute(val);
                                goto last;
                            }
                            else if (lt != "")
                            {
                                txt = driver.FindElement(By.LinkText(lt)).GetAttribute(val);
                                goto last;
                            }
                            else if (plt != "")
                            {
                                txt = driver.FindElement(By.PartialLinkText(plt)).GetAttribute(val);
                                goto last;
                            }
                            else if (css != "")
                            {
                                txt = driver.FindElement(By.CssSelector(css)).GetAttribute(val);
                                goto last;
                            }
                            else goto last;
                        }

                        else if (action == "Get Text - SubString")
                        {
                            txt1 = "";

                            string[] v = val.Split(',');

                            int n1 = Convert.ToInt32(v[0]);
                            int n = Convert.ToInt32(v[1]);

                            if (id != "")
                            {
                                txt1 = driver.FindElement(By.Id(id)).Text;
                                txt = txt1.Substring(n1, n);
                                goto last;
                            }
                            else if (xpath != "")
                            {
                                txt1 = driver.FindElement(By.XPath(xpath)).Text;
                                txt = txt1.Substring(n1, n);
                                goto last;
                            }
                            else if (name != "")
                            {
                                txt1 = driver.FindElement(By.Name(name)).Text;
                                txt = txt1.Substring(n1, n);
                                goto last;
                            }
                            else if (lt != "")
                            {
                                txt1 = driver.FindElement(By.LinkText(lt)).Text;
                                txt = txt1.Substring(n1, n);
                                goto last;
                            }
                            else if (plt != "")
                            {
                                txt1 = driver.FindElement(By.PartialLinkText(plt)).Text;
                                txt = txt1.Substring(n1, n);
                                goto last;
                            }
                            else if (css != "")
                            {
                                txt1 = driver.FindElement(By.CssSelector(css)).Text;
                                txt = txt1.Substring(n1, n);
                                goto last;
                            }
                            goto last;
                        }

                        else if (action == "Remove Attribute")
                        {
                            if (id != "")
                            {
                                IWebElement element = Wait.Until(ExpectedConditions.ElementIsVisible(By.Id(id)));
                                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].removeAttribute('" + val + "')", element);
                            }
                            else if (xpath != "")
                            {
                                IWebElement element = Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
                                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].removeAttribute('" + val + "')", element);
                            }
                            else if (name != "")
                            {
                                IWebElement element = Wait.Until(ExpectedConditions.ElementIsVisible(By.Name(name)));
                                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].removeAttribute('" + val + "')", element);
                            }
                            else if (lt != "")
                            {
                                IWebElement element = Wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText(lt)));
                                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].removeAttribute('" + val + "')", element);
                            }
                            else if (plt != "")
                            {
                                IWebElement element = Wait.Until(ExpectedConditions.ElementIsVisible(By.PartialLinkText(plt)));
                                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].removeAttribute('" + val + "')", element);
                            }
                            else if (css != "")
                            {
                                IWebElement element = Wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(css)));
                                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].removeAttribute('" + val + "')", element);
                            }

                            goto last;
                        }

                        else if (action == "DatePicker")
                        {
                            Start();
                            methodnamefiningfunction(mname);
                            if (id != "")
                            {
                                IWebElement s = Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id(id)));
                                DatePicker(s, value);
                            }
                            else if (xpath != "")
                            {
                                IWebElement s = Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(xpath)));
                                DatePicker(s, value);
                            }
                            else if (name != "")
                            {
                                IWebElement s = Wait.Until(ExpectedConditions.ElementToBeClickable(By.Name(name)));
                                DatePicker(s, value);
                            }
                            else if (lt != "")
                            {
                                IWebElement s = Wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText(lt)));
                                DatePicker(s, value);
                            }
                            else if (plt != "")
                            {
                                IWebElement s = Wait.Until(ExpectedConditions.ElementToBeClickable(By.PartialLinkText(plt)));
                                DatePicker(s, value);
                            }
                            else if (css != "")
                            {
                                IWebElement s = Wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(css)));
                                DatePicker(s, value);
                            }
                            End();

                            goto last;
                        }

                        else if (action == "LookUp")
                        {
                            Start();
                            methodnamefiningfunction(mname);
                            if (id != "")
                            {
                                IWebElement s = Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id(id)));
                                LookupHandling(s, value);
                            }
                            else if (xpath != "")
                            {
                                IWebElement s = Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(xpath)));
                                LookupHandling(s, value);
                            }
                            else if (name != "")
                            {
                                IWebElement s = Wait.Until(ExpectedConditions.ElementToBeClickable(By.Name(name)));
                                LookupHandling(s, value);
                            }
                            else if (lt != "")
                            {
                                IWebElement s = Wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText(lt)));
                                LookupHandling(s, value);
                            }
                            else if (plt != "")
                            {
                                IWebElement s = Wait.Until(ExpectedConditions.ElementToBeClickable(By.PartialLinkText(plt)));
                                LookupHandling(s, value);
                            }
                            else if (css != "")
                            {
                                IWebElement s = Wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(css)));
                                LookupHandling(s, value);
                            }
                            End();

                            goto last;
                        }

                        else if (action == "Action(MoveToElement)")
                        {
                            Actions dummy = new Actions(driver);
                            if (id != "")
                            {
                                IWebElement element = Wait.Until(ExpectedConditions.ElementIsVisible(By.Id(id)));
                                dummy.MoveToElement(element).Build().Perform();
                                goto last;
                            }
                            else if (xpath != "")
                            {
                                IWebElement element = Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
                                dummy.MoveToElement(element).Build().Perform();
                                goto last;
                            }
                            else if (name != "")
                            {
                                IWebElement element = Wait.Until(ExpectedConditions.ElementIsVisible(By.Name(name)));
                                dummy.MoveToElement(element).Build().Perform();
                                goto last;
                            }
                            else if (lt != "")
                            {
                                IWebElement element = Wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText(lt)));
                                dummy.MoveToElement(element).Build().Perform();
                                goto last;
                            }
                            else if (plt != "")
                            {
                                IWebElement element = Wait.Until(ExpectedConditions.ElementIsVisible(By.PartialLinkText(plt)));
                                dummy.MoveToElement(element).Build().Perform();
                                goto last;
                            }
                            else if (css != "")
                            {
                                IWebElement element = Wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(css)));
                                dummy.MoveToElement(element).Build().Perform();
                                goto last;
                            }
                            goto last;
                        }

                        else if (action == "MoveToElement & Click")
                        {
                            Actions dummy = new Actions(driver);
                            if (id != "")
                            {
                                IWebElement element = Wait.Until(ExpectedConditions.ElementIsVisible(By.Id(id)));
                                dummy.MoveToElement(element).DoubleClick(element).Build().Perform();
                                goto last;
                            }
                            else if (xpath != "")
                            {
                                IWebElement element = Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
                                dummy.MoveToElement(element).DoubleClick(element).Build().Perform();
                                goto last;
                            }
                            else if (name != "")
                            {
                                IWebElement element = Wait.Until(ExpectedConditions.ElementIsVisible(By.Name(name)));
                                dummy.MoveToElement(element).DoubleClick(element).Build().Perform();
                                goto last;
                            }
                            else if (lt != "")
                            {
                                IWebElement element = Wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText(lt)));
                                dummy.MoveToElement(element).DoubleClick(element).Build().Perform();
                                goto last;
                            }
                            else if (plt != "")
                            {
                                IWebElement element = Wait.Until(ExpectedConditions.ElementIsVisible(By.PartialLinkText(plt)));
                                dummy.MoveToElement(element).DoubleClick(element).Build().Perform();
                                goto last;
                            }
                            else if (css != "")
                            {
                                IWebElement element = Wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(css)));
                                dummy.MoveToElement(element).DoubleClick(element).Build().Perform();
                                goto last;
                            }
                            goto last;
                        }

                        else if (action == "Scroll")
                        {
                            txt1 = "";

                            if (val != "")
                            {
                                string[] v = val.Split(',');

                                ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollBy(" + v[0] + "," + v[1] + ")");

                                goto last;
                            }
                            else
                            {
                                if (id != "")
                                {
                                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView();", driver.FindElement(By.Id(id)));
                                    goto last;
                                }
                                else if (name != "")
                                {
                                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView();", driver.FindElement(By.Name(name)));
                                    goto last;
                                }
                                else if (xpath != "")
                                {
                                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView();", driver.FindElement(By.XPath(xpath)));
                                    goto last;
                                }
                                else if (lt != "")
                                {
                                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView();", driver.FindElement(By.LinkText(lt)));
                                    goto last;
                                }
                                else if (plt != "")
                                {
                                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView();", driver.FindElement(By.PartialLinkText(plt)));
                                    goto last;
                                }
                                else if (css != "")
                                {
                                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView();", driver.FindElement(By.CssSelector(css)));
                                    goto last;
                                }
                                else goto last;
                            }
                        }

                        else if (action == "Close driver")
                        {
                            driver.Close();
                            goto last;
                        }

                        else if (action == "Throw Ex")
                        {
                            Start();
                            methodnamefiningfunction(mname);
                            throw new Exception();
                        }

                        else
                        {
                            Start();
                            methodnamefiningfunction(mname);
                            throw new Exception();
                        }



                        last: { }

                    }



                    GC.Collect();
                    GC.WaitForPendingFinalizers();

                    Marshal.ReleaseComObject(sheet1);
                    Marshal.ReleaseComObject(sheet2);
                    Marshal.ReleaseComObject(sheet3);
                    Marshal.ReleaseComObject(sheet4);
                    Marshal.ReleaseComObject(xlWorksheets);
                    Marshal.ReleaseComObject(xlWorkbooks);
                    xlApps.Quit();
                    Marshal.ReleaseComObject(xlApps);

                    GlobalVariables.dct.endtime_method();
                    GlobalVariables.dct.linkforbackscreen();
                    GlobalVariables.dct.overallstatus_pass(ref GlobalVariables.r, g, ref GlobalVariables.link, Expected_Status, testcaseid, g1, testcasedesc);
                    GlobalVariables.dct.excelclosefunction();

                }


                catch (Exception ex)
                {

                    StreamWriter objWriter = default(StreamWriter);
                    string filename = @ExpFilePath + @"\" + prjname + g + DateTime.Now.ToString("yyyy-MM-dd_HHmmss") + g + ".txt";
                    Console.WriteLine(ex.Message);
                    if ((!System.IO.Directory.Exists(filename)))
                    {
                        objWriter = File.CreateText(filename);
                        objWriter.WriteLine(ex.ToString());
                        objWriter.Close();
                    }

                    for (int k = 2; k <= rowCount4; k++)
                    {


                        if (sheet4.Cells[k, 2] != null && sheet4.Cells[k, 2].Value2 != null)
                        {
                            action = sheet4.Cells[k, 2].Value2.ToString();
                        }
                        else
                        {
                            action = "";
                        }

                        if (sheet4.Cells[k, 3] != null && sheet4.Cells[k, 3].Value2 != null)
                        {
                            condition = sheet4.Cells[k, 3].Value2.ToString();
                        }
                        else
                        {
                            condition = "";
                        }

                        if (sheet4.Cells[k, 4] != null && sheet4.Cells[k, 4].Value2 != null)
                        {
                            id = sheet4.Cells[k, 4].Value2.ToString();
                        }
                        else
                        {
                            id = "";
                        }

                        if (sheet4.Cells[k, 5] != null && sheet4.Cells[k, 5].Value2 != null)
                        {
                            xpath = sheet4.Cells[k, 5].Value2.ToString();
                        }
                        else
                        {
                            xpath = "";
                        }

                        if (sheet4.Cells[k, 6] != null && sheet4.Cells[k, 6].Value2 != null)
                        {
                            name = sheet4.Cells[k, 6].Value2.ToString();
                        }
                        else
                        {
                            name = "";
                        }

                        if (sheet4.Cells[k, 7] != null && sheet4.Cells[k, 7].Value2 != null)
                        {
                            lt = sheet4.Cells[k, 7].Value2.ToString();
                        }
                        else
                        {
                            lt = "";
                        }

                        if (sheet4.Cells[k, 8] != null && sheet4.Cells[k, 8].Value2 != null)
                        {
                            plt = sheet4.Cells[k, 8].Value2.ToString();
                        }
                        else
                        {
                            plt = "";
                        }

                        if (sheet4.Cells[k, 9] != null && sheet4.Cells[k, 9].Value2 != null)
                        {
                            css = sheet4.Cells[k, 9].Value2.ToString();
                        }
                        else
                        {
                            css = "";
                        }

                        if (sheet4.Cells[k, 10] != null && sheet4.Cells[k, 10].Value2 != null)
                        {
                            thread1 = sheet4.Cells[k, 10].Value2.ToString();
                            thread = Convert.ToInt32(thread1);
                        }
                        else
                        {
                            thread1 = "";
                        }

                        if (condition == "Last Iteration")
                        {
                            if (g != (GlobalVariables.r - 1))
                            {
                                goto end;
                            }
                        }

                        if (thread1 != "")
                        {
                            Thread.Sleep(thread);
                        }

                        if (action == "Click")
                        {
                            if (id != "")
                            {
                                try
                                {
                                    Wait1.Until(ExpectedConditions.ElementToBeClickable(By.Id(id)));
                                    driver.FindElement(By.Id(id)).Click();
                                    goto end;
                                }
                                catch { }
                            }
                            else if (xpath != "")
                            {
                                try
                                {
                                    Wait1.Until(ExpectedConditions.ElementToBeClickable(By.XPath(xpath)));
                                    driver.FindElement(By.XPath(xpath)).Click();
                                    goto end;
                                }
                                catch { }
                            }
                            else if (name != "")
                            {
                                try
                                {
                                    Wait1.Until(ExpectedConditions.ElementToBeClickable(By.Name(name)));
                                    driver.FindElement(By.Name(name)).Click();
                                    goto end;
                                }
                                catch { }
                            }
                            else if (lt != "")
                            {
                                try
                                {
                                    Wait1.Until(ExpectedConditions.ElementToBeClickable(By.LinkText(lt)));
                                    driver.FindElement(By.LinkText(lt)).Click();
                                    goto end;
                                }
                                catch { }
                            }
                            else if (plt != "")
                            {
                                try
                                {
                                    Wait1.Until(ExpectedConditions.ElementToBeClickable(By.PartialLinkText(plt)));
                                    driver.FindElement(By.PartialLinkText(plt)).Click();
                                    goto end;
                                }
                                catch { }
                            }
                            else if (css != "")
                            {
                                try
                                {
                                    Wait1.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(css)));
                                    driver.FindElement(By.CssSelector(css)).Click();
                                    goto end;
                                }
                                catch { }
                            }
                            else goto end;
                        }

                        else if (action == "ScreenShot")
                        {
                            Screenshot();
                            goto end;
                        }

                        else if (action == "Switch To New Window")
                        {
                            try
                            {
                                switchWindow();
                            }
                            catch { }
                            goto end;
                        }

                        else if (action == "Switch To Parent Window")
                        {
                            try
                            {
                                parentWindow();
                            }
                            catch { }
                            goto end;
                        }

                        //JS Click
                        else if (action == "JS Click")
                        {
                            try
                            {
                                if (id != "")
                                {
                                    IWebElement a = driver.FindElement(By.Id(id));
                                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", a);
                                    goto end;
                                }
                                else if (xpath != "")
                                {
                                    IWebElement a = driver.FindElement(By.XPath(xpath));
                                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", a);
                                    goto end;
                                }
                                else if (name != "")
                                {
                                    IWebElement a = driver.FindElement(By.Name(name));
                                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", a);
                                    goto end;
                                }
                                else if (lt != "")
                                {
                                    IWebElement a = driver.FindElement(By.LinkText(lt));
                                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", a);
                                    goto end;
                                }
                                else if (plt != "")
                                {
                                    IWebElement a = driver.FindElement(By.PartialLinkText(plt));
                                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", a);
                                    goto end;
                                }
                                else if (css != "")
                                {
                                    IWebElement a = driver.FindElement(By.CssSelector(css));
                                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", a);
                                    goto end;
                                }
                                else goto end;
                            }
                            catch { goto end; }
                        }

                        else if (action == "Alert Accept")
                        {
                            try
                            {
                                Wait1.Until(ExpectedConditions.AlertIsPresent());
                                driver.SwitchTo().Alert().Accept();
                            }
                            catch { }
                            goto end;
                        }

                        //Alert Dismiss
                        else if (action == "Alert Dismiss")
                        {
                            try
                            {
                                Wait1.Until(ExpectedConditions.AlertIsPresent());
                                driver.SwitchTo().Alert().Dismiss();
                            }
                            catch { }
                            goto end;
                        }

                        else if (action == "Keyboard Keys")
                        {
                            try
                            {
                                SendKeys.SendWait("{" + val + "}");
                            }
                            catch { goto end; }
                        }

                        else if (action == "MoveToElement & Click")
                        {
                            try
                            {
                                Actions dummy = new Actions(driver);
                                if (id != "")
                                {
                                    IWebElement element = Wait1.Until(ExpectedConditions.ElementIsVisible(By.Id(id)));
                                    dummy.MoveToElement(element).DoubleClick(element).Build().Perform();
                                    goto end;
                                }
                                else if (xpath != "")
                                {
                                    IWebElement element = Wait1.Until(ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
                                    dummy.MoveToElement(element).DoubleClick(element).Build().Perform();
                                    goto end;
                                }
                                else if (name != "")
                                {
                                    IWebElement element = Wait1.Until(ExpectedConditions.ElementIsVisible(By.Name(name)));
                                    dummy.MoveToElement(element).DoubleClick(element).Build().Perform();
                                    goto end;
                                }
                                else if (lt != "")
                                {
                                    IWebElement element = Wait1.Until(ExpectedConditions.ElementIsVisible(By.LinkText(lt)));
                                    dummy.MoveToElement(element).DoubleClick(element).Build().Perform();
                                    goto end;
                                }
                                else if (plt != "")
                                {
                                    IWebElement element = Wait1.Until(ExpectedConditions.ElementIsVisible(By.PartialLinkText(plt)));
                                    dummy.MoveToElement(element).DoubleClick(element).Build().Perform();
                                    goto end;
                                }
                                else if (css != "")
                                {
                                    IWebElement element = Wait1.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(css)));
                                    dummy.MoveToElement(element).DoubleClick(element).Build().Perform();
                                    goto end;
                                }
                                goto end;
                            }
                            catch { goto end; }
                        }

                        else if (action == "Scroll")
                        {
                            try
                            {

                                if (id != "")
                                {
                                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView();", driver.FindElement(By.Id(id)));
                                    goto end;
                                }
                                else if (name != "")
                                {
                                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView();", driver.FindElement(By.Name(name)));
                                    goto end;
                                }
                                else if (xpath != "")
                                {
                                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView();", driver.FindElement(By.XPath(xpath)));
                                    goto end;
                                }
                                else if (lt != "")
                                {
                                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView();", driver.FindElement(By.LinkText(lt)));
                                    goto end;
                                }
                                else if (plt != "")
                                {
                                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView();", driver.FindElement(By.PartialLinkText(plt)));
                                    goto end;
                                }
                                else if (css != "")
                                {
                                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView();", driver.FindElement(By.CssSelector(css)));
                                    goto end;
                                }
                                else goto end;

                            }
                            catch { goto end; }
                        }

                        else if (action == "Output")
                        {
                            Console.Write(txt);
                        }

                        else if (action == "Close driver")
                        {
                            driver.Quit();
                            goto end;
                        }

                        else if (action == "Screenshot")
                        {
                            Screenshot();
                        }

                        else { throw new Exception(); }

                        end: { }

                    }

                    GC.Collect();
                    GC.WaitForPendingFinalizers();

                    Marshal.ReleaseComObject(sheet1);
                    Marshal.ReleaseComObject(sheet2);
                    Marshal.ReleaseComObject(sheet2);
                    Marshal.ReleaseComObject(xlWorksheets);
                    Marshal.ReleaseComObject(xlWorkbooks);
                    xlApps.Quit();
                    Marshal.ReleaseComObject(xlApps);



                    GlobalVariables.dct.callingcommanmethod(GlobalVariables.name, GlobalVariables.methodname);
                    GlobalVariables.dct.endtimefunction1(ref GlobalVariables.link, ref GlobalVariables.faild, ref GlobalVariables.countOfTestMethods, ref GlobalVariables.passed, ref g1, ref GlobalVariables.r);
                    //// Added for Reports- for fail iteration
                    //*******************************************************************************************//
                    GlobalVariables.dct.endtime_method();
                    GlobalVariables.dct.overallstatus_fail(ref GlobalVariables.r, g, ref GlobalVariables.link, Expected_Status, testcaseid, g1, testcasedesc);
                    //*******************************************************************************************//
                    GlobalVariables.dct.excelclosefunction();


                }

                string[] ary = new string[2];
                ary = new string[] { Login.Userr + "@novactech.in" };

                string[] ary1 = new string[9];
                if (mailID != "" && mailID1 != "") ary1 = new string[] { mailID, mailID1 };
                else if (mailID != "") ary1 = new string[] { mailID };
                else ary1 = new string[] { };

                string[] ary2 = new string[3];
                ary2 = new string[] { };

                GlobalVariables.dct.reportcalculation(ref GlobalVariables.totalsteps, GlobalVariables.r, ref GlobalVariables.countOfTestMethods, ref GlobalVariables.passed, ref GlobalVariables.faild);
                int rr = GlobalVariables.r - 1;



                ///''''''''''''''''''''''''If the value of g matches with rr then mail will be sent''''''''''''''''''''''''//

                if (g == (GlobalVariables.r - 1))
                {
                    Thread.Sleep(1000);
                    driver.Quit();
                    GlobalVariables.dct.mail(appname, url, GlobalVariables.totalsteps, ref prjname, ref nagvpath, ref GlobalVariables.Filename, ref GlobalVariables.r, ref GlobalVariables.faild, ref GlobalVariables.countOfTestMethods, ref GlobalVariables.passed, ary, ary1, ary2);
                }

                GC.Collect();

            }


        }



        public void Start()
        {
            if (mname != "")
            {
                GlobalVariables.dct.CountNumberOfTestMethods(ref GlobalVariables.countOfTestMethods, ref GlobalVariables.prjpath);
                GlobalVariables.dct.starttimefunction();
            }
        }
        public void End()
        {
            if (mname != "")
            {
                GlobalVariables.dct.callingcommanmethod(GlobalVariables.name, GlobalVariables.methodname);
                GlobalVariables.dct.endtimefunction(ref GlobalVariables.passed, ref GlobalVariables.faild, ref GlobalVariables.countOfTestMethods);
                GlobalVariables.dct.excelclosefunction();
            }
        }
        public void switchWindow()
        {
            IList<String> handles = (IList<string>)driver.WindowHandles;
            foreach (string sample in handles)
            {
                if (!sample.Equals(ParentWindow))
                {
                    string childurl = driver.SwitchTo().Window(sample).Url;

                    Wait.Until(ExpectedConditions.UrlContains(childurl));
                    driver.SwitchTo().Window(sample);
                }
            }
        }
        public void parentWindow()
        {
            driver.SwitchTo().Window(ParentWindow);
        }

        //=============================>>>>>>>>> TextBox

        public void byid(string id, string value, string action)
        {
            Start();
            methodnamefiningfunction(action);
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id(id))).Clear();
            driver.FindElement(By.Id(id)).SendKeys(value);
            End();
        }
        public void byname(string Name, string value, string action)
        {
            Start();
            methodnamefiningfunction(action);
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Name(Name))).Clear();
            driver.FindElement(By.Name(Name)).SendKeys(value);
            End();
        }

        public void byxp(string XPath, string value, string action)
        {
            Start();
            methodnamefiningfunction(action);
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(XPath))).Clear();
            driver.FindElement(By.XPath(XPath)).SendKeys(value);
            End();
        }

        public void bylt(string LinkText, string value, string action)
        {
            Start();
            methodnamefiningfunction(action);
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText(LinkText))).Clear();
            driver.FindElement(By.LinkText(LinkText)).SendKeys(value);
            End();
        }

        public void byplt(string PartialLinkText, string value, string action)
        {
            Start();
            methodnamefiningfunction(action);
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.PartialLinkText(PartialLinkText)));
            driver.FindElement(By.PartialLinkText(PartialLinkText)).SendKeys(value);
            End();
        }

        public void bycss(string css, string value, string action)
        {
            Start();
            methodnamefiningfunction(action);
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(css))).Clear();
            driver.FindElement(By.CssSelector(css)).SendKeys(value);
            End();
        }

        //=============================>>>>>>>>> File Upload

        public void fbyid(string id, string value, string action)
        {
            Start();
            methodnamefiningfunction(action);
            Thread.Sleep(1500);
            driver.FindElement(By.Id(id)).SendKeys(@value);
            End();
        }
        public void fbyname(string Name, string value, string action)
        {
            Start();
            methodnamefiningfunction(action);
            Thread.Sleep(1500);
            driver.FindElement(By.Name(Name)).SendKeys(@value);
            End();
        }

        public void fbyxp(string XPath, string value, string action)
        {
            Start();
            methodnamefiningfunction(action);
            Thread.Sleep(1500);
            driver.FindElement(By.XPath(XPath)).SendKeys(@value);
            End();
        }

        public void fbylt(string LinkText, string value, string action)
        {
            Start();
            methodnamefiningfunction(action);
            Thread.Sleep(1500);
            driver.FindElement(By.LinkText(LinkText)).SendKeys(@value);
            End();
        }

        public void fbyplt(string PartialLinkText, string value, string action)
        {
            Start();
            methodnamefiningfunction(action);
            Thread.Sleep(1500);
            driver.FindElement(By.PartialLinkText(PartialLinkText)).SendKeys(@value);
            End();
        }

        public void fbycss(string css, string value, string action)
        {
            Start();
            methodnamefiningfunction(action);
            Thread.Sleep(1500);
            driver.FindElement(By.CssSelector(css)).SendKeys(@value);
            End();
        }

        //    ================>>>>>>>>>>>>>>  Button
        public void byid(string id, string action)
        {
            if (id.Contains(","))
            {
                string[] idd = id.Split(',');

                Start();
                methodnamefiningfunction(action);
                Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id(idd[0] + d + idd[1])));
                driver.FindElement(By.Id(idd[0] + d + idd[1])).Click();
                End();
            }
            else
            {
                Start();
                methodnamefiningfunction(action);
                Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id(id)));
                driver.FindElement(By.Id(id)).Click();
                End();
            }
        }

        public void byname(string Name, string action)
        {
            Start();
            methodnamefiningfunction(action);
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Name(Name)));
            driver.FindElement(By.Name(Name)).Click();
            End();
        }

        public void byxp(string XPath, string action)
        {
            if (XPath.Contains(","))
            {
                string[] xpa = XPath.Split(',');

                Start();
                methodnamefiningfunction(action);
                Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(xpa[0] + d + xpa[1])));
                driver.FindElement(By.XPath(xpa[0] + d + xpa[1])).Click();
                End();
            }
            else
            {
                Start();
                methodnamefiningfunction(action);
                Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(XPath)));
                driver.FindElement(By.XPath(XPath)).Click();
                End();
            }
        }

        public void bylt(string LinkText, string action)
        {
            Start();
            methodnamefiningfunction(action);
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText(LinkText)));
            driver.FindElement(By.LinkText(LinkText)).Click();
            End();
        }

        public void byplt(string PartialLinkText, string action)
        {
            Start();
            methodnamefiningfunction(action);
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.PartialLinkText(PartialLinkText)));
            driver.FindElement(By.PartialLinkText(PartialLinkText)).Click();
            End();
        }

        public void bycss(string CssSelector, string action)
        {
            Start();
            methodnamefiningfunction(action);
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(CssSelector)));
            driver.FindElement(By.CssSelector(CssSelector)).Click();
            End();
        }



        //DropDown(ByText)
        public void bytextid(string id, string value, string mname)
        {
            Start();
            methodnamefiningfunction(mname);
            IWebElement s = Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id(id)));
            Dropdownz(s, value);
            End();
        }

        public void bytextname(string name, string value, string mname)
        {
            Start();
            methodnamefiningfunction(mname);
            IWebElement s = Wait.Until(ExpectedConditions.ElementToBeClickable(By.Name(name)));
            Dropdownz(s, value);
            End();
        }

        public void bytextxp(string xp, string value, string action)
        {
            Start();
            methodnamefiningfunction(action);
            IWebElement s = Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(xp)));
            Dropdownz(s, value);
            End();
        }
        public void bytextlt(string lt, string value, string action)
        {
            Start();
            methodnamefiningfunction(action);
            IWebElement s = Wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText(lt)));
            Dropdownz(s, value);
            End();
        }

        public void bytextplt(string plt, string value, string action)
        {
            Start();
            methodnamefiningfunction(action);
            IWebElement s = Wait.Until(ExpectedConditions.ElementToBeClickable(By.PartialLinkText(plt)));
            Dropdownz(s, value);
            End();
        }

        public void bytextcss(string css, string value, string action)
        {
            Start();
            methodnamefiningfunction(action);
            IWebElement s = Wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(css)));
            Dropdownz(s, value);
            End();
        }

        //Button->using JavaScript

        public void jbyid(string id, string action)
        {
            Start();
            methodnamefiningfunction(action);
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id(id)));
            IWebElement a = driver.FindElement(By.Id(id));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", a);
            End();
        }

        public void jbyname(string name, string action)
        {
            Start();
            methodnamefiningfunction(action);
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Name(name)));
            IWebElement a = driver.FindElement(By.Name(name));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", a);
            End();
        }

        public void jbyxp(string xp, string action)
        {
            Start();
            methodnamefiningfunction(action);
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(xp)));
            IWebElement a = driver.FindElement(By.XPath(xp));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", a);
            End();
        }

        public void jbylt(string lt, string action)
        {
            Start();
            methodnamefiningfunction(action);
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText(lt)));
            IWebElement a = driver.FindElement(By.LinkText(lt));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", a);
            End();
        }

        public void jbyplt(string plt, string action)
        {
            Start();
            methodnamefiningfunction(action);
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.PartialLinkText(plt)));
            IWebElement a = driver.FindElement(By.PartialLinkText(plt));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", a);
            End();
        }
        public void jbycss(string css, string action)
        {
            Start();
            methodnamefiningfunction(action);
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(css)));
            IWebElement a = driver.FindElement(By.CssSelector(css));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", a);
            End();
        }
        //Alert
        public void alert(string action)
        {
            Start();
            methodnamefiningfunction(action);
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
            driver.SwitchTo().Alert().Accept();
            End();
        }
        public void alertDismiss(string action)
        {
            Start();
            methodnamefiningfunction(action);
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
            driver.SwitchTo().Alert().Dismiss();
            End();
        }
        public System.Drawing.Image GetEntireScreenshot()
        {
            // Get the total size of the page
            var totalWidth = (int)(long)((IJavaScriptExecutor)driver).ExecuteScript("return document.body.offsetWidth"); //documentElement.scrollWidth");
            var totalHeight = (int)(long)((IJavaScriptExecutor)driver).ExecuteScript("return  document.body.parentNode.scrollHeight");
            // Get the size of the viewport
            var viewportWidth = (int)(long)((IJavaScriptExecutor)driver).ExecuteScript("return document.body.clientWidth"); //documentElement.scrollWidth");
            var viewportHeight = (int)(long)((IJavaScriptExecutor)driver).ExecuteScript("return window.innerHeight"); //documentElement.scrollWidth");

            // We only care about taking multiple images together if it doesn't already fit
            if (totalWidth <= viewportWidth && totalHeight <= viewportHeight)
            {
                var screenshot = driver.TakeScreenshot();
                return ScreenshotToImage(screenshot);
            }
            // Split the screen in multiple Rectangles
            var rectangles = new List<Rectangle>();
            // Loop until the totalHeight is reached
            for (var y = 0; y < totalHeight; y += viewportHeight)
            {
                var newHeight = viewportHeight;
                // Fix if the height of the element is too big
                if (y + viewportHeight > totalHeight)
                {
                    newHeight = totalHeight - y;
                }
                // Loop until the totalWidth is reached
                for (var x = 0; x < totalWidth; x += viewportWidth)
                {
                    var newWidth = viewportWidth;
                    // Fix if the Width of the Element is too big
                    if (x + viewportWidth > totalWidth)
                    {
                        newWidth = totalWidth - x;
                    }
                    // Create and add the Rectangle
                    var currRect = new Rectangle(x, y, newWidth, newHeight);
                    rectangles.Add(currRect);
                }
            }
            // Build the Image
            var stitchedImage = new Bitmap(totalWidth, totalHeight);
            // Get all Screenshots and stitch them together
            var previous = Rectangle.Empty;
            foreach (var rectangle in rectangles)
            {
                // Calculate the scrolling (if needed)
                if (previous != Rectangle.Empty)
                {
                    var xDiff = rectangle.Right - previous.Right;
                    var yDiff = rectangle.Bottom - previous.Bottom;
                    // Scroll
                    ((IJavaScriptExecutor)driver).ExecuteScript(String.Format("window.scrollBy({0}, {1})", xDiff, yDiff));
                }
                // Take Screenshot
                var screenshot = driver.TakeScreenshot();
                // Build an Image out of the Screenshot
                var screenshotImage = ScreenshotToImage(screenshot);
                // Calculate the source Rectangle
                var sourceRectangle = new Rectangle(viewportWidth - rectangle.Width, viewportHeight - rectangle.Height, rectangle.Width, rectangle.Height);
                // Copy the Image
                using (var graphics = Graphics.FromImage(stitchedImage))
                {
                    graphics.DrawImage(screenshotImage, rectangle, sourceRectangle, GraphicsUnit.Pixel);
                }
                // Set the Previous Rectangle
                previous = rectangle;
            }
            return stitchedImage;
        }

        private static System.Drawing.Image ScreenshotToImage(OpenQA.Selenium.Screenshot screenshot)
        {
            System.Drawing.Image screenshotImage;
            using (var memStream = new MemoryStream(screenshot.AsByteArray))
            {
                screenshotImage = System.Drawing.Image.FromStream(memStream);
            }
            return screenshotImage;
        }

        public void DatePicker(IWebElement element, string Date)
        {
            if (appname == "STFC")
            {
                string date = Date.Substring(0, 2);
                string month = Date.Substring(3, 2);
                string yr = Date.Substring(6, 4);

                Thread.Sleep(1000);
                ((IJavaScriptExecutor)driver).ExecuteScript(scrollElementIntoMiddle, element);

                //Clicking icon
                Thread.Sleep(1000);
                element.Click();

                //Year
                Thread.Sleep(1000);
                SelectElement s5 = new SelectElement(driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/select[2]")));
                s5.SelectByText(yr);

                //mon
                int mon = Convert.ToInt32(month);
                mon = mon - 1;
                SelectElement s6 = new SelectElement(driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/select[1]")));
                s6.SelectByValue(mon.ToString());

                //Clicking date
                Thread.Sleep(1000);
                int dt = Convert.ToInt32(date);
                Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[contains(@class,'ui-state-default') and (text()='" + dt + "')]")));
                driver.FindElement(By.XPath("//*[contains(@class,'ui-state-default') and (text()='" + dt + "')]")).Click();
            }
            if (appname == "SCUF")
            {
                string date = Date.Substring(0, 2);
                string month = Date.Substring(3, 2);
                string yr = Date.Substring(6, 4);

                Thread.Sleep(1000);
                ((IJavaScriptExecutor)driver).ExecuteScript(scrollElementIntoMiddle, element);

                //Clicking icon
                Thread.Sleep(1000);
                element.Click();

                //Year
                Thread.Sleep(1000);
                SelectElement s5 = new SelectElement(driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/select[2]")));
                s5.SelectByText(yr);

                //mon
                int mon = Convert.ToInt32(month);
                mon = mon - 1;
                SelectElement s6 = new SelectElement(driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/select[1]")));
                s6.SelectByValue(mon.ToString());

                //Clicking date
                Thread.Sleep(1000);
                int dt = Convert.ToInt32(date);
                Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[contains(@class,'ui-state-default') and (text()='" + dt + "')]")));
                driver.FindElement(By.XPath("//*[contains(@class,'ui-state-default') and (text()='" + dt + "')]")).Click();
            }
        }
        public void LookupHandling(IWebElement element, string SearchValue)
        {
            string SearchBy = "";

            if (appname == "STFC")
            {
                Actions actionn = new Actions(driver);
                actionn.DoubleClick(element).Build().Perform();

                Thread.Sleep(1000);
                driver.SwitchTo().Frame(2);

                if (SearchBy != "")
                {
                    IWebElement s = Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("ddlHdrList")));
                    Dropdownz(s, SearchBy);
                }

                Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("txtSearch"))).Clear();
                driver.FindElement(By.Id("txtSearch")).SendKeys(SearchValue);

                Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("btnSearch")));
                driver.FindElement(By.Id("btnSearch")).Click();

                //row click
                Thread.Sleep(500);
                driver.FindElement(By.XPath("//table[@id='rsTable']/tbody/tr[2]/td[@id='0']")).Click();

                driver.SwitchTo().DefaultContent();
            }
            if (appname == "SCUF")
            {
                Actions actions = new Actions(driver);
                actions.DoubleClick(element).Build().Perform();

                Thread.Sleep(1000);
                driver.SwitchTo().Frame(2);

                if (SearchBy != "")
                {
                    IWebElement s = Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("ddlHdrList")));
                    Dropdownz(s, SearchBy);
                }

                Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("txtSearch"))).Clear();
                driver.FindElement(By.Id("txtSearch")).SendKeys(SearchValue);

                Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("btnSearch")));
                driver.FindElement(By.Id("btnSearch")).Click();

                //row click
                Thread.Sleep(500);
                driver.FindElement(By.XPath("//table[@id='rsTable']/tbody/tr[2]/td[@id='0']")).Click();

                driver.SwitchTo().DefaultContent();
            }
        }
        public void Dropdownz(IWebElement FieldName, string FieldValue)
        {
            SelectElement dropDown = new SelectElement(FieldName);
            int index = 0;

            StringBuilder buildz = new StringBuilder(FieldValue.Trim());
            FieldValue = buildz.Replace("-", "").Replace(".", "").Replace(" ", "").ToString();

            foreach (IWebElement selectOptions in dropDown.Options)
            {
                buildz = new StringBuilder(selectOptions.Text);
                string replacedValue = buildz.Replace("-", "").Replace(".", "").Replace(" ", "").ToString();

                if (replacedValue.Equals(FieldValue, StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
                index++;
            }
            dropDown.SelectByIndex(index);
        }
        public void database(string query)
        {
            if (appname == "STFC")
            {
                string sqlConnectionString = "Data Source=192.169.1.109\\sql2012;Initial Catalog=STFCUNO_TESTING;User ID=uno;Password=uno";
                SqlConnection con = new SqlConnection();
                con.ConnectionString = sqlConnectionString;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                SqlDataAdapter Da = new SqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                Da.Fill(ds);
                con.Close();
                DataTable Dt = new DataTable();
                Dt = ds.Copy();
                txt = Dt.Rows[0][0].ToString();
            }
        }

        //Uno Login 
        public void unologin(string url, string browser)
        {
            mname = "Launching URl";

            if (driver == null)
            {
                //URL
                Start();
                methodnamefiningfunction("Launching URl");
                Browser(browser);
                driver.Navigate().GoToUrl(url);

                try
                {
                    driver.SwitchTo().Window(driver.WindowHandles.First());

                    ParentWindow = driver.CurrentWindowHandle;
                }
                catch
                {
                    driver.SwitchTo().Window(driver.WindowHandles.Last());

                    ParentWindow = driver.CurrentWindowHandle;
                }
                End();

                Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            }

            //username
            Start();
            methodnamefiningfunction("Entering Username");
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("txtUsername")));
            driver.FindElement(By.Id("txtUsername")).SendKeys(Username);
            End();

            //unit
            Start();
            methodnamefiningfunction("Entering Unit");
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("txtUnit")));
            driver.FindElement(By.Id("txtUnit")).SendKeys(LoginUnit);
            End();

            //acc period
            Start();
            methodnamefiningfunction("Entering account period");
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("txtFYear")));
            driver.FindElement(By.Id("txtFYear")).SendKeys(AccPeriod);
            End();

            //Captcha
            Start();
            methodnamefiningfunction("Entering Captcha");
            string captcha = driver.FindElement(By.Id("txtcapcha2")).GetAttribute("value");
            if (captcha == "")
            {
                driver.FindElement(By.Id("Imgbtncaptcharefresh2")).Click();
                captcha = driver.FindElement(By.Id("txtcapcha2")).GetAttribute("value");
            }
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("txtCaptcha")));
            driver.FindElement(By.Id("txtCaptcha")).SendKeys(captcha);
            End();

            //password
            Start();
            methodnamefiningfunction("Entering Password");
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("txtPassword")));
            driver.FindElement(By.Id("txtPassword")).SendKeys(Password);
            End();

            //submit
            Start();
            methodnamefiningfunction("Submit");
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("btnSubmit")));
            driver.FindElement(By.Id("btnSubmit")).Click();
            End();
        }

        public void PropertyAdmin(string url, string browser)
        {
            mname = "Launching URl";

            if (driver == null)
            {
                //Launching Url
                Start();

                methodnamefiningfunction("Launching URl");

                Browser(browser);
                driver.Navigate().GoToUrl(url);
                driver.SwitchTo().Window(driver.WindowHandles.Last());
                driver.Manage().Window.Maximize();

                driver.SwitchTo().Window(driver.WindowHandles.Last());
                ParentWindow = driver.CurrentWindowHandle;

                Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

                End();
            }

            //Entering Username
            Start();
            methodnamefiningfunction("Entering Username");
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("txtUsrId")));
            driver.FindElement(By.Id("txtUsrId")).Clear();
            driver.FindElement(By.Id("txtUsrId")).SendKeys(Username);
            End();


            //Entering Password
            Start();
            methodnamefiningfunction("Entering Password");
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("txtPwd")));
            driver.FindElement(By.Id("txtPwd")).Clear();
            driver.FindElement(By.Id("txtPwd")).SendKeys(Password);
            End();


            //Clicking Submit
            Start();
            methodnamefiningfunction("Clicking Submit");
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("btnSignIn")));
            driver.FindElement(By.Id("btnSignIn")).Click();
            End();

            //Entering OTP
            Start();
            methodnamefiningfunction("Entering OTP");
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("txtSubmitOTP")));
            driver.FindElement(By.Id("txtSubmitOTP")).SendKeys("123");
            End();

            //Clicking OTP Confirm
            Start();
            methodnamefiningfunction("Clicking OTP Confirm");
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("btnOTPConfirm")));
            driver.FindElement(By.Id("btnOTPConfirm")).Click();
            End();

            try
            {
                Thread.Sleep(1000);
                Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("btnok")));
                driver.FindElement(By.Id("btnok")).Click();
            }
            catch { }

        }

        public void PropertyBuyer(string url, string browser)
        {
            mname = "Launching URl";

            if (driver == null)
            {
                //Launching Url
                Start();

                methodnamefiningfunction("Launching URl");

                Browser(browser);
                driver.Navigate().GoToUrl(url);
                driver.SwitchTo().Window(driver.WindowHandles.Last());
                driver.Manage().Window.Maximize();

                driver.SwitchTo().Window(driver.WindowHandles.Last());
                ParentWindow = driver.CurrentWindowHandle;

                End();

                Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            }

            user:

            //username
            Start(); methodnamefiningfunction("Entering Username");
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("txtUsrId")));
            driver.FindElement(By.Id("txtUsrId")).SendKeys(Username);
            End();

            //password
            Start(); methodnamefiningfunction("Entering Password");
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("txtPwd")));
            driver.FindElement(By.Id("txtPwd")).SendKeys(Password);
            End();

            //Login
            Start(); methodnamefiningfunction("Clicking Login");
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("btnSignIn")));
            driver.FindElement(By.Id("btnSignIn")).Click();
            End();

            //OTP
            Start();
            methodnamefiningfunction("Entering OTP");
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("txtSubmitOTP")));
            driver.FindElement(By.Id("txtSubmitOTP")).SendKeys("5487");
            End();

            Start(); methodnamefiningfunction("Clicking OTPSubmit");
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("btnOTPConfirm")));
            driver.FindElement(By.Id("btnOTPConfirm")).Click();
            End();


            try
            {
                Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("btnLogoutOk")));
                driver.FindElement(By.Id("btnLogoutOk")).Click();
            }
            catch { }

            try
            {
                Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("ancBacktoHome"))).Click();
                goto user;
            }
            catch { }
        }

        public void GoldLogin(string url, string browser)
        {
            mname = "Launching URl";

            if (driver == null)
            {
                //Launching Url
                Start();

                methodnamefiningfunction("Launching URl");

                Browser(browser);
                driver.Navigate().GoToUrl(url);
                driver.SwitchTo().Window(driver.WindowHandles.Last());
                driver.Manage().Window.Maximize();

                driver.SwitchTo().Window(driver.WindowHandles.Last());
                ParentWindow = driver.CurrentWindowHandle;

                End();

                Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            }

            //Entering Username
            Start();
            methodnamefiningfunction("Entering Username");
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("txtUsrId")));
            driver.FindElement(By.Id("txtUsrId")).Clear();
            driver.FindElement(By.Id("txtUsrId")).SendKeys(Username);
            End();

            //Entering Password
            Start();
            methodnamefiningfunction("Entering Password");
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("txtPwd")));
            driver.FindElement(By.Id("txtPwd")).Clear();
            driver.FindElement(By.Id("txtPwd")).SendKeys(Password);
            End();

            //Clicking Submit
            Start();
            methodnamefiningfunction("Clicking Submit");
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("btnSignIn")));
            driver.FindElement(By.Id("btnSignIn")).Click();
            End();
        }

        public void cameologin(string url, string browser)
        {
            mname = "Launching URl";

            if (driver == null)
            {
                //URL
                Start();
                methodnamefiningfunction("Launching URl");
                Browser(browser);
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl(url);

                driver.SwitchTo().Window(driver.WindowHandles.Last());
                ParentWindow = driver.CurrentWindowHandle;
                End();

                Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            }

            //UserName
            Start();
            methodnamefiningfunction("Entering Username");
            //Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("md_UserID")));
            driver.FindElement(By.Id("md_UserID")).SendKeys(Username);
            End();

            //Password
            Start();
            methodnamefiningfunction("Entering Password");
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("md_Password")));
            driver.FindElement(By.Id("md_Password")).SendKeys(Password);
            End();

            //LoginUnit
            Start();
            methodnamefiningfunction("Entering LoginUnit");
            Thread.Sleep(1000);
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("md_Unit"))).Clear();
            driver.FindElement(By.Id("md_Unit")).SendKeys(LoginUnit);
            End();

            //Captcha
            Start();
            methodnamefiningfunction("Entering Captcha");

            string captcha = driver.FindElement(By.Id("md_captchatxt")).GetAttribute("value");

            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("md_captcha")));
            driver.FindElement(By.Id("md_captcha")).SendKeys(captcha);
            End();

            //submit
            Start();
            methodnamefiningfunction("Submit");
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("btn_loginsubmit")));
            driver.FindElement(By.Id("btn_loginsubmit")).Click();
            End();
        }

        public void Launch(string url, string browser)
        {
            mname = "Launching URl";

            //Launching URL
            Start();
            methodnamefiningfunction("Launching URL");
            Browser(browser);
            driver.Manage().Window.Maximize();
            ParentWindow = driver.CurrentWindowHandle;

            driver.Manage().Cookies.DeleteAllCookies();
            driver.Url = url;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            End();
        }
        public void SCUFlogin(string url, string browser)
        {
            mname = "Launching URl";

            //Launching URL
            Start();
            methodnamefiningfunction("Launching URL");
            Browser(browser);

            driver.Manage().Cookies.DeleteAllCookies();
            driver.Url = url;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            End();

            //Entering UserName 
            Start();
            methodnamefiningfunction("Entering UserName");
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("txtUsername")));
            driver.FindElement(By.Id("txtUsername")).SendKeys(Username);
            End();

            //Entering Password  
            Start();
            methodnamefiningfunction("Entering Password");
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("txtPassword")));
            driver.FindElement(By.Id("txtPassword")).SendKeys(Password);
            End();

            //Entering Login Unit
            Start();
            methodnamefiningfunction("Entering Login Unit");
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("txtUnit")));
            driver.FindElement(By.Id("txtUnit")).SendKeys(LoginUnit);
            End();

            //Clicking Submit
            Start();
            methodnamefiningfunction("Clicking Submit");
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("btnSubmit")));
            driver.FindElement(By.Id("btnSubmit")).Click();
            End();

            //Entering Menu Id
            if (MenuID != "")
            {
                Start();
                methodnamefiningfunction("Entering Menu Id");
                Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='_txtMenuID']")));
                driver.FindElement(By.XPath("//*[@id='_txtMenuID']")).SendKeys(MenuID);
                End();

                //Clicking Go
                Start();
                methodnamefiningfunction("Clicking Go");
                Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='_btnFetch']")));
                driver.FindElement(By.XPath("//*[@id='_btnFetch']")).Click();
                End();
            }
        }

        public void STFClogin(string url, string browser)
        {
            mname = "Launching URl";

            //Launching URL
            Start();
            methodnamefiningfunction("Launching URL");
            Browser(browser);
            driver.Manage().Window.Maximize();
            ParentWindow = driver.CurrentWindowHandle;

            driver.Manage().Cookies.DeleteAllCookies();
            driver.Url = url;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            End();

            //UserName 
            Start();
            methodnamefiningfunction("UserName");
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("txtUsername")));
            driver.FindElement(By.Id("txtUsername")).SendKeys(Username);
            End();

            //password  
            Start();
            methodnamefiningfunction("password");
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("txtPassword")));
            driver.FindElement(By.Id("txtPassword")).SendKeys(Password);
            End();

            //Unit selection
            Start();
            methodnamefiningfunction("Unit selection");
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("txtUnit")));
            driver.FindElement(By.Id("txtUnit")).SendKeys(LoginUnit);
            End();

            //Submit button
            Start();
            methodnamefiningfunction("Submit button");
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("btnSubmit")));
            driver.FindElement(By.Id("btnSubmit")).Click();
            End();


            //Menu Id
            if (MenuID != "")
            {
                Start();
                methodnamefiningfunction("Menu Id");
                Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html[1]/body[1]/form[1]/div[6]/div[2]/div[1]/input[1]")));
                driver.FindElement(By.XPath("/html[1]/body[1]/form[1]/div[6]/div[2]/div[1]/input[1]")).SendKeys(MenuID);
                End();

                //Go click
                Start();
                methodnamefiningfunction("Go click");
                Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html[1]/body[1]/form[1]/div[6]/div[2]/div[2]/button[1]")));
                driver.FindElement(By.XPath("/html[1]/body[1]/form[1]/div[6]/div[2]/div[2]/button[1]")).Click();
                End();
            }
        }

        //Browser
        public void Browser(string browserName)
        {
            if (driver == null)
            {
                if (browserName == "IE")
                {
                    driver = new InternetExplorerDriver();
                    driver.Manage().Window.Maximize();
                    ParentWindow = driver.CurrentWindowHandle;
                }
                else if (browserName == "FireFox")
                {
                    driver = new FirefoxDriver();
                    driver.Manage().Window.Maximize();
                    ParentWindow = driver.CurrentWindowHandle;
                }
                else
                {
                    ChromeOptions chromeOptions = new ChromeOptions();
                    chromeOptions.AddExcludedArgument("enable-automation");
                    chromeOptions.AddArguments("--disable-notifications");
                    if (headless == "On") chromeOptions.AddArgument("--headless");
                    chromeOptions.AddUserProfilePreference("credentials_enable_service", false);
                    chromeOptions.AddUserProfilePreference("profile.password_manager_enabled", false);
                    chromeOptions.AddAdditionalCapability("useAutomationExtension", false);
                    chromeOptions.PageLoadStrategy = PageLoadStrategy.Eager;
                    driver = new ChromeDriver(chromeOptions);
                    driver.Manage().Window.Maximize();
                    ParentWindow = driver.CurrentWindowHandle;
                }
            }
        }

    }
}


