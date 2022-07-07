using Newtonsoft.Json.Linq;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using SelectPdf;
using System.IO;

namespace NRA_ITAS
{
    public partial class transactions : System.Web.UI.Page
    {
        private dataconnect dc = new dataconnect();
        DataTable r_dt = null;
        string _fileName = string.Empty;
        

        protected void Page_Load(object sender, EventArgs e)
        {
            string usr = (string)Session["username"];
            string tiltbox = (string)Session["TILTBOX"];
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(usr))
                {
                    btnPaytax.Visible = false;
                    btnReset.Visible = false;
                    txtAccttoDebit.Enabled = false;
                    //btnReceipt.Visible = false;
                    DataTable dt = dataconnect.dateFilter("no", "no", (string)Session["username"]);
                    gv_trans.DataSource = dt;
                    gv_trans.DataBind();
                }
                else
                {
                    Response.Redirect("login.aspx");
                }

            }
        }

        protected void search(object sender, EventArgs e)
        {
            string[] ss = txtsearch.Text.Split('-');
            string from = convertDate(ss[0].Trim());
            string to = convertDate(ss[1].Trim());

            DataTable dt = dataconnect.dateFilter(from, to, (string)Session["username"]);
            gv_trans.DataSource = dt;
            gv_trans.DataBind();
        }

        protected void btnValidate_Click(object sender, EventArgs e)
        {
            APIOBJ apobj = new APIOBJ();
            try
            {
                //string em = txtTim.Value;
                string prn = txtPRN.Text.Trim();
                string tin = txtTIN.Text.Trim();
                string payType = drpPaymentType.SelectedValue;
                string cusName = txtName.Text;

                if(payType == "-1")
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script5", "alert('Oops!... Please Select Payment Type.');", true);
                    return;
                }

                if (string.IsNullOrEmpty(prn))
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script5", "alert('Oops!... Please Enter Customer's PRN Number.');", true);
                    return;
                }

                if (string.IsNullOrEmpty(tin))
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script5", "alert('Oops!... Please Enter Customer's TIN Number.');", true);
                    return;
                }

                if (string.IsNullOrEmpty(cusName))
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script5", "alert('Oops!... Please Enter Customer's or Business Name.');", true);
                    return;
                }

                //NRAITAS.ServicesAPISoapClient nra = new NRAITAS.ServicesAPISoapClient("ServicesAPISoap");
                //string nraResp = nra.GetPRNDetails(tin, prn);
                string nraResp = apobj.GetPRNDet_NRA(tin, prn);
                if (nraResp.Contains("{"))
                {
                    JObject obj = JObject.Parse(nraResp);
                    //string res = (string)obj["resultCode"];
                    if ((string)obj["resultCode"] == "SUCCESS")
                    {
                        string taxtype = string.Empty;
                        string docref = string.Empty;
                        string doctype = string.Empty;
                        string taxperiod = string.Empty;
                        string jarr = (string)obj["paymentReference"]["paymentReferenceDetails"].ToString();
                        var jArray = JArray.Parse(jarr);
                        int c = jArray.Count;
                        //string[] R = jArray.ToObject<string[c]>();

                        string[] R = new string[c];

                        int n = 0;

                        foreach (var T in jArray)
                        {
                            R[n] = Convert.ToString(T);
                            n++;
                        }

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

                        Session["r_dt"] = dt;
                        gvPaymentDet.DataSource = dt;
                        gvPaymentDet.DataBind();
                        Session["tt"] = tv;
                        decimal total = tv;
                        gvPaymentDet.FooterRow.Cells[0].Text = "Total Tax Amount";
                        gvPaymentDet.FooterRow.Cells[0].HorizontalAlign = HorizontalAlign.Left;
                        gvPaymentDet.FooterRow.Cells[0].Font.Bold = true;
                        gvPaymentDet.FooterRow.Cells[4].Text = total.ToString("N2");
                        gvPaymentDet.FooterRow.Cells[4].Font.Bold = true;
                        gvPaymentDet.FooterRow.Cells[4].HorizontalAlign = HorizontalAlign.Right;

                        if(payType == "CASH")
                        {
                            txtAccttoDebit.Text = (string)Session["from_acct"];
                        }
                        else
                        {
                            txtAccttoDebit.Enabled = true;
                        }
                        txtPRN.Enabled = false;
                        txtTIN.Enabled = false;
                        btnPaytax.Visible = true;
                        btnReset.Visible = true;
                        pnlNRADATA.Visible = true;
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script2", "alert('" + nraResp + "');", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script3", "alert('" + nraResp + "');", true);
                }
                //pnlNRADATA.Visible = true;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script4", "alert('" + ex.Message + "');", true);
            }
        }

        protected void btnPaytax_Click(object sender, EventArgs e)
        {
            APIOBJ apobj = new APIOBJ();
            try
            {
                btnPaytax.Enabled = false;
                string prn = txtPRN.Text.Trim();
                string tin = txtTIN.Text.Trim();
                string taxPayerName = txtName.Text.Trim();
                string tranresp = string.Empty;
                string f_acct = txtAccttoDebit.Text.Trim();
                string t_acct = string.Empty;
                string f_bra = f_acct.Substring(0, 3);
                string bra_code = (string)Session["bra_code"];
                string from_acct = string.Empty;// (string)Session["from_acct"];
                Random random = new Random();
                string receipt = "AB" + Convert.ToString(random.Next(0, 99999999).ToString("D10"));
                //NRAITAS.ServicesAPISoapClient nra = new NRAITAS.ServicesAPISoapClient("ServicesAPISoap");
                //string nraResp = nra.GetPRNDetails(tin, prn);
                string nraResp = apobj.GetPRNDet_NRA(tin, prn);
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
                            JObject o = JObject.Parse(R[i]);

                            string _docref = (string)o["documentReference"];
                            string _amount = (string)o["allottedAmount"];
                            string _taxPeriod = (string)o["taxPeriod"];
                            string _taxType = (string)o["taxType"];
                            string _docType = (string)o["documentType"];
                            string teller = (string)Session["username"];
                            f_acct = txtAccttoDebit.Text.Trim();
                            string _ref = "NR" + DateTime.Now.ToString("yyyyMMddHHmmss");
                            string rmrks = prn + "-" + txtName.Text.Trim() + "-" + tin;
                            string dateOfPayment = DateTime.Now.ToString("yyyy-MM-dd");
                            string modeOfPayment = drpPaymentType.SelectedValue.ToString().ToUpper();
                            if (modeOfPayment == "CASH")
                            {
                                from_acct = (string)Session["from_acct"];// from_acct;
                            }
                            else
                            {
                                from_acct = txtAccttoDebit.Text.Trim();
                            }
                            string bankName = "AccessBank";
                            if (_taxType == "GST")
                            {
                                t_acct = ConfigurationManager.AppSettings["GST_ACCT"].ToString();
                            }
                            else
                            {
                                t_acct = ConfigurationManager.AppSettings["OtherTax_ACCT"].ToString();
                            }
                            string t_bra = t_acct.Substring(0, 3);
                            
                           // string rs = dc.PostTrans(f_acct, t_acct, f_bra, t_bra, _amount, "", _ref, DateTime.Now, rmrks, "", "");
                            //rs = "Y";
                           // if (rs.Trim() == "Y")
                           // {
                                //APIOBJ apobj = new APIOBJ();
                                bool db_resp = apobj.InserNRATrans(tin, dateOfPayment, modeOfPayment, _amount, prn, receipt, bankName, _ref, "PENDING", "PENDING",_docType, _taxPeriod, _taxType, taxPayerName, (string)Session["username"], bra_code, from_acct);
                            // string res = apobj.MakePayment_NRA(tin, prn, _amount, _ref, teller, _docref, _taxPeriod, _taxType, _docType, taxPayerName, drpPaymentType.SelectedValue, (string)Session["username"]);
                            if (db_resp == true)
                            {
                                tranresp = "1000";
                            }
                            else
                            {
                                tranresp = "1005";
                            }

                            // }
                            // else
                            // {
                            //tranresp = "1001";
                            //btnPaytax.Enabled = true;
                            //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script2", "alert('Unable to debit customer account');", true);
                            //break;
                            // }
                        }

                        if (tranresp == "1000")
                        {
                        //    ReceiptBuilder rb = new ReceiptBuilder();
                        //    string fileName = "AB" + prn;
                        //    string file = Server.MapPath("~/Files/" + fileName + ".pdf");
                        //    Session["_fileName"] = prn;
                        //    //DataTable tb = dataconnect.getSelectedRow(Session["reference"].ToString());
                        //    //DataTable dt = tb;

                        //    HtmlToPdf converter = new HtmlToPdf();
                        //    string t_amt = Session["tt"].ToString();
                        //    string res = rb.GenerateReceipt((DataTable)Session["r_dt"], receipt, taxPayerName, prn, tin, t_amt);
                        //    PdfDocument doc = converter.ConvertHtmlString(res);

                        //    doc.Save(file);
                        //    doc.Close();
                        //    //btnReceipt.Visible = true;
                        //    txtAccttoDebit.Enabled = false;
                        //    txtName.Enabled = false;
                        //    txtPRN.Enabled = false;
                        //    txtTIN.Enabled = false;
                        //    drpPaymentType.Enabled = false;
                           ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script2", "alert('Transaction Submitted For Approval'); document.location.href='transactions.aspx';", true);
                        //    //Response.Redirect("transactions.aspx");
                       }

                    }
                    else
                    {
                        btnPaytax.Enabled = true;
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script2", "alert('" + nraResp + "');", true);
                    }

                }
                else
                {
                    btnPaytax.Enabled = true;
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script2", "alert('" + nraResp + "');", true);
                }
            }
            catch (Exception ex)
            {
                btnPaytax.Enabled = true;
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script2", "alert('" + ex.Message + "');", true);
            }
        }
         
        protected void grdData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv_trans.PageIndex = e.NewPageIndex;
            DataTable dt = dataconnect.dateFilter("no", "no", (string)Session["username"]);
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

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string reference = gv_trans.SelectedRow.Cells[1].Text;
            Session["reference"] = reference;
            //pnlDetail.Visible = true;
            //mpDetails.Show();

            DataTable tb = dataconnect.getSelectedRow(reference);
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
            try
            {
                DataTable tb = dataconnect.getSelectedRow(Session["reference"].ToString());
                DataTable dt = tb;
                foreach(DataRow r in dt.Rows)
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

        protected void btnReset_Click(object sender, EventArgs e)
        {
            btnPaytax.Visible = false;
            btnReset.Visible = false;
            txtAccttoDebit.Enabled = false;
            txtPRN.Enabled = true;
            txtTIN.Enabled = true;
            btnPaytax.Visible = false;
            btnReset.Visible = false;
            pnlNRADATA.Visible = false;
            txtPRN.Text = string.Empty;
            txtTIN.Text = string.Empty;
            txtAccttoDebit.Text = string.Empty;
            txtName.Text = string.Empty;
        }

        protected void btnReceipt_Click(object sender, EventArgs e)
        {
            try
            {
                string fileName = "AB" + (string)Session["_fileName"] + ".pdf";
                //string file = Server.MapPath("~/Files/" + fileName );
                
                Response.ContentType = "application/pdf";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
                Response.TransmitFile(Server.MapPath("~/Files/" + fileName));
                Response.End();
            }
            catch(Exception ex)
            {

            }
        }
    }
}