using Newtonsoft.Json.Linq;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;

namespace NRA_ITAS
{
    public class APIOBJ
    {
        public string GetPRNDetails_NRA(string tin, string prn)
        {
            string base_url = string.Empty;
            string uri = "http://10.10.40.13:8181/cxf/trips/collections/getPRNDetails";//string.Format("{0}/token/", base_url);
            string _token = "00";
            string result = string.Empty;


            if (_token != null)
            {
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

                WebRequest request = WebRequest.Create(uri);
                request.Method = WebRequestMethods.Http.Get;
                request.Method = "Get";

                StringBuilder sb = new StringBuilder();
                sb.Append("{\"prnNumber\": \"" + prn + "\",\"tin\": \"" + tin + "\"}");

                //request..AddParameter("application/json", body, ParameterType.RequestBody);

                byte[] postaccessData = Encoding.UTF8.GetBytes(sb.ToString());
                request.ContentLength = postaccessData.Length;

                try
                {
                    System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                    request.GetRequestStream().Write(postaccessData, 0, postaccessData.Length);
                    using (WebResponse response = request.GetResponse())
                    {
                        if (response != null)
                        {
                            StreamReader sd = new StreamReader(response.GetResponseStream());

                            result = sd.ReadToEnd();
                            string data_string = "00|" + result;
                            JObject obj = JObject.Parse(result);
                            string res = (string)obj["resultCode"];
                            //string res1 = (string)obj["paymentReference"]["paymentReferenceDetails"];
                            foreach (var d in obj["paymentReference"]["paymentReferenceDetails"])
                            {

                            }

                            return res;
                        }
                    }
                }
                catch (WebException e)
                {
                    var r = e.Response as HttpWebResponse;
                    if (r == null)
                    {
                        string data_string = "03|" + e.Message;

                        return data_string;
                    }
                    else if (r.StatusCode.ToString().Contains("526"))
                    {
                        string data_string = "04|Prepaid contract is not active or Meter number is blocked.";
                    }
                    else if (r.StatusCode.ToString().Contains(""))
                    {
                        string data_string = "05|";
                    }
                    else
                    {
                        string data_string = "02|" + r.StatusCode + " | " + r.StatusDescription;
                        return data_string;
                    }
                    //return data_string;
                }
            }
            else
            {
                string data_string = "01|INVALID CLIENT CREDENTIALS, OR ACCESS DENIED";

                return data_string;
            }

            return result;
        }


