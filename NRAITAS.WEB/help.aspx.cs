using System;

namespace NRA_ITAS
{
    public partial class help : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string usr = (string)Session["username"];
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(usr))
                {
                }
                else
                {
                    Response.Redirect("login.aspx");
                }
            }
        }
    }
}