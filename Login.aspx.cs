using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace aUTOMATION
{
    public partial class Login : System.Web.UI.Page
    {
        public static string Userr = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null)
            {
                Response.Redirect("MainPage.aspx");
            }
        }

        public static int login = 0;
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if (TextBox1.Text == "automation")
            {
                Userr = TextBox1.Text;
                Session["User"] = User;
                Response.Redirect("MainPage.aspx");
                login = 1;
            }
            else
            {
                TextBox1.Text = "";
            }
        }

        protected void ImageButton10_Click(object sender, ImageClickEventArgs e)
        {
            try { Response.Redirect("Login.aspx"); } catch { }
            Session["User"] = null;
        }
    }
}