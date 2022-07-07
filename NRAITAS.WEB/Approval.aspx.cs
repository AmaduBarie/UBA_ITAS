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
using Newtonsoft.Json.Linq;

namespace NRA_ITAS
{
    public partial class Approval : System.Web.UI.Page
    {
        private dataconnect dc = new dataconnect();
        protected void Page_Load(object sender, EventArgs e)
       {
                string usr = (string)Session["username"];
                string bra_code = (string)Session["bra_code"];
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(usr))
                {

                    PopulatePending();
                }
                else
                   {
                      Response.Redirect("login.aspx");
                   }
            }
        }

        //    protected void search(object sender, EventArgs e)
        //    {              

        //        DataTable dt = dataconnect.dateFilter(txtsearch.Text);
        //        gv_trans.DataSource = dt;
        //        gv_trans.DataBind();
        //    }



        protected void grdData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv_trans.PageIndex = e.NewPageIndex;
            DataTable dt = dataconnect.dateFilter("");
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
           
            //    dataconnect.deleteUser( Session["email"].ToString().Trim(), Session["user"].ToString().Trim());
          

            //DataTable dt = dataconnect.dateFilter(txtsearch.Text);
            //gv_trans.DataSource = dt;
            //gv_trans.DataBind();
            //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script2", "alert('Successfully delete');", true);
        }

        protected void sel(object sender, EventArgs e)
            {

            try
            {
                btnApprove.Enabled = true;
                Session["Log_Seq"] = null;
                Session["tin_num"] = null;
                Session["prn_num"] = null;
                string reference = gv_trans.SelectedRow.Cells[0].Text;
                string tin = gv_trans.SelectedRow.Cells[1].Text;
                string prn = gv_trans.SelectedRow.Cells[2].Text;

                Session["Log_Seq"] = reference;
                Session["tin_num"] = tin;
                Session["prn_num"] = prn;

                DataTable tb = dataconnect.getSelectedRowUserApproval(reference);
                int row = tb.Rows.Count;
                DetailsView.DataSource = tb;
                DetailsView.DataBind();

            }
            catch (Exception ex)
            {

            }


            }

      

            //object sender, EventArgs e




            protected void refresh(object sender, EventArgs e)
            {
                Response.Redirect("transactions.aspx");
            }
            protected void Reciptss(object sender, EventArgs e)
            {
            }
            //protected void Recipts(object sender, EventArgs e)
            //{

            //    string file = Server.MapPath("./Files/timpdf.pdf");

            //    //pnlDetail.Visible = true;
            //    //mpDetails.Show();

            //    DataTable tb = dataconnect.getSelectedRow(Session["reference"].ToString());
            //    DataTable dt = tb;

            //    HtmlToPdf converter = new HtmlToPdf();


            //    string res = HtmlStr(dt);
            //    // convert the url to pdf
            //    PdfDocument doc = converter.ConvertHtmlString(res);

            //    // save pdf document
            //    doc.Save(file);

            //    // close pdf document
            //    doc.Close();
            //}



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

        protected void btnPaytax_Click(object sender, EventArgs e)
        {
            try
            {
                btnApprove.Enabled = false;
                double total_amt = 0.0;
                btnApprove.Enabled = false;
                APIOBJ apobj = new APIOBJ();
                string reference = (string)Session["Log_Seq"];
                DataTable tb = dataconnect.getSelectedRowUserApproval(reference);
                //foreach (DataRow dr in tb.Rows)
                //{
                    Session["r_dt"] = tb;
                    string prn = tb.Rows[0]["Prn"].ToString();
                    string tin = tb.Rows[0]["Tin"].ToString();
                    string taxPayerName = tb.Rows[0]["Tax Payer Name"].ToString();
                    string tranresp = string.Empty;
                    string f_acct = tb.Rows[0]["Debit Account"].ToString();// txtAccttoDebit.Text.Trim();
                    string t_acct = string.Empty;
                    string f_bra = f_acct.Substring(0, 3);
                double t_amt = 0;
                int b = 0;
                string _amount = string.Empty, _ref = string.Empty, teller = string.Empty, _docref = string.Empty, _taxPeriod = string.Empty, _taxType = string.Empty, _docType = string.Empty;

                    Random random = new Random();
                    string receipt = "AB" + Convert.ToString(random.Next(0, 99999999).ToString("D10"));
                    //NRAITAS.ServicesAPISoapClient nra = new NRAITAS.ServicesAPISoapClient("ServicesAPISoap");
                    //string nraResp = nra.GetPRNDetails(tin, prn);
                    string nraResp = apobj.GetPRNDet_NRA(tin, prn);
                StringBuilder sb = new StringBuilder();
                if (nraResp.Contains("{"))
                    {
                        JObject obj = JObject.Parse(nraResp);
                    if ((string)obj["resultCode"] == "SUCCESS")
                    {
                        string taxtype = string.Empty;
                        string docref = string.Empty;
                        string doctype = string.Empty;
                        string taxperiod = string.Empty;
                        string jarr = (string)obj["paymentReference"]["paymentReferenceDetails"].ToString();
                        var jArray = JArray.Parse(jarr);
                        int c = jArray.Count;

                        string[] R = new string[c];

                        int n = 0;

                        foreach (var T in jArray)
                        {
                            R[n] = Convert.ToString(T);
                            n++;
                        }
                        for (int i = 0; i < R.Length; i++)
                        {
                            // StringBuilder sb = new StringBuilder();
                           
                            if(b == 0)
                            {
                                sb.AppendLine("\"liabilities\": [");
                                for (int j = 0; j < R.Length; j++)
                                {
                                    JObject p = JObject.Parse(R[j]);
                                    sb.AppendLine("{");
                                    sb.AppendLine("\"documentReference\": \"" + (string)p["documentReference"] + "\",");
                                    sb.AppendLine("\"documentType\": \"" + (string)p["documentType"] + "\",");
                                    sb.AppendLine("\"taxType\": \"" + (string)p["taxPeriod"] + "\",");
                                    sb.AppendLine("\"taxPeriod\": \"" + (string)p["taxPeriod"] + "\",");
                                    sb.AppendLine("\"paymentAmount\": \"" + (string)p["allottedAmount"] + "\"");
                                    int t = j + 1;
                                    if (t < R.Length)
                                    {
                                        sb.AppendLine("},");
                                    }
                                    else
                                    {
                                        sb.AppendLine("}");
                                    }
                                    t_amt = t_amt + Convert.ToDouble((string)p["allottedAmount"]);

                                }
                                b = 1;
                                sb.AppendLine(" ],");
                            }
                           
                            JObject o = JObject.Parse(R[i]);

                            _docref = (string)o["documentReference"];
                            _amount = (string)o["allottedAmount"];
                            _taxPeriod = (string)o["taxPeriod"];
                            _taxType = (string)o["taxType"];
                            _docType = (string)o["documentType"];
                            teller = (string)Session["username"];
                            f_acct = tb.Rows[0]["Debit Account"].ToString();
                            _ref = "NR" + DateTime.Now.ToString("yyyyMMddHHmmss");
                            string rmrks = prn + "-" + tb.Rows[0]["Tax Payer Name"].ToString() + "-" + tin;




                            if (_taxType == "GST")
                            {
                                t_acct = ConfigurationManager.AppSettings["GST_ACCT"].ToString();
                            }
                            else
                            {
                                t_acct = ConfigurationManager.AppSettings["OtherTax_ACCT"].ToString();
                            }
                            string t_bra = t_acct.Substring(0, 3);
                            string rs = string.Empty;
                            //if (prn == "00000000023801")
                            //{
                            //    rs = "Y";
                            //}
                            //else
                            //{
                                rs = dc.PostTrans(f_acct, t_acct, f_bra, t_bra, _amount, "", _ref, DateTime.Now, rmrks, "", "");
                            //}
                            
                            //rs = "Y";
                            if (rs.Trim() == "Y")
                            {

                                //string res = apobj.MakePayment_NRA(tin, prn, _amount, _ref, teller, _docref, _taxPeriod, _taxType, _docType, taxPayerName, tb.Rows[0]["Method of Payment"].ToString(), (string)Session["username"], sb.ToString());
                                //string[] _res = res.Split('|');
                                // if (_res[0].Contains("SUCCESS"))
                                //    {

                                total_amt = total_amt + Convert.ToDouble(_amount);
                                tranresp = "1000";
                                //bool ures = apobj.UpdateApproval("PAID", (string)Session["username"], "", "PAID", (string)Session["Log_Seq"]);
                                apobj.UpdateApproval("PAID", (string)Session["username"], "PAID", "PAID", (string)Session["Log_Seq"], tin, prn);
                                // }
                                //else
                                //{
                                //bool ures = apobj.UpdateApproval("APPROVED", (string)Session["username"], res, "FAILED", (string)Session["Log_Seq"]);
                                //tranresp = "1005";
                                //}

                            }
                            else
                            {
                                tranresp = "1001";
                                bool ures = apobj.UpdateApproval("PENDING", (string)Session["username"], "UNABLE TO DEBIT", "FAILED", (string)Session["Log_Seq"]);
                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script2", "alert('Unable to debit customer account');", true);
                                break;
                            }
                        }
                        if (tranresp == "1000")
                        {
                            string res = apobj.MakePayment_NRA(tin, prn, Convert.ToString(t_amt), _ref, teller, _docref, _taxPeriod, _taxType, _docType, taxPayerName, tb.Rows[0]["Method of Payment"].ToString(), (string)Session["username"], sb.ToString());
                            string[] _res = res.Split('|');
                            if (_res[0].Contains("SUCCESS"))
                            {

                               // total_amt = total_amt + Convert.ToDouble(_amount);
                                tranresp = "1000";
                                apobj.UpdateApproval("APPROVED", (string)Session["username"], res, "SUCCESS", (string)Session["Log_Seq"]);
                            

                            bool ures = apobj.UpdateApproval("APPROVED", (string)Session["username"], "SUCCESS", "SUCCESS", (string)Session["Log_Seq"], tin, prn);
                            ReceiptBuilder rb = new ReceiptBuilder();
                            string fileName = "AB" + prn;
                            string file = Server.MapPath("~/Files/" + fileName + ".pdf");
                            Session["_fileName"] = prn;
                            //DataTable tb = dataconnect.getSelectedRow(Session["reference"].ToString());
                            //DataTable dt = tb;

                            DataTable dt = new DataTable();
                            dt.Columns.Add("documentReference", typeof(System.String));
                            dt.Columns.Add("allottedAmount", typeof(System.Decimal));
                            dt.Columns.Add("taxPeriod", typeof(System.String));
                            dt.Columns.Add("taxType", typeof(System.String));
                            dt.Columns.Add("documentType", typeof(System.String));

                            DataRow row = dt.Rows.Add();
                            decimal tv = 0;
                            for (int i = 0; i < R.Length;)
                            {
                                JObject o = JObject.Parse(R[i]);

                                row.SetField(0, (string)o["documentReference"]);
                                row.SetField(1, Convert.ToDecimal((string)o["allottedAmount"]));
                                row.SetField(2, (string)o["taxPeriod"]);
                                row.SetField(3, (string)o["taxType"]);
                                row.SetField(4, (string)o["documentType"]);
                                tv = tv + Convert.ToDecimal((string)o["allottedAmount"]);
                                i++;
                                if (i < R.Length)
                                {
                                    row = dt.NewRow();
                                    dt.Rows.InsertAt(row, i);
                                }
                                else
                                {
                                    row = dt.NewRow();
                                }
                            }

                            //Session["r_dt"] = dt;

                            HtmlToPdf converter = new HtmlToPdf();
                            string t_amt1 = Convert.ToString(total_amt); // Session["tt"].ToString();
                            string res_ = rb.GenerateReceipt(dt, fileName, taxPayerName, prn, tin, t_amt1);
                            PdfDocument doc = converter.ConvertHtmlString(res_);

                            doc.Save(file);
                            doc.Close();
                            string bra_code = (string)Session["bra_code"];
                            PopulatePending();
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script2", "alert('Operation Successful!...Teller Can Now Print Receipt.'); document.location.href='Approval.aspx';", true);
                            //Response.Redirect("transactions.aspx");
                        }
                        }
                        else
                        {
                            apobj.UpdateApproval("PENDING", (string)Session["username"], "'UNABLE TO DEBIT", "AB ERROR", (string)Session["Log_Seq"]);
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script2", "alert('Unable to debit customer account');", true);
                        }
                        }
                        else
                        {
                           
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script2", "alert('" + nraResp + "');", true);
                        }

                    }
                    else
                    {
                       
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script2", "alert('" + nraResp + "');", true);
                    }
               // }
            }
            catch (Exception ex)
            {
                
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script2", "alert('" + ex.Message + "');", true);
            }
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {

        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            try
            {
               
                
                APIOBJ apobj = new APIOBJ();
                string id = (string)Session["Log_Seq"];
                string tin = (string)Session["tin_num"];
                string prn = (string)Session["prn_num"];
                bool res = apobj.UpdateApproval("REJECTED", (string)Session["username"], "","REJECTED", id, tin, prn);
                PopulatePending();
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script2", "alert('Transaction Has Been Rejected');", true);
            }
            catch(Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script2", "alert('" + ex.Message + "');", true);
            }
        }

        private void PopulatePending()
        {
            string bra_code = (string)Session["bra_code"];
            DataTable dt = dataconnect.getPendingApproval(bra_code);
            gv_trans.DataSource = dt;
            gv_trans.DataBind();
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

    }
}