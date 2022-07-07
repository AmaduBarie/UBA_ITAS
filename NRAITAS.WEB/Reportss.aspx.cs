using ClosedXML.Excel;
using Newtonsoft.Json.Linq;
using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NRA_ITAS
{
    public partial class Reportss : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            gv_trans.DataBind();
            string role = Session["user_role"].ToString();
            if (role == "Teller")
            {
                Response.Redirect("Home.aspx");

            }

            string usr = (string)Session["username"];
            if (!string.IsNullOrEmpty(usr))
            {
            }
            else
            {
                Response.Redirect("login.aspx");
            }
            if (!IsPostBack)
            {
                search.Visible = false;
                gv_trans.DataSource = init();
                gv_trans.DataBind();
                //string role = Session["user_role"].ToString();
                //DataTable tb = new DataTable();
                //if (role == "Auditor")
                //{
                //    tb = dataconnect.report("init", "init", "init", "Auditor");
                //}
                //else
                //{

                //    tb = dataconnect.report("init", "init", "init", usr);
                //}

                //gv_trans.DataSource = tb;
                //gv_trans.DataBind();

            }
        }

        protected void grdData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv_trans.PageIndex = e.NewPageIndex;
            //gv_trans.DataSource = init();
            //gv_trans.DataBind();

        }

        protected DataTable init()
        {
            string usr = (string)Session["username"];
            string role = Session["user_role"].ToString();
            DataTable tb = new DataTable();
            if (role == "Auditor")
            {
                tb = dataconnect.report("init", "init", "init", "Auditor");
            }
            else
            {

                tb = dataconnect.report("init", "init", "init", usr);
            }
            return tb;

        }

        protected void Recipts(object sender, EventArgs e)
        {

            string file = Server.MapPath("./Files/timpdf.pdf");
            try
            {
                DataTable tb = dataconnect.getSelectedRow(Session["reference"].ToString());
                DataTable dt = tb;
                foreach (DataRow r in dt.Rows)
                {
                    if (r["Trans. Status"].ToString() == "SUCCESS")
                    {


                        string fileName = "AB" + r["PRN"] + ".pdf";
                        //string file = Server.MapPath("~/Files/" + fileName );

                        Response.ContentType = "application/pdf";
                        Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
                        Response.TransmitFile(Server.MapPath("~/Files/" + fileName));
                        Response.End();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script20", "alert('SORRY! - Receipt Can Only Be Printed For Approved and Successful Transaction.');", true);
                    }
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script21", "alert('" + ex.Message + "');", true);
            }

        }


        protected void Reciptss(object sender, EventArgs e)
        {
        }


        protected void RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gv_trans, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

            string reference = gv_trans.SelectedRow.Cells[1].Text;
            Session["reference"] = reference;
            //pnlDetail.Visible = true;
            //mpDetails.Show();

            DataTable tb = dataconnect.getSelectedRows(reference);
            DetailsView.DataSource = tb;
            DetailsView.DataBind();

            //UpdatePanel.Update();


        }


        protected void excelExports(object sender, EventArgs e)
        {

        }





        protected void checkeds(object sender, EventArgs e)
        {
            RadioButton bt = (RadioButton)sender;
            string id = bt.ID;
            if (id == "dates")
            {
                enterdate.Visible = true;
                search.Visible = false;
            }
            else
            {
                enterdate.Visible = false;
                search.Visible = true;
            }


        }
        //reports @category varchar(100), @from varchar(100),@begin varchar(100),@end varchar(100)
        //

        //dates


        protected void btnsearcherexl(object sender, EventArgs e)
        {
            System.Web.UI.WebControls.LinkButton btnFrom = (System.Web.UI.WebControls.LinkButton)sender;
            string fbtn = btnFrom.CommandArgument;

            getDataonTable(fbtn);
        }



        protected void btnsearcher(object sender, EventArgs e)
        {


            getDataonTable("data");
        }

        protected void getDataonTable(string fbtn)
        {
            try
            {
                DataTable tb = new DataTable("NRA_Payment");
                string usr = (string)Session["username"];
                string role = Session["user_role"].ToString();

                if (dates.Checked == true)
                {

                    if (txtddst.Text != "-1" && txtMMst.Text != "-1" && txtyyyyst.Text != "-1" && txtddend.Text != "-1" && txtMMend.Text != "-1" && txtyyyend.Text != "-1")
                    {
                        //yyyy - MM - dd
                        string start = $"{txtyyyyst.Text}-{txtMMst.Text}-{txtddst.Text}";// convertDate(txtstart.Text);
                        string end = $"{txtyyyend.Text}-{txtMMend.Text}-{txtddend.Text}"; //convertDate(txtend.Text);
                        if (role == "Auditor")
                        {

                            tb = dataconnect.report("date", start, end, "Auditor");
                            //gv_trans.DataSource = tb;
                            //// gv_trans.DataBind();
                        }
                        else
                        {
                            tb = dataconnect.report("date", start, end, usr);
                            //gv_trans.DataSource = tb;
                            // gv_trans.DataBind();
                        }
                    }
                    else
                    {
                        tb = init();
                    }
                }
                else if (prn.Checked == true)
                {
                    if (role == "Auditor")
                    {

                        tb = dataconnect.report("prn", txtsearchnor.Text, "prn", "Auditor");
                    }
                    else
                    {

                        tb = dataconnect.report("prn", txtsearchnor.Text, "prn", usr);
                    }

                }
                else if (tin.Checked == true)
                {
                    if (role == "Auditor")
                    {

                        tb = dataconnect.report("tin", txtsearchnor.Text, "tin", "Auditor");
                    }
                    else
                    {

                        tb = dataconnect.report("tin", txtsearchnor.Text, "tin", usr);
                    }
                }


                if (fbtn == "excel")
                {
                    tb.TableName = "NRA_TRANS_" + DateTime.Now.ToString("yyyyMMddHHmmss");
                    XLWorkbook wb = new XLWorkbook();
                    // wb.Worksheets.Add("NRA_Test");
                    wb.Worksheets.Add(tb);

                    //wb.Worksheets.Add(failTB);
                    string Pathss = Server.MapPath("./Assets/accessbank.xlsx");
                    wb.SaveAs(Pathss);

                    Response.Clear();
                    Response.ContentType = ContentType;
                    Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(Pathss));
                    Response.WriteFile(Pathss);
                    Response.End();
                }
                else
                {
                    gv_trans.DataSource = tb;
                    gv_trans.DataBind();

                }
            }
            catch (Exception e) { }
        }

        //protected void excelExports(object sender, EventArgs e)
        //{
        //    try
        //    {




        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}

        protected string convertDate(string date)
        {
            try
            {
                DateTime da = DateTime.ParseExact(date, @"d MMM, yyyy", System.Globalization.CultureInfo.InvariantCulture);
                return da.ToString("yyyy-MM-dd");


                //if (date != "1 End Date" && date != "1 Start Date")
                //{
                //    DateTime da = DateTime.ParseExact(date, @"d MMM yyyy", System.Globalization.CultureInfo.InvariantCulture);
                //    if (from == "yes")
                //    {
                //        da = da.AddMonths(1);
                //    }

                //    return da.ToString("yyyy-MM-dd");
                //}
                //else if (from == "no")
                //{
                //    DateTime da = DateTime.Now;

                //    da = da.AddMonths(-1);

                //    return da.ToString("yyyy-MM-dd");
                //}
                //return DateTime.Now.ToString("yyyy-MM-dd");
                //2011 - 10 - 14 17:47:28.370
            }
            catch (Exception ex)
            {
                return null;// ex.Message;
            }

        }
    }
}