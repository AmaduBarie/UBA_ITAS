using Newtonsoft.Json.Linq;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;

namespace ServiceAPI
{
    /// <summary>
    /// Summary description for ServicesAPI
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ServicesAPI : System.Web.Services.WebService
    {
        private dataconnect dc = new dataconnect();
        [WebMethod]
        public string PostTrans(string pi_cod_acct_dr, string pi_cod_acct_cr, string brn1, string brn2, string pi_txn_amount, string drcr, string pi_ref_chq_no, string pi_narrative, string eod, string p_err_msg)
        {
            try
            {
                DateTime pi_dat_value = DateTime.Now;
                pi_ref_chq_no = "NR" + DateTime.Now.ToString("yyyyMMddHHmmss");
                string res = "|OK";
                DataSet ds = new DataSet();
                OracleConnection oraconn = new OracleConnection(ConfigurationManager.ConnectionStrings["OraconnStr"].ConnectionString);
                OracleCommand oracmd = new OracleCommand("ACPN_FN_FLEX_POST.post_transaction", oraconn);
                oracmd.CommandType = CommandType.StoredProcedure;
                if (oraconn.State == ConnectionState.Closed)
                {
                    oraconn.Open();
                }
                oracmd.Parameters.Add("pi_cod_acct_dr", OracleDbType.Varchar2, 21).Value = pi_cod_acct_dr;
                oracmd.Parameters.Add("pi_cod_acct_cr", OracleDbType.Varchar2, 21).Value = pi_cod_acct_cr;
                oracmd.Parameters.Add("brn1", OracleDbType.Varchar2, 15).Value = brn1;
                oracmd.Parameters.Add("brn2", OracleDbType.Varchar2, 15).Value = brn2;
                oracmd.Parameters.Add("pi_txn_amount", OracleDbType.Double, 15).Value = Convert.ToDouble(pi_txn_amount);
                oracmd.Parameters.Add("drcr", OracleDbType.Varchar2, 21).Value = drcr;

                oracmd.Parameters.Add("pi_ref_chq_no", OracleDbType.Varchar2, 21).Value = pi_ref_chq_no;
                oracmd.Parameters.Add("pi_dat_value", OracleDbType.Date).Value = pi_dat_value;
                oracmd.Parameters.Add("pi_narrative", OracleDbType.Varchar2, 500).Value = pi_narrative;
                oracmd.Parameters.Add("eod", OracleDbType.Varchar2, 21).Value = eod;
                oracmd.Parameters.Add("p_err_msg", OracleDbType.Varchar2, 21).Value = p_err_msg;
                oracmd.Parameters.Add("p_response", OracleDbType.Varchar2, 100).Direction = ParameterDirection.Output;

                oracmd.ExecuteNonQuery();
                res = oracmd.Parameters["p_response"].Value.ToString();
                return res;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        [WebMethod]
        public void PushToNRA(string log_seq)
        {
            try
            {
                double total_amt = 0.0;
                
                APIOBJ apobj = new APIOBJ();
                string reference = log_seq;
                DataTable tb = dataconnect.getSelectedRowUserApproval(reference);
                //foreach (DataRow dr in tb.Rows)
                //{
                //Session["r_dt"] = tb;
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

                            if (b == 0)
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
                            teller = "";
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
                            rs = "Y";

                            //rs = "Y";
                            if (rs.Trim() == "Y")
                            {

                                //string res = apobj.MakePayment_NRA(tin, prn, _amount, _ref, teller, _docref, _taxPeriod, _taxType, _docType, taxPayerName, tb.Rows[0]["Method of Payment"].ToString(), (string)Session["username"], sb.ToString());
                                //string[] _res = res.Split('|');
                                // if (_res[0].Contains("SUCCESS"))
                                //    {

                                total_amt = total_amt + Convert.ToDouble(_amount);
                                tranresp = "1000";
                               

                            }
                            else
                            {
                                tranresp = "1001";
                              
                                break;
                            }
                        }
                        if (tranresp == "1000")
                        {
                            string res = apobj.MakePayment_NRA(tin, prn, Convert.ToString(t_amt), _ref, teller, _docref, _taxPeriod, _taxType, _docType, taxPayerName, tb.Rows[0]["Method of Payment"].ToString(), "", sb.ToString());
                            string[] _res = res.Split('|');
                            if (_res[0].Contains("SUCCESS"))
                            {

                                // total_amt = total_amt + Convert.ToDouble(_amount);
                                tranresp = "1000";
                               
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

                            }
                        }
                        else
                        {
                           
                        }
                    }
                    else
                    {

                        
                    }

                }
                else
                {

                    
                }
                // }
            }
            catch (Exception ex)
            {

               
            }
        }
        [WebMethod]
        public String GetPRNDetails(String tin, string prn)
        {
            String ret_val = null;
            APIOBJ obj = new APIOBJ();
            ret_val = obj.GetPRNDet_NRA(tin, prn);

            return ret_val;
        }

        [WebMethod]
        public string PostPaymentToCBA(string pi_cod_acct_dr, string pi_cod_acct_cr, string brn1, string brn2, string pi_txn_amount, string drcr, string pi_ref_chq_no, DateTime pi_dat_value, string pi_narrative, string eod, string p_err_msg)
        {
            string res = string.Empty;
            //APIOBJ obj = new APIOBJ();
            //string res = obj.PostTrans(pi_cod_acct_dr, pi_cod_acct_cr, brn1, brn2, pi_txn_amount, drcr, pi_ref_chq_no, pi_dat_value, pi_narrative, eod, p_err_msg);
            return res;
        }

        [WebMethod]
        public string MakePayment_NRA(string tin, string prn, string amount, string receipt, string createdby, string doc_ref, string t_period, string t_type, string doc_type, string payerName)
        {
            string res = string.Empty;
            //APIOBJ obj = new APIOBJ();
            //res = obj.MakePayment_NRA(tin, prn, amount, receipt, "", doc_ref, t_period, t_type, doc_type, payerName);

            return res;
        }

    }
}