        public string GetPRNDet_NRA(string tin, string prn)
        {
            try
            {
                string result = string.Empty;
                // var handler = new WinHttpHandler();
                //var client = new HttpClient(handler);
                //var client = new RestSharp.RestClient("http://10.10.40.13:8181/cxf/trips/collections/getPRNDetails");
                //var request = new HttpRequestMessage
                StringBuilder sb = new StringBuilder();
                sb.Append("{\"prnNumber\": \"" + prn + "\",\"tin\": \"" + tin + "\"}");
                var request = WebRequest.Create(ConfigurationManager.AppSettings["apiUrl"].ToString() + "/cxf/trips/collections/getPRNDetails");

                request.ContentType = "application/json";
                request.Method = "GET";

                var type = request.GetType();
                var currentMethod = type.GetProperty("CurrentMethod", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(request);

                var methodType = currentMethod.GetType();
                methodType.GetField("ContentBodyNotAllowed", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(currentMethod, false);

                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(sb.ToString());
                }
                using (WebResponse response = request.GetResponse())
                {
                    if (response != null)
                    {
                        StreamReader sd = new StreamReader(response.GetResponseStream());

                        result = sd.ReadToEnd();
                        string data_string = "00|" + result;
                        JObject obj = JObject.Parse(result);
                        string jarr = (string)obj["paymentReference"]["paymentReferenceDetails"].ToString();
                        var jArray = JArray.Parse(jarr);

                        foreach (var ob in jArray)
                        {
                            JObject obarr = JObject.Parse(ob.ToString());
                            //Console.WriteLine(obj);
                        }
                    }
                }


                return result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            //Console.WriteLine(response.Content);
        }
        public string GetEOD_NRA(string tin, string prn)
        {
            string base_url = string.Empty;
            string uri = ConfigurationManager.AppSettings["apiUrl"].ToString() + "/cxf/trips/collections/getPRNDetails";//string.Format("{0}/token/", base_url);
            string _token = "00";
            string result = string.Empty;


            if (_token != null)
            {
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

                WebRequest request = WebRequest.Create(uri);
                request.Method = WebRequestMethods.Http.Post;
                request.Method = "Post";

                StringBuilder sb = new StringBuilder();
                sb.Append("{\"prnNumber\": \"" + prn + "\",\"tin\": \"" + tin + "\"}");

                byte[] postaccessData = Encoding.UTF8.GetBytes(sb.ToString());
                request.ContentLength = postaccessData.Length;

                try
                {
                    System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                    request.GetRequestStream().Write(postaccessData, 0, postaccessData.Length);
                    using (WebResponse response = request.GetResponse())
                    {
                        if (response != null)
                        {
                            StreamReader sd = new StreamReader(response.GetResponseStream());

                            result = sd.ReadToEnd();
                            string data_string = "00|" + result;
                            JObject obj = JObject.Parse(result);
                            string res = (string)obj["resultCode"];
                            //string res1 = (string)obj["paymentReference"]["paymentReferenceDetails"];
                            foreach (var d in obj["paymentReference"]["paymentReferenceDetails"])
                            {

                            }

                            return res;
                        }
                    }
                }
                catch (WebException e)
                {
                    var r = e.Response as HttpWebResponse;
                    if (r == null)
                    {
                        string data_string = "03|" + e.Message;

                        return data_string;
                    }
                    else if (r.StatusCode.ToString().Contains("526"))
                    {
                        string data_string = "04|Prepaid contract is not active or Meter number is blocked.";
                    }
                    else if (r.StatusCode.ToString().Contains(""))
                    {
                        string data_string = "05|";
                    }
                    else
                    {
                        string data_string = "02|" + r.StatusCode + " | " + r.StatusDescription;
                        return data_string;
                    }
                    //return data_string;
                }
            }
            else
            {
                string data_string = "01|INVALID CLIENT CREDENTIALS, OR ACCESS DENIED";

                return data_string;
            }

            return result;
        }

        public string GetBankDailyStatement_NRA(string tin, string prn)
        {
            string base_url = string.Empty;
            string uri = ConfigurationManager.AppSettings["apiUrl"].ToString() + "/cxf/trips/collections/getPRNDetails";//string.Format("{0}/token/", base_url);
            string _token = "00";
            string result = string.Empty;


            if (_token != null)
            {
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

                WebRequest request = WebRequest.Create(uri);
                request.Method = WebRequestMethods.Http.Post;
                request.Method = "Post";

                StringBuilder sb = new StringBuilder();
                sb.Append("{\"prnNumber\": \"" + prn + "\",\"tin\": \"" + tin + "\"}");

                byte[] postaccessData = Encoding.UTF8.GetBytes(sb.ToString());
                request.ContentLength = postaccessData.Length;

                try
                {
                    System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                    request.GetRequestStream().Write(postaccessData, 0, postaccessData.Length);
                    using (WebResponse response = request.GetResponse())
                    {
                        if (response != null)
                        {
                            StreamReader sd = new StreamReader(response.GetResponseStream());

                            result = sd.ReadToEnd();
                            string data_string = "00|" + result;
                            JObject obj = JObject.Parse(result);
                            string res = (string)obj["resultCode"];
                            //string res1 = (string)obj["paymentReference"]["paymentReferenceDetails"];
                            foreach (var d in obj["paymentReference"]["paymentReferenceDetails"])
                            {

                            }

                            return res;
                        }
                    }
                }
                catch (WebException e)
                {
                    var r = e.Response as HttpWebResponse;
                    if (r == null)
                    {
                        string data_string = "03|" + e.Message;

                        return data_string;
                    }
                    else if (r.StatusCode.ToString().Contains("526"))
                    {
                        string data_string = "04|Prepaid contract is not active or Meter number is blocked.";
                    }
                    else if (r.StatusCode.ToString().Contains(""))
                    {
                        string data_string = "05|";
                    }
                    else
                    {
                        string data_string = "02|" + r.StatusCode + " | " + r.StatusDescription;
                        return data_string;
                    }
                    //return data_string;
                }
            }
            else
            {
                string data_string = "01|INVALID CLIENT CREDENTIALS, OR ACCESS DENIED";

                return data_string;
            }

            return result;
        }

        public Boolean InserNRATrans(string Tin, string DateOfPayment, string ModeOfPayment, string PaymentAmount, string Prn, string ReceiptNumber, string BankName, string BankReferenceNumber, string Liabilities, string TransStatus, string PaymentPurpose, string TaxPeriod, string TaxType, string TaxPayerName, string Teller, string bra_code, string From_Acct)
        {


            // string qryString = "UPDATE [dbo].[transactions] SET [Details] = '" + details + "' WHERE reference = '" + transID + "'";
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ITAS_DBConnectionString"].ToString());
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                SqlCommand cmd = new SqlCommand("SP_InsertNRATrans", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Tin", SqlDbType.VarChar).Value = Tin;
                cmd.Parameters.Add("@DateOfPayment", SqlDbType.VarChar).Value = DateOfPayment;
                cmd.Parameters.Add("@ModeOfPayment", SqlDbType.VarChar).Value = ModeOfPayment;
                cmd.Parameters.Add("@PaymentAmount", SqlDbType.VarChar).Value = PaymentAmount;
                cmd.Parameters.Add("@Prn", SqlDbType.VarChar).Value = Prn;
                cmd.Parameters.Add("@ReceiptNumber", SqlDbType.VarChar).Value = ReceiptNumber;
                cmd.Parameters.Add("@BankName", SqlDbType.VarChar).Value = BankName;
                cmd.Parameters.Add("@BankReferenceNumber", SqlDbType.VarChar).Value = BankReferenceNumber;
                cmd.Parameters.Add("@Liabilities", SqlDbType.VarChar).Value = Liabilities;
                cmd.Parameters.Add("@TransStatus", SqlDbType.VarChar).Value = TransStatus;
                cmd.Parameters.Add("@PaymentPurpose", SqlDbType.VarChar).Value = PaymentPurpose;
                cmd.Parameters.Add("@TaxPeriod", SqlDbType.VarChar).Value = TaxPeriod;
                cmd.Parameters.Add("@TaxType", SqlDbType.VarChar).Value = TaxType;
                cmd.Parameters.Add("@TaxPayerName", SqlDbType.VarChar).Value = TaxPayerName; 
                cmd.Parameters.Add("@Teller", SqlDbType.VarChar).Value = Teller;
                cmd.Parameters.Add("@BraCode", SqlDbType.VarChar).Value = bra_code;
                cmd.Parameters.Add("@From_Acct", SqlDbType.VarChar).Value = From_Acct;
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Boolean UpdateApproval(string action, string approveby, string apiresp, string status, string log_seq, string tin, string prn)
        {


            // string qryString = "UPDATE [dbo].[transactions] SET [Details] = '" + details + "' WHERE reference = '" + transID + "'";
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ITAS_DBConnectionString"].ToString());
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                SqlCommand cmd = new SqlCommand("SP_UpdateApproval2", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@API_res", SqlDbType.VarChar).Value = apiresp;
                cmd.Parameters.Add("@tran_status", SqlDbType.VarChar).Value = status;
                cmd.Parameters.Add("@approve_by", SqlDbType.VarChar).Value = approveby;
                cmd.Parameters.Add("@action", SqlDbType.VarChar).Value = action;
                cmd.Parameters.Add("@Tin", SqlDbType.VarChar).Value = tin;
                cmd.Parameters.Add("@Prn", SqlDbType.VarChar).Value = prn;





                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Boolean UpdateApproval(string action, string approveby, string apiresp, string status, string log_seq)
        {


            // string qryString = "UPDATE [dbo].[transactions] SET [Details] = '" + details + "' WHERE reference = '" + transID + "'";
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ITAS_DBConnectionString"].ToString());
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                SqlCommand cmd = new SqlCommand("SP_UpdateApproval", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@API_res", SqlDbType.VarChar).Value = apiresp;
                cmd.Parameters.Add("@tran_status", SqlDbType.VarChar).Value = status;
                cmd.Parameters.Add("@approve_by", SqlDbType.VarChar).Value = approveby;
                cmd.Parameters.Add("@action", SqlDbType.VarChar).Value = action;
                cmd.Parameters.Add("@log_seq", SqlDbType.Int).Value = Convert.ToInt32(log_seq);





                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public string MakePayment_NRA(string tin, string prn, string paymentAmount, string receiptNumber, string createdBy, string doc_ref, string t_period, string t_type, string doc_type, string payerName, string paymentType, string Teller, string rqstPayload)
        {
            //string tin = string.Empty;thtt
            // string prn = string.Empty;
            string amount = string.Empty;
            string receipt = string.Empty;
            string createdby = string.Empty;
            //string doc_ref = string.Empty;
            //string t_period = string.Empty;
            //string t_type = string.Empty;
            //string doc_type = string.Empty;
            //@PaymentPurpose,
            // @TaxPeriod,
            // @TaxType,
            //@TaxPayerName
            string base_url = string.Empty;
            string uri = ConfigurationManager.AppSettings["apiUrl"].ToString() + "/cxf/trips/collections/receivePayment";//string.Format("{0}/token/", base_url);
            string _token = "00";
            string result = string.Empty;


            if (_token != null)
            {
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

                WebRequest request = WebRequest.Create(uri);
                request.Method = WebRequestMethods.Http.Post;
                request.Method = "Post";
                request.ContentType = "application/json";
                string dateOfPayment = DateTime.Now.ToString("yyyy-MM-dd");
                string modeOfPayment = paymentType.ToString().ToUpper();
                string bankName = "AccessBank";
                string Add = string.Empty;

                string bankReferenceNumber = "ABSL" + DateTime.Now.ToString("yyyyssmmddHHMM");//string.Empty;
                StringBuilder sb = new StringBuilder();

                sb.AppendLine("{");
                sb.AppendLine("\"tin\": \"" + tin + "\",");
                sb.AppendLine("\"dateOfPayment\": \"" + dateOfPayment + "\",");
                sb.AppendLine("\"modeOfPayment\": \"" + modeOfPayment + "\", ");
                sb.AppendLine("\"paymentAmount\": \"" + paymentAmount + "\",");
                sb.AppendLine("\"prn\": \"" + prn + "\",");
                sb.AppendLine("\"receiptNumber\": \"" + receiptNumber + "\",");
                sb.AppendLine("\"bankName\" : \"" + bankName + "\",");
                sb.AppendLine("\"bankReferenceNumber\":\"" + bankReferenceNumber + "\",");
                sb.AppendLine(rqstPayload);
                //sb.AppendLine("\"liabilities\": [");
                //// for(int i = 0; i < )
                //// foreach(var obj in liabilities)
                //// {
                //sb.AppendLine("{");
                //sb.AppendLine("\"documentReference\": \"" + doc_ref + "\",");
                //sb.AppendLine("\"documentType\": \"" + doc_type + "\",");
                //sb.AppendLine("\"taxType\": \"" + t_type + "\",");
                //sb.AppendLine("\"taxPeriod\": \"" + t_period + "\",");
                //sb.AppendLine("\"paymentAmount\": \"" + paymentAmount + "\"");
                //sb.AppendLine("}");
                ////  Add = ",";
                //// }

                //sb.AppendLine(" ],");
                sb.AppendLine("\"createdBy\": \"" + createdBy + "\",");
                sb.AppendLine("\"updatedBy\": \"" + createdBy + "\",");
                sb.AppendLine("\"updatedDate\": null,");
                sb.AppendLine("\"createdDate\": null");
                sb.AppendLine("}");

                byte[] postaccessData = Encoding.UTF8.GetBytes(sb.ToString());
                request.ContentLength = postaccessData.Length;

                try
                {
                    System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                    request.GetRequestStream().Write(postaccessData, 0, postaccessData.Length);
                    using (WebResponse response = request.GetResponse())
                    {
                        if (response != null)
                        {
                            StreamReader sd = new StreamReader(response.GetResponseStream());

                            result = sd.ReadToEnd();
                            string data_string = "00|" + result;
                            JObject obj = JObject.Parse(result);
                            string res = (string)obj["resultCode"] +"|"+ obj.ToString();
                            //string res1 = (string)obj["paymentReference"]["paymentReferenceDetails"];
                            //foreach (var d in obj["paymentReference"]["paymentReferenceDetails"])
                            //{

                            //}

                          // bool db_resp = InserNRATrans(tin, dateOfPayment, modeOfPayment, paymentAmount, prn, receiptNumber, bankName, bankReferenceNumber, result, res, doc_type, t_period, t_type, payerName, Teller);

                            return res;
                        }
                    }
                }
                catch (WebException e)
                {
                   // InserNRATrans(tin, dateOfPayment, modeOfPayment, paymentAmount, prn, receiptNumber, bankName, bankReferenceNumber, e.Message, "FAILED", doc_type, t_period, t_type, payerName, Teller);
                    var r = e.Response as HttpWebResponse;
                    if (r == null)
                    {
                        string data_string = "03|" + e.Message;

                        return data_string;
                    }
                    else if (r.StatusCode.ToString().Contains("526"))
                    {
                        string data_string = "04|Prepaid contract is not active or Meter number is blocked.";
                    }
                    else if (r.StatusCode.ToString().Contains(""))
                    {
                        string data_string = "05|";
                    }
                    else
                    {
                        string data_string = "02|" + r.StatusCode + " | " + r.StatusDescription;
                        return data_string;
                    }
                    //return data_string;
                }
            }
            else
            {
                string data_string = "01|INVALID CLIENT CREDENTIALS, OR ACCESS DENIED";

                return data_string;
            }

            return result;
        }

    }
}