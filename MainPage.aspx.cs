using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace aUTOMATION
{
    public partial class MainPage : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
        {
            try { Response.Redirect("Merge.aspx"); } catch { }
        }

        protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
        {
            try { Response.Redirect("Replace.aspx"); } catch { }
        }

        protected void ImageButton7_Click(object sender, ImageClickEventArgs e)
        {
            try { Response.Redirect("Seperate.aspx"); } catch { }
        }

        protected void ImageButton9_Click(object sender, ImageClickEventArgs e)
        {
            try { Response.Redirect("Framework.aspx"); } catch { }
        }

        protected void ImageButton10_Click(object sender, ImageClickEventArgs e)
        {
            try { Response.Redirect("Login.aspx"); } catch { }
            Session["User"] = null;
        }


    }
}