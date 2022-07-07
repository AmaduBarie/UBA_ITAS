using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Data;
using QRCoder;
using System.IO;
using System.Drawing.Imaging;

namespace NRA_ITAS
{
    public class ReceiptBuilder
    {
        public string GenerateReceipt(DataTable dt, string receiptNo, string cus_Name, string prn, string tin, string tt)
        {
            decimal t_amt = Convert.ToDecimal(tt);

            StringBuilder q = new StringBuilder();
            q.AppendLine("Customer Name: " + cus_Name + "</div>");
            q.AppendLine("PRN Nunber: " + prn + "</div>");
            q.AppendLine("TIN NUmber: " + tin + "</div>");
            q.AppendLine("Transaction Ref: " + receiptNo + "</div><br />");
            q.AppendLine("Total Amount: " + t_amt.ToString("C").Replace("$", "") + "</div><br />");
            q.AppendLine("Transaction Date: " + DateTime.Now.ToString("f") + "</div>");
            GenerateBarCode(q.ToString(), receiptNo);
            string res = string.Empty;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<!DOCTYPE html>");
            sb.AppendLine("<html lang=\"en\">");
            sb.AppendLine("<head>");
            sb.AppendLine("<meta charset=\"utf-8\">");
            sb.AppendLine("<title>Example 1</title>");
            sb.AppendLine("<style>");
            sb.AppendLine(".clearfix:after {");
            sb.AppendLine("content: \"\";");
            sb.AppendLine("display: table;");
            sb.AppendLine("clear: both;");
            sb.AppendLine("}");

            sb.AppendLine("a {");
            sb.AppendLine("color: #5D6975;");
            sb.AppendLine("text -decoration: underline;");
            sb.AppendLine("}");

            sb.AppendLine("body {");
            sb.AppendLine("position: relative;");
            sb.AppendLine("width: 21cm;");
            sb.AppendLine("height: 29.7cm;");
            sb.AppendLine("margin: 0 auto;");
            sb.AppendLine("color: #001028;");
            sb.AppendLine("background: #FFFFFF;");
            sb.AppendLine("font-family: Arial, sans-serif;");
            sb.AppendLine("font-size: 14px;");
            sb.AppendLine("font-family: Arial;");
            sb.AppendLine("}");

            sb.AppendLine("header {");
            sb.AppendLine("padding: 10px 0;");
            sb.AppendLine("margin -bottom: 30px;");
            sb.AppendLine("}");

            sb.AppendLine("#logo1 {");
            sb.AppendLine("text-align: right;");
            sb.AppendLine("margin-bottom: 10px;");
            sb.AppendLine("}");

            sb.AppendLine("#logo1 img {");
            sb.AppendLine("width: 120px;");
            sb.AppendLine("}");

            sb.AppendLine("#qrcode {");
            sb.AppendLine("text-align: center;");
            sb.AppendLine("margin-bottom: 10px;");
            sb.AppendLine("}");

            sb.AppendLine("#qrcode img {");
            sb.AppendLine("width: 150px;");
            sb.AppendLine("}");

            sb.AppendLine("#logo2 {");
            sb.AppendLine("text-align: left;");
            sb.AppendLine("margin-bottom: 10px;");
            sb.AppendLine("}");

            sb.AppendLine("#logo2 img {");
            sb.AppendLine("width: 120px;");
            sb.AppendLine("}");


            sb.AppendLine("h3 {");
            sb.AppendLine("border-top: 1px solid  #5D6975;");
            sb.AppendLine("border-bottom: 1px solid  #5D6975;");
            sb.AppendLine("color: #5D6975;");
            sb.AppendLine("font-size: 2.4em;");
            sb.AppendLine("line-height: 1.4em;");
            sb.AppendLine("font-weight: normal;");
            sb.AppendLine("text-align: center;");
            sb.AppendLine("margin: 0 0 20px 0;");
            sb.AppendLine("background: url(http://10.240.13.16/logo/dimension.png);");
            sb.AppendLine("}");

            sb.AppendLine("#project {");
            sb.AppendLine("float: left;");
            sb.AppendLine("}");

            sb.AppendLine("#project span {");
            sb.AppendLine("color: #5D6975;");
            sb.AppendLine("text-align: left;");
            sb.AppendLine("width: 100px;");
            sb.AppendLine("margin-right: 20px;");
            sb.AppendLine("display: inline-block;");
            sb.AppendLine("font-size: 0.9em;");
            sb.AppendLine("}");

            sb.AppendLine("#company {");
            sb.AppendLine("float: right;");
            sb.AppendLine("text-align: right;");
            sb.AppendLine("}");

            sb.AppendLine("#project div,");
            sb.AppendLine("#company div {");
            sb.AppendLine("white-space: nowrap;");
            sb.AppendLine("}");

            sb.AppendLine("table {");
            sb.AppendLine("width: 100%;");
            sb.AppendLine("border-collapse: collapse;");
            sb.AppendLine("border-spacing: 0;");
            sb.AppendLine("margin-bottom: 20px;");
            sb.AppendLine("}");

            sb.AppendLine("table tr:nth-child(2n-1) td {");
            sb.AppendLine("background: #F5F5F5;");
            sb.AppendLine("}");

            sb.AppendLine("table th,");
            sb.AppendLine("table td {");
            sb.AppendLine("text-align: center;");
            sb.AppendLine("}");

            sb.AppendLine("table th {");
            sb.AppendLine("padding: 5px 20px;");
            sb.AppendLine("color: #5D6975;");
            sb.AppendLine("border-bottom: 1px solid #C1CED9;");
            sb.AppendLine("white-space: nowrap;");
            sb.AppendLine("font-weight: normal;");
            sb.AppendLine("}");

            sb.AppendLine("table .service,");
            sb.AppendLine("table .desc {");
            sb.AppendLine("text-align: left;");
            sb.AppendLine("}");

            sb.AppendLine("table td {");
            sb.AppendLine("padding: 20px;");
            sb.AppendLine("text-align: right;");
            sb.AppendLine("}");

            sb.AppendLine("table td.service,");
            sb.AppendLine("table td.desc {");
            sb.AppendLine("vertical-align: top;");
            sb.AppendLine("}");

            sb.AppendLine("table td.unit,");
            sb.AppendLine("table td.qty,");
            sb.AppendLine("table td.total {");
            sb.AppendLine("font-size: 1.2em;");
            sb.AppendLine("}");

            sb.AppendLine("table td.grand {");
            sb.AppendLine("border-top: 1px solid #5D6975;");
            sb.AppendLine("}");

            sb.AppendLine("#notices .notice {");
            sb.AppendLine("color: #5D6975;");
            sb.AppendLine("font-size: 1.2em;");
            sb.AppendLine("}");

            sb.AppendLine("footer {");
            sb.AppendLine("color: #5D6975;");
            sb.AppendLine("width: 100%;");
            sb.AppendLine("height: 30px;");
            sb.AppendLine("position: absolute;");
            sb.AppendLine("bottom: 0;");
            sb.AppendLine("border-top: 1px solid #C1CED9;");
            sb.AppendLine("padding: 8px 0;");
            sb.AppendLine("text-align: center;");
            sb.AppendLine("}");
            sb.AppendLine("</style>");
            sb.AppendLine("</head>");
            sb.AppendLine("<body>");
            sb.AppendLine("<header class=\"clearfix\">");
            sb.AppendLine("<table>");

            sb.AppendLine("<tbody>");
            sb.AppendLine("<tr>");
            sb.AppendLine("<td style=\"float:left\">");
            sb.AppendLine("<div id=\"logo1\">");
            sb.AppendLine("<img src=\"http://10.240.13.16/logo/logo.jpg\">");
            sb.AppendLine("</div>");
            sb.AppendLine("</td>");
            sb.AppendLine("<td style=\"float:right\">");
            sb.AppendLine("<div id=\"logo2\">");
            sb.AppendLine("<img src=\"http://10.240.13.16/logo/logo2.png\">");
            sb.AppendLine("</div>");
            sb.AppendLine("</td>");
            sb.AppendLine("</tr>");
            sb.AppendLine("</tbody>");
            sb.AppendLine("</table>");
            sb.AppendLine("<h3>RECEIPT NUMBER: "+ DateTime.Now.ToString("ssMMyyyymmHH") +"</h3>");
            sb.AppendLine("<div id=\"company\" class=\"clearfix\">");
            sb.AppendLine("<div>Access Bank SL</div>");
            sb.AppendLine("<div>30 Siaka Stevens Street,<br /> Freetown, Sierra Leone.</div>");
            sb.AppendLine("<div>Tel: +232 30 96 9943,  +232 76 926032</div>");
            sb.AppendLine("<div>Mail: sierraleonecontactcenter@accessbankplc.com</div>");
            sb.AppendLine("</div>");
            sb.AppendLine("<div id=\"project\">");
            sb.AppendLine("<div><span>Customer Name:</span> "+ cus_Name +"</div>");
            sb.AppendLine("<div><span>PRN Nunber:</span> "+ prn +"</div>");
            sb.AppendLine("<div><span>TIN NUmber:</span> "+ tin +"</div>");
            sb.AppendLine("<div><span>Transaction Ref</span> "+ receiptNo +"</div><br />");
            sb.AppendLine("<div><span>Transaction DATE</span> "+ DateTime.Now.ToString("f") +"</div>");
            sb.AppendLine("</div>");
            sb.AppendLine("</header>");
            sb.AppendLine("<main>");
            sb.AppendLine("<table>");
            sb.AppendLine("<thead>");
            sb.AppendLine("<tr>");
            sb.AppendLine("<th class=\"service\">Doc Ref.</th>");
            sb.AppendLine("<th class=\"desc\">Tax Type</th>");
            sb.AppendLine("<th>Doc Type</th>");
            sb.AppendLine("<th>Tax Period</th>");
            sb.AppendLine("<th>Amount</th>");
            sb.AppendLine("</tr>");
            sb.AppendLine("</thead>");
            sb.AppendLine("<tbody>");
            decimal t = 0;
            foreach(DataRow dr in dt.Rows)
            {
                decimal amt = Convert.ToDecimal(dr["allottedAmount"].ToString());
                t = t + amt;
                sb.AppendLine("<tr>");
                sb.AppendLine("<td class=\"service\">"+ dr["documentReference"].ToString() +"</td>");
                sb.AppendLine("<td class=\"desc\">"+ dr["taxType"].ToString() + "</td>");
                sb.AppendLine("<td class=\"unit\">"+ dr["documentType"].ToString() + "</td>");
                sb.AppendLine("<td class=\"qty\">"+ dr["taxPeriod"].ToString() + "</td>");
                sb.AppendLine("<td class=\"total\">"+ amt.ToString("C").Replace("$", "") + "</td>");
                sb.AppendLine("</tr>");
            }
            
            sb.AppendLine("<tr>");
            sb.AppendLine("<td colspan=\"4\" class=\"grand total\">TOTAL AMOUNT</td>");
            sb.AppendLine("<td class=\"grand total\">Le "+ t.ToString("C").Replace("$", "") + "</td>");
            sb.AppendLine("</tr>");

            sb.AppendLine("</tbody>");
            sb.AppendLine("</table>");
            sb.AppendLine("<td style=\"float:right\">");
            sb.AppendLine("<div id=\"logo2\">");
            sb.AppendLine("<img src=\"http://10.240.13.16/logo/"+ receiptNo +".png\">");
            sb.AppendLine("</div>");
            sb.AppendLine("</td>");
            //sb.AppendLine("<div id=\"notices\">");
            //sb.AppendLine("<div>NOTICE:</div>");
            //sb.AppendLine("<div class=\"notice\">A finance charge of 1.5% will be made on unpaid balances after 30 days.</div>");
            //sb.AppendLine("</div>");
            sb.AppendLine("</main>");
            sb.AppendLine("<footer>");

            sb.AppendLine("Invoice was created on a computer and is valid without the signature and seal.");
            sb.AppendLine("</footer>");
            sb.AppendLine("</body>");
            sb.AppendLine("</html>");

            res = sb.ToString();

            return res;
        }

        private void GenerateBarCode(string qrdata, string receiptNo)
        {
            
            string path = @"C:\inetpub\wwwroot\logo\" + receiptNo + ".png";
            
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeGenerator.QRCode qrCode = qrGenerator.CreateQrCode(qrdata, QRCodeGenerator.ECCLevel.Q);
            System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
            imgBarCode.Height = 150;
            imgBarCode.Width = 150;
            using (System.Drawing.Bitmap bitMap = qrCode.GetGraphic(20))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    byte[] byteImage = ms.ToArray();
                    System.Drawing.Image _img = System.Drawing.Image.FromStream(ms);
                   
                    _img.Save(path, ImageFormat.Png);
                   
                }
            }


            //return path;
        }
    }
}