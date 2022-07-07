using System;
using System.Data;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
//using iTextSharp.tool.xml;
using System.Text;
using SelectPdf;

namespace NRA_ITAS
{
    public partial class Admins : System.Web.UI.Page
    {
        protected void cancel(object sender, EventArgs e)
        {
        }






        protected void findbranch(object sender, EventArgs e)
        {
            loader("smal");

        }



        protected void getlocationgrall(object sender, EventArgs e)
        {
            loader("big");

        }

        private void populateBranch()
        {
            loadBranch();
        }

        private void loader(string v)
        {
            DataTable tb = dataconnect.getlocation();
            if (v == "big")
            {
                Itas.DataSource = tb;
                Itas.DataBind();
            }

        }

        private void loadBranch()
        {
            DataTable tb = dataconnect.getlocation();
            ddbranch.DataSource = tb;
            ddbranch.DataBind();

        }


        //Itas
        protected void addlocation(object sender, EventArgs e)

        {
            try {
            if (txtbranch.Text != "" && txtlocationaccount.Text != "" && txtbracode.Text != "")
            {

                string user = (string)Session["username"];
                string result = dataconnect.location(txtbranch.Text.ToString(), txtlocationaccount.Text.ToString().Trim(), user, txtbracode.Text.Trim());
                if (result != "fail" )
                {
                    // Response.Redirect("Login.aspx");
                    users.Visible = true;
                    location.Visible = false;
                    txtbranch.Text = "";
                    txtlocationaccount.Text = "";
                    txtbracode.Text = "";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "good", "alert('Location successfully added');", true);

                }
                else
                {
                    users.Visible = true;
                    location.Visible = false;
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "good", "alert('Error:  Location already exist');", true);
                }
            }

            }
            catch (Exception exx) {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "good", "alert('Error: Location can't be added');", true);
            }
        }


        protected void locationadd(object sender, EventArgs e)
        {
            users.Visible = false;
            location.Visible = true;
        }




        protected void back(object sender, EventArgs e)
        {
            users.Visible = true;
            location.Visible = false;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string usr = (string)Session["username"];
            txttiltbox.Text = "000";
            if (!IsPostBack)
            {
                //if (!string.IsNullOrEmpty(usr))
                //{
                DataTable dt = dataconnect.dateFilter(txtsearch.Text);
                gv_trans.DataSource = dt;
                gv_trans.DataBind();

                populateBranch();
                //}
                //  else
                //{
                //    Response.Redirect("login.aspx");
                //}
            }
        }

        protected void search(object sender, EventArgs e)
        {

            DataTable dt = dataconnect.dateFilter(txtsearch.Text);
            gv_trans.DataSource = dt;
            gv_trans.DataBind();
        }



        protected void send(object sender, EventArgs e)
        {

            try {
            string fName = txtfname.Text.Trim();
            string lname = txtlname.Text.Trim();
            string email = txtEmail.Text.Trim();
            string username = txtUsername.Text.Trim();
            string role = txtrole.SelectedValue.Trim();
            string createby = Session["username"].ToString();
            string tiltbox = txttiltbox.Text.Trim();
            //string ddb = ddbranch.SelectedItem.Text;
            string branch = ddbranch.SelectedItem.Value.Trim();
            if (fName.Length < 2 || lname.Length < 2 || email.Length < 2 || username.Length < 2 ||
                role.Length < 2 || createby.Length < 2 || tiltbox.Length < 2)
            {
                // Response.Redirect("Login.aspx");
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script2", "alert('Please Click the \"New User Button\" and Fill in all the input correctly');", true);

            }
            else
            {
                DataTable dt1 = dataconnect.dateFilter(username);
                DataTable dt2 = dataconnect.dateFilter(email);
                if (dt1.Rows.Count == 0 && dt2.Rows.Count == 0)
                {
                    dataconnect.createUser(fName, lname, email, username, role, createby, tiltbox, branch);
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script2", "alert('User is successfully added');", true);
                    txtfname.Text = string.Empty;
                    txtlname.Text = string.Empty;
                    txtEmail.Text = string.Empty;
                    txtUsername.Text = string.Empty;
                    txtrole.SelectedValue = string.Empty;
                    txttiltbox.Text = string.Empty;
                    gv_trans.DataSource = dataconnect.dateFilter(txtsearch.Text.Trim());
                    gv_trans.DataBind();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script2", "alert('User already exists');", true);

                }



            }


            }
            catch (Exception ex) {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script2", "alert('User already exists');", true);

            }

        }

        protected void grdData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv_trans.PageIndex = e.NewPageIndex;
            DataTable dt = dataconnect.dateFilter(txtsearch.Text);
            gv_trans.DataSource = dt;
            gv_trans.DataBind();

        }


        protected string convertDate(string date)
        {
            DateTime da = DateTime.ParseExact(date, @"d MMM, yyyy", System.Globalization.CultureInfo.InvariantCulture);

            return da.ToString("yyyy-MM-dd");
        }




        protected void RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gv_trans, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void delete(object sender, EventArgs e)
        {

            dataconnect.deleteUser(Session["email"].ToString().Trim(), Session["user"].ToString().Trim());


            DataTable dt = dataconnect.dateFilter(txtsearch.Text);
            gv_trans.DataSource = dt;
            gv_trans.DataBind();
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script2", "alert('Successfully delete');", true);
        }

        protected void sel(object sender, EventArgs e)
        {
            string reference = gv_trans.SelectedRow.Cells[1].Text;
            Session["email"] = gv_trans.SelectedRow.Cells[1].Text;
            Session["user"] = gv_trans.SelectedRow.Cells[0].Text;
            //pnlDetail.Visible = true;
            //mpDetails.Show();

            DataTable tb = dataconnect.getSelectedRowUser(reference);
            DetailsView.DataSource = tb;
            DetailsView.DataBind();

            //UpdatePanel.Update();


        }




        protected void refresh(object sender, EventArgs e)
        {
            Response.Redirect("transactions.aspx");
        }
        protected void Reciptss(object sender, EventArgs e)
        {
        }
        protected void Recipts(object sender, EventArgs e)
        {

            string file = Server.MapPath("./Files/timpdf.pdf");

            //pnlDetail.Visible = true;
            //mpDetails.Show();

            DataTable tb = dataconnect.getSelectedRow(Session["reference"].ToString());
            DataTable dt = tb;

            HtmlToPdf converter = new HtmlToPdf();


            string res = HtmlStr(dt);
            // convert the url to pdf
            PdfDocument doc = converter.ConvertHtmlString(res);

            // save pdf document
            doc.Save(file);

            // close pdf document
            doc.Close();
        }



        protected String HtmlStr(DataTable dt)
        {

            StringBuilder sbstr = new StringBuilder();


            //            sbstr.AppendLine("<html>");
            //            sbstr.AppendLine("<body  style=\"margin-top:10px;background:#eee;width:100%\">");
            //            sbstr.AppendLine("<div class=\"container bootdey\">");
            //            sbstr.AppendLine("<div class=\"row invoice row-printable\">");
            //            sbstr.AppendLine("<div class=\"col-md-10\">");
            //            sbstr.AppendLine("<div class=\"panel panel-default plain\" id=\"dash_0\">");
            //            sbstr.AppendLine("<div class=\"panel-body p30\">");
            //            sbstr.AppendLine("<div style = \"display:flex;justify-content:space-between;padding:.1em\">");
            //            sbstr.AppendLine("<img width=\"80\" src=\"https://bootdey.com/img/Content/avatar/avatar7.png\" alt=\"Invoice logo\">");
            //            sbstr.AppendLine("<img width = \"80\" src=\"https://bootdey.com/img/Content/avatar/avatar7.png\" alt=\"Invoice logo\">");
            //            sbstr.AppendLine("</div>");
            //            sbstr.AppendLine("<div class=\"col-lg-12\">");
            //            sbstr.AppendLine("<div class=\"invoice-details mt25\">");
            //            sbstr.AppendLine("<div class=\"well\">");
            //            sbstr.AppendLine("<ul class=\"list-unstyled mb0\">");
            //            sbstr.AppendLine($"<li><strong>TIN</strong> {dt.Rows[dt.Rows.Count - 1][0].ToString()}</li>");
            //            sbstr.AppendLine($"<li><strong>PRN</strong> {dt.Rows[dt.Rows.Count - 1][4].ToString()}</li>");
            //            sbstr.AppendLine($"<li><strong>Date:</strong> {dt.Rows[dt.Rows.Count - 1][1].ToString()}</li>");
            //            sbstr.AppendLine("</ul>");
            //            sbstr.AppendLine("</div>");
            //            sbstr.AppendLine("</div>");
            //            sbstr.AppendLine("<div class=\"invoice-items\">");
            //            sbstr.AppendLine("<div class=\"table-responsive\" style=\"overflow: hidden; outline: none;\" tabindex=\"0\">");
            //            sbstr.AppendLine("<table class=\"table table-bordered\">");
            //            sbstr.AppendLine("<thead>");


            //            //sbstr.AppendLine("<tr><th class=\"per70 text-center\">Description</th>");

            //            //sbstr.AppendLine("<th class=\"per5 text-center\">Qty</th>");
            //            //sbstr.AppendLine("<th class=\"per25 text-center\">Total</th>"); 
            //            sbstr.AppendLine($"<th class=\"per5 text-center\" >{dt.Columns[5].ToString()}</th>");
            //            sbstr.AppendLine($"<th class=\"per5 text-center\" >{dt.Columns[3].ToString()}</th>");
            //            sbstr.AppendLine($"<th class=\"per5 text-center\">{dt.Columns[2].ToString()}</th>");
            //            sbstr.AppendLine($"<th class=\"per5 text-center\">{dt.Columns[9].ToString()}</th>");
            //            sbstr.AppendLine($"<th class=\"per5 text-center\">{dt.Columns[10].ToString()}</th>");
            //            sbstr.AppendLine($"<th class=\"per5 text-center\">{dt.Columns[12].ToString()}</th>");
            //            sbstr.AppendLine($"<th class=\"per5 text-center\">{dt.Columns[1].ToString()}</th>");

            //            sbstr.AppendLine("</tr>");
            //            sbstr.AppendLine("</thead>");
            //            sbstr.AppendLine("<tbody>"); 

            //            for (int i = 0; i < dt.Rows.Count; i++)
            //            {
            //                sbstr.AppendLine("<tr>");
            //                sbstr.AppendLine($"<td class=\"text-center\"> {dt.Rows[i][5].ToString()}</td>");
            //                sbstr.AppendLine($"<td class=\"text-center\"> {dt.Rows[i][3].ToString()}</td>");
            //                sbstr.AppendLine($"<td class=\"text-center\"> {dt.Rows[i][2].ToString()}</td>");
            //                sbstr.AppendLine($"<td class=\"text-center\"> {dt.Rows[i][9].ToString()}</td>");
            //                sbstr.AppendLine($"<td class=\"text-center\"> {dt.Rows[i][10].ToString()}</td>");
            //                sbstr.AppendLine($"<td class=\"text-center\"> {dt.Rows[i][12].ToString()}</td>");
            //                sbstr.AppendLine($"<td class=\"text-center\"> {dt.Rows[i][1].ToString()}</td>");
            //                sbstr.AppendLine("</tr>");
            //            }


            //            sbstr.AppendLine("</tbody>");


            //            sbstr.AppendLine("<tfoot>");
            //            sbstr.AppendLine("<tr>");
            //            sbstr.AppendLine("<th colspan = \"2\" class=\"text-right\">Sub Total:</th>");
            //            sbstr.AppendLine("<th class=\"text-center\">$237.00 USD</th>");
            //            sbstr.AppendLine("</tr>");
            //            sbstr.AppendLine("</tfoot>");
            //            sbstr.AppendLine("</table>");
            //            sbstr.AppendLine("</div>");
            //            sbstr.AppendLine("</div>");
            //            sbstr.AppendLine("</div> ");
            //            sbstr.AppendLine("</div> ");
            //            sbstr.AppendLine("</div>");
            //            sbstr.AppendLine("</div> ");
            //            sbstr.AppendLine("</div> ");
            //            sbstr.AppendLine("</div> ");
            //            sbstr.AppendLine("</body>");
            //            sbstr.AppendLine("</html>");



            return sbstr.ToString();
        }

        protected void ClientButton_Click(object sender, EventArgs e)
        {

        }
    }
}